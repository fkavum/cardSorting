using System.Collections.Generic;

namespace CardSorting.GamePlay.Sorting
{
    public abstract class Sorter
    {
        public List<List<Card>> sortedCardListGroups;
        public List<Card> unsortedGroups;
        
        public int GetUnsortedGroupPoint()
        {
            int totalPoint = 0;
            foreach (var unsortedCard in unsortedGroups)
            {
                totalPoint += unsortedCard.CardNumber;
            }

            return totalPoint;
        }

       

        public bool IsCardInTheUnsortedSortedGroup(Card cardToSearch)
        {
            if (unsortedGroups.Find(x => x == cardToSearch) == null)
                return false;
            return true;
        }
        
        public bool IsSortedCardListInTheSortedGroup(List<Card> cardList)
        {
            foreach (var sortedCardList in sortedCardListGroups)
            {
                if (IsTwoSortedCardListEqual(cardList, sortedCardList))
                {
                    return true;
                }
            }

            return false;
        }
        
        public bool IsUnsortedCardListInTheSortedGroup(List<Card> cardList)
        {
            foreach (var sortedCardList in sortedCardListGroups)
            {
                if (IsTwoUnsortedCardListEqual(cardList, sortedCardList))
                {
                    return true;
                }
            }
        
            return false;
        }

        bool IsTwoSortedCardListEqual(List<Card> lCards, List<Card> rCards)
        {
            if (lCards.Count != rCards.Count) return false;
            int cardsCount = lCards.Count;
            for (int i = 0; i < cardsCount; i++)
            {
                if (lCards[i] != rCards[i]) return false;
            }

            return true;
        }
        
        bool IsTwoUnsortedCardListEqual(List<Card> lCards, List<Card> rCards)
        {
            if (lCards.Count != rCards.Count) return false;
            int cardsCount = lCards.Count;
            int matchedCardCount = 0;
            for (int i = 0; i < cardsCount; i++)
            {
                if (lCards[i] != rCards[i]) matchedCardCount ++;
            }

            if (matchedCardCount == cardsCount)
            {
                return true;
            }
            return true;
        }
    }
}