using System.Collections.Generic;
using System.Linq;
using CardSorting.Helpers;

namespace CardSorting.GamePlay.Sorting
{
    public class SmartSorter:Sorter
    {
        public SmartSorter(List<Card> cards)
        {
            sortedCardListGroups = new List<List<Card>>();
            unsortedGroups = new List<Card>();

            SequentialSorter sequentialSorter = new SequentialSorter(cards);
            SameNumberSorter sameNumberSorter = new SameNumberSorter(cards);

            foreach (var seqCardList in sequentialSorter.sortedCardListGroups)
            {
                sortedCardListGroups.AddRange(DeckHelper.GetAllCombos(seqCardList,3));
            }

            foreach (var sameCardList in sameNumberSorter.sortedCardListGroups)
            {
                sortedCardListGroups.AddRange(DeckHelper.GetAllCombos(sameCardList,3));
            }

            List<List<List<Card>>> allCombos = DeckHelper.GetAllCombos(sortedCardListGroups);
            List<List<List<Card>>> cardGroups = GetOneDeckCardGroups(allCombos);

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

                List<Card> otherCards = DeckHelper.GetOtherCards(allCardsInTheCardGroup);
                int otherCardsPoint = DeckHelper.GetTotalCardPoint(otherCards);

                if (otherCardsPoint < lowestOtherCardsPoint)
                {
                    bestCombo = cardGroup;
                    bestUnsortedGroup = otherCards;
                }
            }
            sortedCardListGroups = bestCombo;
            unsortedGroups = bestUnsortedGroup;
        }
        
        public List<List<List<Card>>> GetOneDeckCardGroups(List<List<List<Card>>> cardGroups)
        {
            List<List<List<Card>>> oneDeckCardGroups = new List<List<List<Card>>>();

            foreach (List<List<Card>> cardGroup in cardGroups)
            {
                if(DeckHelper.IsOneDeckCardGroup(cardGroup))
                {
                    oneDeckCardGroups.Add(cardGroup);
                }
            }

            return oneDeckCardGroups;
        }
    }
}