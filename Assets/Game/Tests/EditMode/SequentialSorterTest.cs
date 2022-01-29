using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using CardSorting.GamePlay;
using CardSorting.GamePlay.Sorting;

public class SequentialSorterTest
{
    [Test]
    public void CheckSorting()
    {
        SequentialSorter sequentialSorter = new SequentialSorter(new List<Card>()
        {
            new Card(1,Card.CardTypeEnum.Hearts),
            new Card(2,Card.CardTypeEnum.Spades),
            new Card(5,Card.CardTypeEnum.Diamonds),
            new Card(4,Card.CardTypeEnum.Hearts),
            new Card(1,Card.CardTypeEnum.Spades),
            new Card(3,Card.CardTypeEnum.Diamonds),
            new Card(4,Card.CardTypeEnum.Clubs),
            new Card(4,Card.CardTypeEnum.Spades),
            new Card(1,Card.CardTypeEnum.Diamonds),
            new Card(3,Card.CardTypeEnum.Spades),
            new Card(4,Card.CardTypeEnum.Diamonds),
        });

        Assert.AreEqual(true,sequentialSorter.IsCardInTheUnsortedSortedGroup(new Card(1,Card.CardTypeEnum.Diamonds)));
        Assert.AreEqual(true,sequentialSorter.IsCardInTheUnsortedSortedGroup(new Card(1,Card.CardTypeEnum.Hearts)));
        Assert.AreEqual(true,sequentialSorter.IsCardInTheUnsortedSortedGroup(new Card(4,Card.CardTypeEnum.Hearts)));
        Assert.AreEqual(true,sequentialSorter.IsCardInTheUnsortedSortedGroup(new Card(4,Card.CardTypeEnum.Clubs)));
        
        
        Assert.AreEqual(true,sequentialSorter.IsSortedCardListInTheSortedGroup(new List<Card>()
        {
            new Card(1),
            new Card(2),
            new Card(3),
            new Card(4),
        }));
        
        Assert.AreEqual(false,sequentialSorter.IsSortedCardListInTheSortedGroup(new List<Card>()
        {
            new Card(1),
            new Card(2),
            new Card(3),
        }));

        
        Assert.AreEqual(true,sequentialSorter.IsSortedCardListInTheSortedGroup(new List<Card>()
        {
            new Card(16),
            new Card(17),
            new Card(18),
        }));
    }
}
