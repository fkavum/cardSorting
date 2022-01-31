using System.Collections.Generic;
using NUnit.Framework;
using CardSorting.GamePlay;
using CardSorting.GamePlay.Sorting;

public class SameNumberSorterTest
{
    /// <summary>
    /// Test of 777 sorting algorithm.
    /// </summary>
    [Test]
    public void CheckSorting()
    {
        SameNumberSorter sameNumberSorter = new SameNumberSorter(new List<Card>()
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

        Assert.AreEqual(true,sameNumberSorter.IsCardInTheUnsortedSortedGroup(new Card(2,Card.CardTypeEnum.Spades)));
        Assert.AreEqual(true,sameNumberSorter.IsCardInTheUnsortedSortedGroup(new Card(3,Card.CardTypeEnum.Diamonds)));
        Assert.AreEqual(true,sameNumberSorter.IsCardInTheUnsortedSortedGroup(new Card(5,Card.CardTypeEnum.Diamonds)));
        Assert.AreEqual(true,sameNumberSorter.IsCardInTheUnsortedSortedGroup(new Card(3,Card.CardTypeEnum.Spades)));
        Assert.AreEqual(false,sameNumberSorter.IsCardInTheUnsortedSortedGroup(new Card(10,Card.CardTypeEnum.Spades)));
        Assert.AreEqual(false,sameNumberSorter.IsCardInTheUnsortedSortedGroup(new Card(9,Card.CardTypeEnum.Diamonds)));
        
        
        Assert.AreEqual(true,sameNumberSorter.IsUnsortedCardListInTheSortedGroup(new List<Card>()
        {
            new Card(1,Card.CardTypeEnum.Hearts),
            new Card(1,Card.CardTypeEnum.Spades),
            new Card(1,Card.CardTypeEnum.Diamonds),
        }));
        Assert.AreEqual(true,sameNumberSorter.IsUnsortedCardListInTheSortedGroup(new List<Card>()
        {
            new Card(4,Card.CardTypeEnum.Hearts),
            new Card(4,Card.CardTypeEnum.Spades),
            new Card(4,Card.CardTypeEnum.Diamonds),
            new Card(4,Card.CardTypeEnum.Clubs),
        }));
        
        Assert.AreEqual(false,sameNumberSorter.IsUnsortedCardListInTheSortedGroup(new List<Card>()
        {
            new Card(5,Card.CardTypeEnum.Hearts),
            new Card(5,Card.CardTypeEnum.Spades),
            new Card(5,Card.CardTypeEnum.Diamonds),
            new Card(5,Card.CardTypeEnum.Clubs),
        }));
   
    }
}
