using System.Collections.Generic;
using NUnit.Framework;
using CardSorting.GamePlay;
using CardSorting.GamePlay.Sorting;

public class SmartSorterTest
{
    [Test]
    public void CheckSorting()
    {
        SmartSorter smartSorter = new SmartSorter(new List<Card>()
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

        Assert.AreEqual(true,smartSorter.IsCardInTheUnsortedSortedGroup(new Card(1,Card.CardTypeEnum.Diamonds)));
        Assert.AreEqual(true,smartSorter.IsCardInTheUnsortedSortedGroup(new Card(1,Card.CardTypeEnum.Hearts)));
        Assert.AreEqual(false,smartSorter.IsCardInTheUnsortedSortedGroup(new Card(9,Card.CardTypeEnum.Hearts)));
        Assert.AreEqual(false,smartSorter.IsCardInTheUnsortedSortedGroup(new Card(10,Card.CardTypeEnum.Diamonds)));
        
        Assert.AreEqual(true,smartSorter.IsUnsortedCardListInTheSortedGroup(new List<Card>()
        {
            new Card(1,Card.CardTypeEnum.Spades),
            new Card(2,Card.CardTypeEnum.Spades),
            new Card(3,Card.CardTypeEnum.Spades),
        }));
        
        Assert.AreEqual(true,smartSorter.IsUnsortedCardListInTheSortedGroup(new List<Card>()
        {
            new Card(4,Card.CardTypeEnum.Hearts),
            new Card(4,Card.CardTypeEnum.Spades),
            new Card(4,Card.CardTypeEnum.Clubs),
        }));
        
        Assert.AreEqual(false,smartSorter.IsUnsortedCardListInTheSortedGroup(new List<Card>()
        {
            new Card(4,Card.CardTypeEnum.Hearts),
            new Card(4,Card.CardTypeEnum.Spades),
            new Card(4,Card.CardTypeEnum.Clubs),
            new Card(3,Card.CardTypeEnum.Diamonds),
        }));

        
        Assert.AreEqual(true,smartSorter.IsUnsortedCardListInTheSortedGroup(new List<Card>()
        {
            new Card(3,Card.CardTypeEnum.Diamonds),
            new Card(4,Card.CardTypeEnum.Diamonds),
            new Card(5,Card.CardTypeEnum.Diamonds),
        }));
   
    }
}
