namespace Santase.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using Santase.Logic;
    using Santase.Logic.Cards;
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class DeckTests
    {
        private static readonly IEnumerable<CardType> AllCardTypes = new List<CardType>
        {
            CardType.Nine,
            CardType.Ten,
            CardType.Jack,
            CardType.Queen,
            CardType.King,
            CardType.Ace
        };

        private static readonly IEnumerable<CardSuit> AllCardSuits = new List<CardSuit>
        {
            CardSuit.Club,
            CardSuit.Diamond,
            CardSuit.Heart,
            CardSuit.Spade
        };

       
        [Test]
        public void Deck_Ctor_ShouldBeFullDeckOfDistinctCards()
        {
            var result = true;
            var deck = new Deck();
            var fullDeckCount = 24;
            var fullDeck = new List<Tuple<CardType, CardSuit>>(fullDeckCount);

            if (deck.CardsLeft != fullDeckCount)
            {
                result = false;
            }
            else
            {
                fullDeck.AddRange(from cardType in DeckTests.AllCardTypes
                                  from suit in DeckTests.AllCardSuits
                                  select new Tuple<CardType, CardSuit>(cardType, suit));
                for (int i = 0; i < fullDeckCount; i++)
                {
                    var card = deck.GetNextCard();
                    if ( !fullDeck.Remove(new Tuple<CardType, CardSuit>(card.Type, card.Suit)) )
                    {
                        result = false;
                        break;
                    }
                }
            }

            Assert.IsTrue(result);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void Deck_CardsLeft_ShouldDecrementByOne(int missingCards)
        {
            var result = true;
            var deck = new Deck();
            var expectedCount = deck.CardsLeft - missingCards;

            for (int i = 0; i < missingCards; i++)
            {
                deck.GetNextCard();
            }
            Assert.AreEqual(expectedCount, deck.CardsLeft);
        }

        [Test]
        public void Deck_DrawingCardWhenNoCardsInDeck_ShouldThrow()
        {
            var deck = new Deck();

            var upper = deck.CardsLeft;
            for (int i = 0; i < upper; i++)
            {
                deck.GetNextCard();
            }

            Assert.Throws(typeof(InternalGameException), () => deck.GetNextCard());
        }

        [Test, TestCaseSource(nameof(DeckTests.TestCards))]
        public void Deck_ChangeTrumpCard_ShouldEqualParameter(Card c)
        {
            var deck = new Deck();

            deck.ChangeTrumpCard(c);

            var result = deck.TrumpCard.Suit == c.Suit
                        && deck.TrumpCard.Type == c.Type;
            Assert.IsTrue(result);
        }

        private static readonly IList<Card> TestCards =
            new List<Card>
            {
                new Card(CardSuit.Spade, CardType.Ace),
                new Card(CardSuit.Diamond, CardType.Queen),
                new Card(CardSuit.Heart, CardType.Nine),
                new Card(CardSuit.Club, CardType.Ten),
            };
    }
}