using System.Collections.Generic;
using System.Linq;
using CardSorting.Helpers;

namespace CardSorting.GamePlay.Sorting
{
    public abstract class Sorter
    {
        public List<List<Card>> sortedCardListGroups;
        public List<Card> unsortedGroups;

        public int GetUnsortedGroupPoint()
        {
            return DeckHelper.GetTotalCardPoint(unsortedGroups);
        }

        public bool IsCardInTheUnsortedSortedGroup(Card cardToSearch)
        {
            if (unsortedGroups.Find(x => x == cardToSearch) == null)
                return false;
            return true;
        }

        public bool IsSortedCardListInTheSortedGroup(List<Card> cardList)
        {
            return DeckHelper.IsSortedCardListInTheCardGroup(cardList, sortedCardListGroups);
        }

        public bool IsUnsortedCardListInTheSortedGroup(List<Card> cardList)
        {
            return DeckHelper.IsUnsortedCardListInTheCardGroup(cardList, sortedCardListGroups);
        }

        public List<Card> GetSortedList()
        {
            List<Card> sortedList = new List<Card>();

            foreach (var sortedCardList in sortedCardListGroups)
            {
                sortedList.AddRange(sortedCardList);
            }

            sortedList.AddRange(unsortedGroups);

            return sortedList;
        }

        public List<Card> GetOtherCards(List<Card> givenCards, List<Card> allCards)
        {
            return allCards.Where(x =>
            {
                if (givenCards.Find(y => y.DeckCardNumber == x.DeckCardNumber) == null)
                {
                    return true;
                }

                return false;
            }).ToList();
        }
    }
}