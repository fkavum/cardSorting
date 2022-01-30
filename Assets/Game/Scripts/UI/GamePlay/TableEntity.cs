using System.Collections.Generic;
using CardSorting.UI.Gameplay;
using UnityEngine;

public class TableEntity : MonoBehaviour
{
   public DeckEntity deckEntity;
   public CardEntityHolder cardEntityHolder;
   
   public void Start()
   {
      deckEntity.Initialize();
      deckEntity.Shuffle();
      ShuffleCards();
   }

   public void ResetTable()
   {
      deckEntity.ReturnCards(cardEntityHolder.cardEntities);
      cardEntityHolder.cardEntities = new List<CardEntity>();
   }

   public void ShuffleCards()
   {
      ResetTable();
      List<CardEntity> cards = deckEntity.TakeCards(11);
      cardEntityHolder.Initialize(cards);
   }

   public void ChangeTheme()
   {
      deckEntity.ChangeTheme();
   }

   public void SortSequentially()
   {
      cardEntityHolder.SortSequentially();
   }
   public void SortSameNumber()
   {
      cardEntityHolder.SortSameNumber();
   }
   public void SortSmart()
   {
      cardEntityHolder.SortSmart();
   }

   public void ShufflePreset1()
   {
      ResetTable();
      List<CardEntity> cards = deckEntity.TakePrecalculatedCards(new List<int>()
      {
         27,
         2,
         18,
         30,
         1,
         16,
         43,
         4,
         14,
         3,
         17
      });
      cardEntityHolder.Initialize(cards);
   }

   public void ShufflePreset2()
   {
      ResetTable();
      List<CardEntity> cards = deckEntity.TakePrecalculatedCards(new List<int>()
      {
         45,
         32,
         44,
         17,
         5,
         6,
         18,
         30,
         31,
         4,
         16,
      });
      cardEntityHolder.Initialize(cards);
   }
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Alpha1))
      {
         ShuffleCards();
      }
      
      if (Input.GetKeyDown(KeyCode.Alpha2))
      {
         SortSequentially();
      }
      
      if (Input.GetKeyDown(KeyCode.Alpha3))
      {
         SortSameNumber();
      }
      
      if (Input.GetKeyDown(KeyCode.Alpha4))
      {
         SortSmart();
      }

      if (Input.GetKeyDown(KeyCode.Alpha5))
      {
         ShufflePreset1();
      }
      if (Input.GetKeyDown(KeyCode.Alpha6))
      {
        ShufflePreset2();
      }
      
      if (Input.GetKeyDown(KeyCode.R))
      {
         ResetTable();
      }
   }
}
