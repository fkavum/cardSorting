using System.Collections.Generic;

namespace CardSorting.GamePlay
{
    public class Table
    {
        private List<Card> _cards;
        
        public Table(int tableCardCount)
        {
            _cards = new Deck().Shuffle().TakeCards(tableCardCount);
        }
        public void ChangeCards(List<Card> newCards)
        {
            _cards = newCards;
        }

        public void SortSequential()
        {
            
        }

        public void SortSameNumber()
        {
            
        }

        public void SortSmart()
        {
            
        }
    }
}