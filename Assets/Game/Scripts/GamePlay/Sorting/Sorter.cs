using System.Collections.Generic;

namespace CardSorting.GamePlay.Sorting
{
    public interface Sorter
    {
        public List<Card> Sort(List<Card> cards);
    }
}