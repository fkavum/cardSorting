using System.Collections;
using System.Collections.Generic;
using CardSorting.GamePlay;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCardConfig",menuName = "Custom/CardConfig")]
public class CardConfig : ScriptableObject
{
    public int cardNumber;
    public Card.CardTypeEnum cardType;
    public Sprite cardSprite;
}
