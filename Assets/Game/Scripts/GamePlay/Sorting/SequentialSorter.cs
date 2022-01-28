using System.Collections.Generic;
using System.Linq;

namespace CardSorting.GamePlay.Sorting
{
    public class SequentialSorter
    {
        public List<List<Card>> sortedCardListGroups;
        public List<Card> unsortedGroups;

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
                    }
                    else
                    {
                        unsortedGroups.AddRange(sortedCardList);
                    }
                }
            }
        }

        public int GetUnsortedGroupPoint()
        {
            int totalPoint = 0;
            foreach (var unsortedCard in unsortedGroups)
            {
                totalPoint += unsortedCard.CardNumber;
            }

            return totalPoint;
        }
        
    }
}