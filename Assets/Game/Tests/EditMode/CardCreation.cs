using NUnit.Framework;
using CardSorting.GamePlay;
public class CardCreation
{
    [Test]
    public void DeckCardNumberToOthers()
    {
        Card card1 = new Card(5);
        Assert.AreEqual(5,card1.CardNumber);
        Assert.AreEqual(Card.CardTypeEnum.Spades,card1.CardType );

        Card card2 = new Card(17);
        Assert.AreEqual(4,card2.CardNumber );
        Assert.AreEqual( Card.CardTypeEnum.Diamonds,card2.CardType);
        
        Card card3 = new Card(48);
        Assert.AreEqual(9,card3.CardNumber);
        Assert.AreEqual(Card.CardTypeEnum.Clubs,card3.CardType);
        
        
        Card card4 = new Card(39);
        Assert.AreEqual( 13,card4.CardNumber);
        Assert.AreEqual(Card.CardTypeEnum.Hearts,card4.CardType );
        
        Card card5 = new Card(27);
        Assert.AreEqual(1,card5.CardNumber );
        Assert.AreEqual( Card.CardTypeEnum.Hearts,card5.CardType);
    }
}
