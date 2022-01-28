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
        
        
        
    }
}