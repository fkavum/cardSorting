using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CardSorting.Helpers;
namespace CardSorting.GamePlay
{
    /// <summary>
    /// Initially, this deck class always have 52 cards with 4 card type. No more, no less...
    /// After the initialization, you can take card(s) from it.
    /// Its not a generic class, its just enough for the case. 
    /// </summary>
    public class Deck
    {
        private Card[] _cards;

        public Deck()
        {
            _cards = new Card[52];
            foreach (int cardTypeValue in Enum.GetValues(typeof(Card.CardType)))
            {
                for (int i = 1; i <= 13; i++)
                {
                    _cards[(i * cardTypeValue) - 1] = new Card(i, (Card.CardType) cardTypeValue);
                }
            }
        }

        public Deck Shuffle()
        {
            System.Random rng = new System.Random(UnityEngine.Random.Range(0, 999999));
            rng.Shuffle(_cards);
            return this;
        }
        
        public Deck Shuffle(int seed)
        {
            System.Random rng = new System.Random(seed);
            rng.Shuffle(_cards);
            return this;
        }

        public List<Card> TakeCards(int cardCount)
        {
            return _cards.Take(cardCount).ToList();
        }

    }
}