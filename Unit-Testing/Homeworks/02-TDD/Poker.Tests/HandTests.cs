namespace Poker.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class HandTests
    {
        [Test]
        public void Hand_ToString_ShouldReturnFormattedHand()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Hearts),
            });
            var expected = "A♦, Q♦, K♣, A♠, 4♥";

            var result = hand.ToString();

            Assert.AreEqual(expected, result);
        }
    }
}