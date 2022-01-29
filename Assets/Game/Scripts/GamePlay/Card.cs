using UnityEngine.XR;

namespace CardSorting.GamePlay
{
    public class Card
    {
        
        private readonly int _cardNumber;
        private readonly CardTypeEnum _cardType;
        private readonly int _deckCardNumber;

        /// <summary>
        /// Starts from 1(includes) to 13(includes)
        /// </summary>
        public int CardNumber => _cardNumber;
        public CardTypeEnum CardType => _cardType;
        
        /// <summary>
        /// Starts from 1(includes) to 52(includes)
        /// </summary>
        public int DeckCardNumber => _deckCardNumber;

        public Card(int cardNumber, CardTypeEnum cardType)
        {
            _cardNumber = cardNumber;
            _cardType = cardType;
            _deckCardNumber = cardNumber + (13 * ((int) cardType -1));
        }
        
        public Card(int deckCardNumber)
        {
            if(_cardNumber > 52) return;
            
            _deckCardNumber = deckCardNumber;
            _cardNumber = deckCardNumber % 13;
            _cardNumber = _cardNumber == 0 ? 13 : _cardNumber;
            
            _cardType = (CardTypeEnum)(((_deckCardNumber - _cardNumber) / 13) +1);
        }
        
        public static bool operator ==(Card lhs, Card rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles the case of null on right side.
            return rhs != null && lhs.DeckCardNumber == rhs.DeckCardNumber;
        }

        public static bool operator !=(Card lhs, Card rhs) => !(lhs == rhs);
 
        public enum CardTypeEnum
        {
            Spades = 1,
            Diamonds = 2,
            Hearts = 3,
            Clubs = 4,
        }
    }
}