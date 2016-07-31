namespace Poker.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CardTests
    {
        [TestCase(CardFace.Ace, CardSuit.Spades, "A♠")]
        [TestCase(CardFace.Nine, CardSuit.Diamonds, "9♦")]
        [TestCase(CardFace.Two, CardSuit.Hearts, "2♥")]
        [TestCase(CardFace.King, CardSuit.Clubs, "K♣")]
        [TestCase(CardFace.Three, CardSuit.Clubs, "3♣")]
        [TestCase(CardFace.Four, CardSuit.Clubs, "4♣")]
        [TestCase(CardFace.Five, CardSuit.Clubs, "5♣")]
        [TestCase(CardFace.Six, CardSuit.Clubs, "6♣")]
        [TestCase(CardFace.Seven, CardSuit.Clubs, "7♣")]
        [TestCase(CardFace.Eight, CardSuit.Clubs, "8♣")]
        [TestCase(CardFace.Nine, CardSuit.Clubs, "9♣")]
        [TestCase(CardFace.Ten, CardSuit.Clubs, "10♣")]
        [TestCase(CardFace.Jack, CardSuit.Clubs, "J♣")]
        [TestCase(CardFace.Queen, CardSuit.Clubs, "Q♣")]
        public void Card_ToString_ShouldReturnFormattedString(CardFace face, CardSuit suit, string expected)
        {
            var actual = new Card(face, suit).ToString();
            
            Assert.AreEqual(expected, actual);
        }
    }
}
