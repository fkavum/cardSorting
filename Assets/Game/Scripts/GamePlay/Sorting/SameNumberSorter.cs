using System.Collections.Generic;
using System.Linq;

namespace CardSorting.GamePlay.Sorting
{
    public class SameNumberSorter:Sorter
    {
    
        /// <summary>
        /// Sorts automatically in the constructor method
        /// </summary>
        /// <param name="cards"></param>
        public SameNumberSorter(List<Card> cards)
        {
            sortedCardListGroups = new List<List<Card>>();
            unsortedGroups = new List<Card>();

            //Orders by cardNumber
            cards = cards.OrderBy((x) => x.CardNumber).ToList();


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

                //if card[i] has the same card number as the previous one add that one to list.
                if (sortedCardList[sortedCardListCount - 1].CardNumber == cards[i].CardNumber)
                {
                    sortedCardList.Add(cards[i]);
                }
                else //When there is no more match, we empty the list here to search for new sorting match.
                {
                    
                    //if count>3 there is a match!
                    if (sortedCardList.Count >= 3)
                    {
                        sortedCardListGroups.Add(sortedCardList);
                        sortedCardList = new List<Card>();
                    }
                    //if there is no match! (I didnt put the first two line to else statement. since sortedCard will be already empty if there is a match)
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