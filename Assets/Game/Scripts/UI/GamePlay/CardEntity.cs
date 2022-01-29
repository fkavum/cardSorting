using System;
using System.Collections;
using System.Collections.Generic;
using CardSorting.GamePlay;
using CardSorting.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace CardSorting.UI.Gameplay
{
    public class CardEntity : MonoBehaviour
    {
        public GameObject backSide;
        public GameObject frontSide;
        public Image frontImage;
        public Image backImage;

        
        [HideInInspector]public CardEntityHolder holder;
        [HideInInspector]public CardConfig cardConfig;
        public Card card;
    }
}