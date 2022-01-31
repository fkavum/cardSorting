using System.Collections.Generic;
using System.Linq;

namespace CardSorting.GamePlay.Sorting
{
    public class SequentialSorter : Sorter
    {
        /// <summary>
        /// Sorts automatically in the constructor method
        /// </summary>
        /// <param name="cards"></param>
        public SequentialSorter(List<Card> cards)
        {
            sortedCardListGroups = new List<List<Card>>();
            unsortedGroups = new List<Card>();

            cards = cards.OrderBy((x) => x.DeckCardNumber).ToList();


            List<Card> sortedCardList = new List<Card>();
            for (int i = 0; i < cards.Count; i++)
            {
                int sortedCardListCount = sortedCardList.Count;

                //to add the first element to the sortedCard list.
                if (sortedCardListCount == 0)
                {
                    sortedCardList.Add(cards[i]);
                    continue;
                }

                //if card[i] and the previous one has sequence, there is a match possibility!
                if (sortedCardList[sortedCardListCount - 1].CardNumber + 1 == cards[i].CardNumber)
                {
                    sortedCardList.Add(cards[i]);
                }
                else
                {
                    //if count>3 there is a match!
                    if (sortedCardList.Count >= 3)
                    {
                        sortedCardListGroups.Add(sortedCardList);
                        sortedCardList = new List<Card>();
                    }

                    //if there is no match! (I didnt put the first two line to else statement.
                    unsortedGroups.AddRange(sortedCardList);
                    sortedCardList = new List<Card>();
                    sortedCardList.Add(cards[i]);
                }
            }

            //Checking for the last card.
            if (sortedCardList.Count >= 3)
            {
                sortedCardListGroups.Add(sortedCardList);
            }
            else
            {
                unsortedGroups.AddRange(sortedCardList); //if there is something left in the array we should put it too.
            }
        }
    }
}