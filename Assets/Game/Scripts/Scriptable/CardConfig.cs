using System;
using System.Collections;
using System.Collections.Generic;
using CardSorting.GamePlay;
using UnityEditor;
using UnityEngine;

namespace CardSorting.Scriptable
{
    [CreateAssetMenu(fileName = "NewCardConfig", menuName = "Custom/CardConfig")]
    public class CardConfig : ScriptableObject
    {
        public int cardNumber;
        public Card.CardTypeEnum cardType;
        public Sprite cardSprite;
        public int deckNumber;

        private void OnValidate()
        {
            deckNumber = cardNumber + (13 * ((int) cardType -1));
        }
    }
}