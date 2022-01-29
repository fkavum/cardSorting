using System;
using System.Collections;
using System.Collections.Generic;
using CardSorting.GamePlay;
using CardSorting.UI.Gameplay;
using DG.Tweening;
using UnityEngine;

public class TableEntity : MonoBehaviour
{
   public DeckEntity deckEntity;
   public CardEntityHolder cardEntityHolder;
   
   public void Start()
   {
      Debug.Log("Initializing Deck");
      deckEntity.Initialize();
      deckEntity.Shuffle();
      
      
      List<CardEntity> cards = deckEntity.TakeCards(11);
      cardEntityHolder.Initialize(cards);
      
   }

  
   
}
