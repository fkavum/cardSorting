using UnityEngine.XR;

namespace CardSorting.GamePlay
{
    public class Card
    {
        private readonly int _cardNumber;
        private readonly CardType _cardType;
        private readonly int _deckCardNumber;

        public Card(int cardNumber, CardType cardType)
        {
            _cardNumber = cardNumber;
            _cardType = cardType;
            _deckCardNumber = cardNumber * (int) cardType;
        }

        public enum CardType
        {
            Clubs = 1,
            Diamonds = 2,
            Hearts = 3,
            Spades = 4,
        }
    }
}