using System.Collections.Generic;
using CardSorting.Helpers;

namespace CardSorting.GamePlay.Sorting
{
    public class SmartSorter : Sorter
    {
        /// <summary>
        /// Sorts automatically in the constructor method
        /// </summary>
        /// <param name="cards"></param>
        public SmartSorter(List<Card> cards)
        {
            sortedCardListGroups = new List<List<Card>>();
            unsortedGroups = new List<Card>();

            SequentialSorter sequentialSorter = new SequentialSorter(cards); //Sort sequentially first.
            SameNumberSorter sameNumberSorter = new SameNumberSorter(cards); //Then sort with 777 algorthm.
            
            //Add all of the sequential sorted cards. With combination (if there is 4 card match, we should consider the 3 card match scenario too). 
            if (sequentialSorter.sortedCardListGroups.Count > 0)
            {
                foreach (var seqCardList in sequentialSorter.sortedCardListGroups)
                {
                    sortedCardListGroups.AddRange(DeckHelper.GetAllCombos(seqCardList, 3));
                }
            }
            //Add all of the 777 sorted cards. With combination (if there is 4 card match, we should consider the 3 card match scenario too). 
            if (sameNumberSorter.sortedCardListGroups.Count > 0)
            {
                foreach (var sameCardList in sameNumberSorter.sortedCardListGroups)
                {
                    sortedCardListGroups.AddRange(DeckHelper.GetAllCombos(sameCardList, 3));
                }
            }

            // if there is no match for both algorithm. There is no match for this(smart sorting) algorithm too.
            if (sortedCardListGroups.Count == 0)
            {
                unsortedGroups = cards;
                return;
            }

            //Get combination of all of the sortedCardListGroups from that two algorithm (123 and 777 sorting).
            //This list will have the answers!
            List<List<List<Card>>> allCombos = DeckHelper.GetAllCombos(sortedCardListGroups);
            //Get rid of the answers that have the duplicated cards!            
            List<List<List<Card>>> cardGroups = GetOneDeckCardGroups(allCombos);

            //Look the min lowestOtherCardPoints.
            List<List<Card>> bestCombo = null;
            int lowestOtherCardsPoint = 999;
            List<Card> bestUnsortedGroup = null;
            foreach (var cardGroup in cardGroups)
            {
                List<Card> allCardsInTheCardGroup = new List<Card>();
                foreach (List<Card> cardList in cardGroup)
                {
                    allCardsInTheCardGroup.AddRange(cardList);
                }

                List<Card> otherCards = GetOtherCards(allCardsInTheCardGroup, cards);
                int otherCardsPoint = DeckHelper.GetTotalCardPoint(otherCards);

                if (otherCardsPoint < lowestOtherCardsPoint)
                {
                    bestCombo = cardGroup;
                    bestUnsortedGroup = otherCards;
                    lowestOtherCardsPoint = otherCardsPoint;
                }
            }

            sortedCardListGroups = bestCombo;
            unsortedGroups = bestUnsortedGroup;

            //This just for visual. Get all combos function makes groups reversed. So sequential distribution became int desc. order
            foreach (var sortedCardListGroup in sortedCardListGroups)
            {
                sortedCardListGroup.Reverse();
            }

            sortedCardListGroups.Reverse();
        }

        /// <summary>
        /// Checking uniqueness in all of the cardGroups.  cardGroup is List<List<Card>>
        /// </summary>
        /// <param name="cardGroups"></param>
        /// <returns></returns>
        public List<List<List<Card>>> GetOneDeckCardGroups(List<List<List<Card>>> cardGroups)
        {
            List<List<List<Card>>> oneDeckCardGroups = new List<List<List<Card>>>();

            foreach (List<List<Card>> cardGroup in cardGroups)
            {
                if (DeckHelper.IsOneDeckCardGroup(cardGroup))
                {
                    oneDeckCardGroups.Add(cardGroup);
                }
            }

            return oneDeckCardGroups;
        }
    }
}