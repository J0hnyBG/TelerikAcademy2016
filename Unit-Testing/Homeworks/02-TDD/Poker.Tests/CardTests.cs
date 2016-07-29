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
        public void Card_ToString_ShouldReturnFormattedString(CardFace face, CardSuit suit, string expected)
        {
            var cardString = new Card(face, suit).ToString();
            
            Assert.AreEqual(expected, cardString);
        }
    }
}
