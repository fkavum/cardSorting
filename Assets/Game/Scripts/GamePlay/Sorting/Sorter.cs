using System.Collections.Generic;
using CardSorting.Helpers;

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
            return ListHelper.IsSortedCardListInTheCardGroup(cardList, sortedCardListGroups);
        }

        public bool IsUnsortedCardListInTheSortedGroup(List<Card> cardList)
        {
            return ListHelper.IsUnsortedCardListInTheCardGroup(cardList, sortedCardListGroups);
        }
    }
}