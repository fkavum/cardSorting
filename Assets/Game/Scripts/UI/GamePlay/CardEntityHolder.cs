using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CardSorting.GamePlay;
using CardSorting.GamePlay.Sorting;
using CardSorting.UI.Gameplay;
using CardSorting.Utils;
using UnityEngine;
using DG.Tweening;
public class CardEntityHolder : MonoBehaviour
{
    public RectTransform startPoint;
    public RectTransform endPoint;
    public RectTransform controlPoint;

    public CubicBezier _bezier;
    public CardEntity _pickedCard;

    public List<CardEntity> cardEntities;
    [HideInInspector]public TableEntity tableEntity;


    public void Initialize(List<CardEntity> cardEntities)
    {
        this.cardEntities = cardEntities;
        _bezier = new CubicBezier(startPoint.anchoredPosition, endPoint.anchoredPosition, controlPoint.anchoredPosition);
        int cardEntitiesCount = this.cardEntities.Count;
        for (int i = 0; i < cardEntitiesCount; i++)
        {
            CardEntity cardEntity = cardEntities[i];
            cardEntity.holder = this;
            RectTransform cardEntityRect = cardEntity.GetComponent<RectTransform>();
            Vector2 newPos = _bezier.Solve(i / (float) (cardEntitiesCount -1));
            float angle = _bezier.SolveTangent(i / (float) (cardEntitiesCount -1));
            
            cardEntityRect.SetParent(transform);
            cardEntityRect.DOLocalMove(newPos, 1).SetDelay(i * 0.1f);
            cardEntityRect.DOLocalRotate(new Vector3(0, 85, 0), .5f).OnComplete(
                () =>
                {
                    cardEntity.backSide.SetActive(false);
                    cardEntity.frontSide.SetActive(true);
                    cardEntityRect.DOLocalRotate(new Vector3(0, 0, angle), .5f);
                }
            ).SetDelay(i * 0.1f);
        }
    }

    public void SortSequentially()
    {
        List<Card> cards = cardEntities.ConvertAll(x => x.card);
        SequentialSorter sequentialSorter = new SequentialSorter(cards);
        cards = sequentialSorter.GetSortedList();
        cardEntities = cards.ConvertAll(x =>
        {
            var entity = cardEntities.Find(y => y.cardConfig.deckNumber == x.DeckCardNumber);
            return entity;
        });

        Animate();
    }
    
    public void SortSameNumber()
    {
        List<Card> cards = cardEntities.ConvertAll(x => x.card);
        SameNumberSorter sequentialSorter = new SameNumberSorter(cards);
        cards = sequentialSorter.GetSortedList();
        cardEntities = cards.ConvertAll(x =>
        {
            var entity = cardEntities.Find(y => y.cardConfig.deckNumber == x.DeckCardNumber);
            return entity;
        });

        Animate();
    }
    
    public void SortSmart()
    {
        List<Card> cards = cardEntities.ConvertAll(x => x.card);
        SmartSorter sequentialSorter = new SmartSorter(cards);
        cards = sequentialSorter.GetSortedList();
        cardEntities = cards.ConvertAll(x =>
        {
            var entity = cardEntities.Find(y => y.cardConfig.deckNumber == x.DeckCardNumber);
            return entity;
        });

        Animate();
    }

    void Animate()
    {
        int cardEntitiesCount = cardEntities.Count;
        for (int i = 0; i < cardEntitiesCount; i++)
        {
            CardEntity cardEntity = cardEntities[i];
            RectTransform cardEntityRect = cardEntity.GetComponent<RectTransform>();
            Vector2 newPos = _bezier.Solve(i / (float) (cardEntitiesCount -1));
            float angle = _bezier.SolveTangent(i / (float) (cardEntitiesCount -1));
            
            cardEntityRect.SetSiblingIndex(i);
            cardEntityRect.DOLocalMove(newPos, 1);
            cardEntityRect.DOLocalRotate(new Vector3(0, 0, angle), 1);
        }
    }

    public void FixPlacement()
    {
        int cardEntitiesCount = cardEntities.Count;
        for (int i = 0; i < cardEntitiesCount; i++)
        {
            CardEntity cardEntity = cardEntities[i];
            
            RectTransform cardEntityRect = cardEntity.GetComponent<RectTransform>();
            Vector2 newPos = _bezier.Solve(i / (float) (cardEntitiesCount -1));
            float angle = _bezier.SolveTangent(i / (float) (cardEntitiesCount -1));
            
            cardEntityRect.SetSiblingIndex(i);
            cardEntityRect.DOLocalMove(newPos, .1f);
            cardEntityRect.DOLocalRotate(new Vector3(0, 0, angle), .1f);
        }
      
    }
    public void PickCard(CardEntity entity)
    {
        RectTransform cardEntityRect = entity.GetComponent<RectTransform>();
        cardEntityRect.SetSiblingIndex(transform.childCount -1);
        cardEntityRect.DOScale(2.5f, 0.1f);
        _pickedCard = entity;
    }

    public void HoverOver(CardEntity entity)
    {
        if(!_pickedCard) return;
        int pickedCardIndex = cardEntities.FindIndex(x => x == _pickedCard);
        int hoverOverIndex = cardEntities.FindIndex(x => x == entity);

        cardEntities[pickedCardIndex] = entity;
        cardEntities[hoverOverIndex] = _pickedCard;
        
        FixPlacement();

    }

    public void PutOver(CardEntity entity)
    {
        
    }
}
