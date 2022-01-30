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
   }

   private void ResetTable()
   {
      deckEntity.ReturnCards(cardEntityHolder.cardEntities);
      cardEntityHolder.cardEntities = new List<CardEntity>();
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Alpha1))
      {
         List<CardEntity> cards = deckEntity.TakeCards(11);
         cardEntityHolder.Initialize(cards);
      }
      
      if (Input.GetKeyDown(KeyCode.Alpha2))
      {
         cardEntityHolder.SortSequentially();
      }
      
      if (Input.GetKeyDown(KeyCode.Alpha3))
      {
         cardEntityHolder.SortSameNumber();
      }
      
      if (Input.GetKeyDown(KeyCode.Alpha4))
      {
         cardEntityHolder.SortSmart();
      }
      
      if (Input.GetKeyDown(KeyCode.R))
      {
         ResetTable();
      }
      
      
   }
}