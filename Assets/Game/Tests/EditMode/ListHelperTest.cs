using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using CardSorting.GamePlay;
using CardSorting.Helpers;


public class ListHelperTest
{
    /// <summary>
    /// Tests ListHelper.GetAllCombos function. 
    /// </summary>
    [Test]
    public void ListCombinationTest()
    {
        List<List<Card>> result = DeckHelper.GetAllCombos(new List<Card>()
        {
            new Card(1),
            new Card(2),
            new Card(3),
            new Card(4),
            new Card(5),
        },3);
        
        Assert.AreEqual(true, DeckHelper.IsUnsortedCardListInTheCardGroup(new List<Card>()
        {
            new Card(2),
            new Card(5),
            new Card(3)
        }, result));
        
    }
}