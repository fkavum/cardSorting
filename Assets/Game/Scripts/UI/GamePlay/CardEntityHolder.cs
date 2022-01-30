using System.Collections.Generic;
using CardSorting.GamePlay;
using CardSorting.GamePlay.Sorting;
using CardSorting.UI.Gameplay;
using CardSorting.Utils;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// This is a card holder class.
/// Its responsible for all of the card operations in the hand. Like, card placement, sorting, etc.
/// </summary>
public class CardEntityHolder : MonoBehaviour
{
    public RectTransform startPoint;
    public RectTransform endPoint;
    public RectTransform controlPoint;

    public CubicBezier _bezier;
    public CardEntity _pickedCard;

    public List<CardEntity> cardEntities;
    [HideInInspector] public TableEntity tableEntity;


    public void Initialize(List<CardEntity> cardEntities)
    {
        this.cardEntities = cardEntities;
        _bezier = new CubicBezier(startPoint.anchoredPosition, endPoint.anchoredPosition,
            controlPoint.anchoredPosition);
        int cardEntitiesCount = this.cardEntities.Count;
        for (int i = 0; i < cardEntitiesCount; i++)
        {
            CardEntity cardEntity = cardEntities[i];
            cardEntity.holder = this;
            RectTransform cardEntityRect = cardEntity.GetComponent<RectTransform>();
            Vector2 newPos = _bezier.Solve(i / (float) (cardEntitiesCount - 1));
            float angle = _bezier.SolveTangent(i / (float) (cardEntitiesCount - 1));

            cardEntityRect.SetParent(transform);
            cardEntityRect.SetSiblingIndex(i);
            cardEntityRect.DOKill();
            cardEntityRect.DOLocalMove(newPos, 1).SetDelay(i * 0.1f).OnKill(
                () => { cardEntityRect.anchoredPosition = newPos; }
            );
            cardEntityRect.DOLocalRotate(new Vector3(0, 85, 0), .5f).OnComplete(
                () =>
                {
                    cardEntity.backSide.SetActive(false);
                    cardEntity.frontSide.SetActive(true);
                    cardEntityRect.DOLocalRotate(new Vector3(0, 0, angle), .5f);
                }
            ).SetDelay(i * 0.1f).OnKill(() =>
            {
                cardEntity.backSide.SetActive(false);
                cardEntity.frontSide.SetActive(true);
                cardEntityRect.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            });
        }
    }

    public void SortSequentially()
    {
        if(cardEntities.Count == 0) return;
        
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
        if(cardEntities.Count == 0) return;
        List<Card> cards = cardEntities.ConvertAll(x => x.card);
        SameNumberSorter sameNumberSorter = new SameNumberSorter(cards);
        cards = sameNumberSorter.GetSortedList();
        cardEntities = cards.ConvertAll(x =>
        {
            var entity = cardEntities.Find(y => y.cardConfig.deckNumber == x.DeckCardNumber);
            return entity;
        });

        Animate();
    }

    public void SortSmart()
    {
        if(cardEntities.Count == 0) return;
        List<Card> cards = cardEntities.ConvertAll(x => x.card);
        SmartSorter smartSorter = new SmartSorter(cards);
        cards = smartSorter.GetSortedList();
        cardEntities = cards.ConvertAll(x =>
        {
            var entity = cardEntities.Find(y => y.cardConfig.deckNumber == x.DeckCardNumber);
            return entity;
        });

        Animate();
    }

    void Animate(float duration = 1f)
    {
        int cardEntitiesCount = cardEntities.Count;
        for (int i = 0; i < cardEntitiesCount; i++)
        {
            CardEntity cardEntity = cardEntities[i];
            RectTransform cardEntityRect = cardEntity.GetComponent<RectTransform>();
            Vector2 newPos = _bezier.Solve(i / (float) (cardEntitiesCount - 1));
            float angle = _bezier.SolveTangent(i / (float) (cardEntitiesCount - 1));

            cardEntityRect.SetSiblingIndex(i);
            cardEntityRect.DOKill();
            cardEntityRect.DOLocalMove(newPos, duration).OnKill(() =>
            {
                cardEntityRect.anchoredPosition = newPos;
            });
            cardEntityRect.DOLocalRotate(new Vector3(0, 0, angle), duration).OnKill(() =>
            {
                cardEntityRect.localRotation = Quaternion.Euler(new Vector3(0,0,angle));
            });
        }
    }

    public void FixPlacement()
    {
        Animate(0.1f);
    }

    public void PickCard(CardEntity entity)
    {
        RectTransform cardEntityRect = entity.GetComponent<RectTransform>();
        cardEntityRect.SetSiblingIndex(transform.childCount - 1);
        cardEntityRect.DOScale(2.5f, 0.1f);
        _pickedCard = entity;
    }
    
    // if hover 3, and picked 5 -> hover:3 picked:4 4-> 5
    // if hover 2 and picked 5 -> hover:2 picked 3 , 3-> 4  , 4 -> 5
    // if hover 5, and picked 3 -> hover: 4, picked 5, 4 -> 3, 
    public void HoverOver(CardEntity entity)
    {
        if (!_pickedCard) return;
        
        cardEntities.Remove(_pickedCard);
        int hoverOverIndex = cardEntities.FindIndex(x => x == entity);
        cardEntities.Insert(hoverOverIndex + 1 , _pickedCard);
        FixPlacement();
    }

    public void PutOver(CardEntity entity)
    {
    }
}