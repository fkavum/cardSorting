using System.Collections.Generic;
using UnityEngine;

namespace CardSorting.Scriptable
{
    [CreateAssetMenu(fileName = "NewDeckConfig",menuName = "Custom/DeckConfig")]
    public class DeckConfig : ScriptableObject
    {
        public List<CardConfig> cardConfigs;
        public Sprite[] cardBackImages;
        
    }
}