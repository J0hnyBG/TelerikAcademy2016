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
        private const int FullSantaseDeckCount = 24;
        private static readonly IEnumerable<CardType> AllSantaseCardTypes = new List<CardType>
        {
            CardType.Nine,
            CardType.Ten,
            CardType.Jack,
            CardType.Queen,
            CardType.King,
            CardType.Ace
        };

        private static readonly IEnumerable<CardSuit> AllSantaseCardSuits = new List<CardSuit>
        {
            CardSuit.Club,
            CardSuit.Diamond,
            CardSuit.Heart,
            CardSuit.Spade
        };

       
        [Test]
        public void Constructor_ShouldBeFullDeckOfDistinctCards()
        {
            var result = true;
            var deck = new Deck();
            
            var fullDeck = new List<Tuple<CardType, CardSuit>>(FullSantaseDeckCount);

            //Check if deck is full when initialized
            if (deck.CardsLeft != FullSantaseDeckCount )
            {
                result = false;
            }
            else
            {
                //Add all distinct cards in a fake deck
                fullDeck.AddRange(from cardType in DeckTests.AllSantaseCardTypes
                                  from suit in DeckTests.AllSantaseCardSuits
                                  select new Tuple<CardType, CardSuit>(cardType, suit));
                for (var i = 0; i < FullSantaseDeckCount; i++)
                {
                    //Get the next card
                    var card = deck.GetNextCard();
                    //If fullDeck.Remove returns false 
                    //=> there are cards that repeat in the tested deck & test fails
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
        public void CardsLeft_ShouldDecrementByPassedValue(int missingCards)
        {
            var deck = new Deck();
            var expectedCount = FullSantaseDeckCount - missingCards;

            //Remove cards from deck equal to missingCards
            for (var i = 0; i < missingCards; i++)
            {
                deck.GetNextCard();
            }
            Assert.AreEqual(expectedCount, deck.CardsLeft);
        }

        [Test]
        public void GetNextCard_WhenNoCardsInDeck_ShouldThrowInternalGameExceptionWitchCorrectmessage()
        {
            var deck = new Deck();

            //Remove cards from deck until no cards are left
            for (var i = 0; i < FullSantaseDeckCount; i++)
            {
                deck.GetNextCard();
            }
            //Assert if correct exception is thrown and store it in a var
            var ex = Assert.Throws(typeof(InternalGameException), () => deck.GetNextCard());
            //Assert if exception message contains expected message
            StringAssert.Contains("Deck is empty", ex.Message);
        }

        [Test, TestCaseSource(nameof(DeckTests.ChangeTrumpCardTestCases))]
        public void ChangeTrumpCard_ShouldEqualPassedValue(Card c)
        {
            var deck = new Deck();

            deck.ChangeTrumpCard(c);
            //Check if trump card suit and type are equal to expected
            var result = deck.TrumpCard.Suit == c.Suit
                        && deck.TrumpCard.Type == c.Type;

            Assert.IsTrue(result);
        }

        private static readonly IList<Card> ChangeTrumpCardTestCases =
            new List<Card>
            {
                new Card(CardSuit.Spade, CardType.Ace),
                new Card(CardSuit.Diamond, CardType.Queen),
                new Card(CardSuit.Heart, CardType.Nine),
                new Card(CardSuit.Club, CardType.Ten),
            };
    }
}