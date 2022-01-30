using System.Collections.Generic;
using System.Linq;
using CardSorting.GamePlay;
using CardSorting.Helpers;
using CardSorting.Scriptable;
using DG.Tweening;
using UnityEngine;

namespace CardSorting.UI.Gameplay
{
    public class DeckEntity : MonoBehaviour
    {
        public DeckConfig deckConfig;
        public RectTransform deckHolder;
        public RectTransform deckCardPosition;
        public CardEntity cardTemplatePrefab;


        public List<CardEntity> cardEntities;
        public int _themeIndex = 0;
        public void Initialize()
        {
            Deck deck = new Deck();
            cardEntities = new List<CardEntity>();
            for (int i = 1; i <= 52; i++)
            {
                CardEntity newCardEntity = Instantiate(cardTemplatePrefab, deckHolder);
                RectTransform newCardEntityRect = newCardEntity.GetComponent<RectTransform>();
                newCardEntityRect.anchoredPosition = deckCardPosition.anchoredPosition;
                newCardEntity.backSide.SetActive(true);
                newCardEntity.frontSide.SetActive(false);
                newCardEntity.backImage.sprite = deckConfig.cardBackImages[_themeIndex];
                var cardConfig = deckConfig.cardConfigs.Find(x => i == x.deckNumber);

                if (cardConfig == null)
                {
                    Debug.LogWarning($"Card config not found! deckNumber: {i}");
                }

                newCardEntity.frontImage.sprite = cardConfig.cardSprite;
                newCardEntity.cardConfig = cardConfig;
                newCardEntity.card = deck.Cards[i - 1];
                cardEntities.Add(newCardEntity);
            }
        }

        public void ChangeTheme()
        {
            int newIndex = _themeIndex + 1;
            if (newIndex >= deckConfig.cardBackImages.Length)
            {
                newIndex = 0;
            }

            _themeIndex = newIndex;

            foreach (var card in cardEntities)
            {
                card.backImage.sprite = deckConfig.cardBackImages[newIndex];
            }
        }

        public void Shuffle()
        {
            System.Random rng = new System.Random(UnityEngine.Random.Range(0, 999999));
            rng.Shuffle(cardEntities);
        }

        public void Shuffle(int seed)
        {
            System.Random rng = new System.Random(seed);
            rng.Shuffle(cardEntities);
        }

        public List<CardEntity> TakeCards(int count)
        {
            return cardEntities.Take(count).ToList();
        }

        public List<CardEntity> TakePrecalculatedCards(List<int> deckNumberList)
        {
            List<CardEntity> returnedCardEntities = new List<CardEntity>();

            for (int i = 0; i < deckNumberList.Count; i++)
            {
                returnedCardEntities.Add(cardEntities.Find(x => x.cardConfig.deckNumber == deckNumberList[i]));
            }

            return returnedCardEntities;
        }

        public void ReturnCards(List<CardEntity> returnedCardEntities)
        {
            Shuffle();

            for (int i = 0; i < returnedCardEntities.Count; i++)
            {
                CardEntity returnedCardEntity = returnedCardEntities[i];
                returnedCardEntity.holder = null;
                RectTransform cardEntityRect = returnedCardEntity.GetComponent<RectTransform>();


                cardEntityRect.SetParent(deckHolder);
                cardEntityRect.DOLocalMove(deckCardPosition.anchoredPosition, 1).SetDelay(i * 0.1f);
                cardEntityRect.DOLocalRotate(new Vector3(0, 85, 0), .35f).OnComplete(
                    () =>
                    {
                        returnedCardEntity.backSide.SetActive(true);
                        returnedCardEntity.frontSide.SetActive(false);
                        cardEntityRect.DOLocalRotate(new Vector3(0, 0, 0), .35f).SetEase(Ease.Linear);
                    }
                ).SetDelay(i * 0.1f).SetEase(Ease.Linear);
            }
        }
    }
}