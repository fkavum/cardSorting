using System.Collections.Generic;
using System.Linq;
using CardSorting.GamePlay;

namespace CardSorting.Helpers
{
    public static class DeckHelper
    {
        /// <summary>
        /// Find all combinations of the list elements.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="minimumElementCount"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<List<T>> GetAllCombos<T>(List<T> list, int minimumElementCount)
        {
            List<List<T>> result = GetAllCombos(list);
            return result.Where(x => x.Count >= minimumElementCount).ToList();
        }

        /// <summary>
        /// Source: https://stackoverflow.com/questions/7802822/all-possible-combinations-of-a-list-of-values
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<List<T>> GetAllCombos<T>(List<T> list)
        {
            List<List<T>> result = new List<List<T>>();
            // head
            result.Add(new List<T>());
            result.Last().Add(list[0]);
            if (list.Count == 1)
                return result;
            // tail
            List<List<T>> tailCombos = GetAllCombos(list.Skip(1).ToList());
            tailCombos.ForEach(combo =>
            {
                result.Add(new List<T>(combo));
                combo.Add(list[0]);
                result.Add(new List<T>(combo));
            });
            return result;
        }

        public static bool IsSortedCardListInTheCardGroup(List<Card> cardList, List<List<Card>> cardGroup)
        {
            foreach (var sortedCardList in cardGroup)
            {
                if (IsTwoSortedListEqual(cardList, sortedCardList))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsUnsortedCardListInTheCardGroup(List<Card> cardList, List<List<Card>> cardGroup)
        {
            foreach (var sortedCardList in cardGroup)
            {
                if (IsTwoUnsortedListEqual(cardList, sortedCardList))
                {
                    return true;
                }
            }

            return false;
        }

        //if you make this class generic it will fail. Since it needs to use "Card" class equal operator. Not an default class equal operator. 
        public static bool IsTwoSortedListEqual(List<Card> lList, List<Card> rList)
        {
            if (lList.Count != rList.Count) return false;
            int cardsCount = lList.Count;
            for (int i = 0; i < cardsCount; i++)
            {
                if (lList[i] != rList[i]) return false;
            }

            return true;
        }

        public static bool IsTwoUnsortedListEqual(List<Card> lList, List<Card> rList)
        {
            if (lList.Count != rList.Count) return false;
            int cardsCount = lList.Count;
            int matchedCardCount = 0;
            for (int i = 0; i < cardsCount; i++)
            {
                if (lList[i] != rList[i]) matchedCardCount++;
            }

            if (matchedCardCount == cardsCount)
            {
                return true;
            }

            return true;
        }


        public static bool IsOneDeckCardGroup(List<List<Card>> cardGroup)
        {
            foreach (List<Card> cards in cardGroup)
            {
                foreach (Card card in cards)
                {
                    if (GetSearchedCardCountInTheCardGroup(card, cardGroup) > 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static int GetSearchedCardCountInTheCardGroup(Card searchedCard, List<List<Card>> cardGroup)
        {
            int cardCount = 0;
            foreach (List<Card> cards in cardGroup)
            {
                foreach (Card card in cards)
                {
                    if (card == searchedCard)
                        cardCount++;
                }
            }

            return cardCount;
        }
        public static List<Card> GetOtherCards(List<Card> givenCards)
        {
            List<Card> otherCards = givenCards;
            for (int i = 1; i <= 52; i++)
            {
                if (givenCards.Find(x => x.DeckCardNumber == i) == null)
                {
                    otherCards.Add(new Card(i));
                }
            }

            return otherCards;
        }
        public static int GetTotalCardPoint(List<Card> cards)
        {
            int totalPoint = 0;
            foreach (var card in cards)
            {
                totalPoint += card.CardNumber;
            }

            return totalPoint;
        }
    }
}