using System.Collections.Generic;
using System.Linq;

namespace CardSorting.GamePlay.Sorting
{
    public class SequentialSorter:Sorter
    {
        public SequentialSorter(List<Card> cards)
        {
            sortedCardListGroups = new List<List<Card>>();
            unsortedGroups = new List<Card>();

            cards = cards.OrderBy((x) => x.DeckCardNumber).ToList();


            List<Card> sortedCardList = new List<Card>();
            for (int i = 0; i < cards.Count; i++)
            {
                int sortedCardListCount = sortedCardList.Count;
                if (sortedCardListCount == 0)
                {
                    sortedCardList.Add(cards[i]);
                    continue;
                }

                if (sortedCardList[sortedCardListCount - 1].CardNumber + 1 == cards[i].CardNumber)
                {
                    sortedCardList.Add(cards[i]);
                }
                else
                {
                    if (sortedCardList.Count >= 3)
                    {
                        sortedCardListGroups.Add(sortedCardList);
                        sortedCardList = new List<Card>();
                    }

                    unsortedGroups.AddRange(sortedCardList);
                    sortedCardList = new List<Card>();
                    sortedCardList.Add(cards[i]);
                }
            }

            unsortedGroups.AddRange(sortedCardList); //if there is something left in the array we should put it too.
        }
    }
}