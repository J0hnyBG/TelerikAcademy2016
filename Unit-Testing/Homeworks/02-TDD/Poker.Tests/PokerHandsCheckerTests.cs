namespace Poker.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class PokerHandsCheckerTests
    {
        private static PokerHandsChecker PokerHandsChecker;

        [OneTimeSetUp]
        public void Init()
        {
            PokerHandsCheckerTests.PokerHandsChecker = new PokerHandsChecker();
        }

        [TestCaseSource(nameof(IsValidHandTestCases))]
        public void IsValidHand_ShouldReturnExpectedValue(bool expected, IHand hand)
        {
            var result = PokerHandsChecker.IsValidHand(hand);

            Assert.AreEqual(expected, result);
        }

        private static List<object> IsValidHandTestCases = new List<object>()
            #region IsValidHandTestCases

        {
            new object[]
            {
                true, //Valid hand
                new Hand(new List<ICard>()
                {
                    new Card(CardFace.Five, CardSuit.Spades),
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.Ace, CardSuit.Spades),
                }),
            },
            new object[]
            {
                false, //Invalid hand - two equal cards
                new Hand(new List<ICard>()
                {
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                    new Card(CardFace.Queen, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                    new Card(CardFace.Ace, CardSuit.Spades),
                }),
            },
            new object[]
            {
                false, //Invalid hand - four equal cards
                new Hand(new List<ICard>()
                {
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                }),
            },
            new object[]
            {
                false, //Invalid hand - too few cards
                new Hand(new List<ICard>()
                {
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                    new Card(CardFace.Queen, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Diamonds),
                }),
            },
            new object[]
            {
                false, //Invalid hand - too many cards
                new Hand(new List<ICard>()
                {
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                    new Card(CardFace.Queen, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Hearts),
                    new Card(CardFace.Two, CardSuit.Diamonds),
                }),
            },
        };

        #endregion

        [TestCaseSource(nameof(IsFlushTestCases))]
        public void IsFlushHand_ShouldReturnExpectedValue(bool expected, IHand hand)
        {
            var result = PokerHandsChecker.IsFlush(hand);

            Assert.AreEqual(expected, result);
        }

        private static List<object> IsFlushTestCases = new List<object>()
        {
            #region IsFlushTestCases
            new object[]
            {
                true,
                new Hand(new List<ICard>()
                {
                    //Valid flush
                    new Card(CardFace.Five, CardSuit.Spades),
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Spades),
                    new Card(CardFace.Ace, CardSuit.Spades),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid flush - not all cards are the same suit
                    new Card(CardFace.Ace, CardSuit.Diamonds),
                    new Card(CardFace.Queen, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Clubs),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.Ace, CardSuit.Spades),
                }),
            },
        };

        #endregion

        [TestCaseSource(nameof(IsStraightFlushTestCases))]
        public void IsStraightFlushHand_ShouldReturnExpectedValue(bool expected,
            IHand hand)
        {
            var result = PokerHandsChecker.IsStraightFlush(hand);

            Assert.AreEqual(expected, result);
        }

        private static List<object> IsStraightFlushTestCases = new List<object>()
        {
            #region IsStraightFlushTestCases
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid straight flush - not the same suit
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.Three, CardSuit.Spades),
                    new Card(CardFace.Five, CardSuit.Diamonds),
                    new Card(CardFace.Four, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Spades),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid straight flush - cards are not concurrent
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.Three, CardSuit.Spades),
                    new Card(CardFace.Five, CardSuit.Spades),
                    new Card(CardFace.Four, CardSuit.Spades),
                    new Card(CardFace.Ten, CardSuit.Spades),
                }),
            },
            new object[]
            {
                true,
                new Hand(new List<ICard>()
                {
                    //Valid straight flush
                    new Card(CardFace.Six, CardSuit.Spades),
                    new Card(CardFace.Three, CardSuit.Spades),
                    new Card(CardFace.Five, CardSuit.Spades),
                    new Card(CardFace.Four, CardSuit.Spades),
                    new Card(CardFace.Two, CardSuit.Spades),
                }),
            }
        };

        #endregion

        [TestCaseSource(nameof(IsFourOfAKindTestCases))]
        public void IsFourOfAKind_ShouldReturnExpectedValue(bool expected, IHand hand)
        {
            var result = PokerHandsChecker.IsFourOfAKind(hand);

            Assert.AreEqual(expected, result);
        }

        private static List<object> IsFourOfAKindTestCases = new List<object>()
            #region IsFourOfAKindTestCases

        {
            new object[]
            {
                true,
                new Hand(new List<ICard>()
                {
                    //Valid four of a kind
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.Two, CardSuit.Diamonds),
                    new Card(CardFace.Five, CardSuit.Diamonds),
                    new Card(CardFace.Two, CardSuit.Hearts),
                    new Card(CardFace.Two, CardSuit.Clubs),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid four of a kind - invalid hand
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.Two, CardSuit.Diamonds),
                    new Card(CardFace.Two, CardSuit.Diamonds),
                    new Card(CardFace.Two, CardSuit.Hearts),
                    new Card(CardFace.Two, CardSuit.Clubs),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid four of a kind - only three matching cards
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.Two, CardSuit.Diamonds),
                    new Card(CardFace.Five, CardSuit.Diamonds),
                    new Card(CardFace.Two, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Spades),
                }),
            }
        };

        #endregion

        [TestCaseSource(nameof(IsStraightTestCases))]
        public void IsStraight_ShouldReturnExpectedValue(bool expected, IHand hand)
        {
            var result = PokerHandsChecker.IsStraight(hand);

            Assert.AreEqual(expected, result);
        }

        private static List<object> IsStraightTestCases = new List<object>()
            #region IsStraightTestCases

        {
            new object[]
            {
                true,
                new Hand(new List<ICard>()
                {
                    //Valid straight
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.Three, CardSuit.Diamonds),
                    new Card(CardFace.Five, CardSuit.Diamonds),
                    new Card(CardFace.Four, CardSuit.Hearts),
                    new Card(CardFace.Six, CardSuit.Clubs),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid straight - its a straight flush
                    new Card(CardFace.Two, CardSuit.Hearts),
                    new Card(CardFace.Three, CardSuit.Hearts),
                    new Card(CardFace.Five, CardSuit.Hearts),
                    new Card(CardFace.Four, CardSuit.Hearts),
                    new Card(CardFace.Six, CardSuit.Hearts),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid straight - cards are not concurrent
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Three, CardSuit.Hearts),
                    new Card(CardFace.Five, CardSuit.Hearts),
                    new Card(CardFace.Four, CardSuit.Diamonds),
                    new Card(CardFace.Six, CardSuit.Hearts),
                }),
            }
        };

        #endregion

        [TestCaseSource(nameof(IsThreeOfAKindTestCases))]
        public void IsThreeOfAKind_ShouldReturnExpectedValue(bool expected, IHand hand)
        {
            var result = PokerHandsChecker.IsThreeOfAKind(hand);

            Assert.AreEqual(expected, result);
        }

        private static List<object> IsThreeOfAKindTestCases = new List<object>()
            #region IsThreeOfAKindTestCases

        {
            new object[]
            {
                true,
                new Hand(new List<ICard>()
                {
                    //Valid three of a kind
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.Three, CardSuit.Clubs),
                    new Card(CardFace.Three, CardSuit.Diamonds),
                    new Card(CardFace.Three, CardSuit.Hearts),
                    new Card(CardFace.Six, CardSuit.Clubs),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid three of a kind - its a four of a kind
                    new Card(CardFace.Two, CardSuit.Hearts),
                    new Card(CardFace.Two, CardSuit.Clubs),
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.Two, CardSuit.Diamonds),
                    new Card(CardFace.Six, CardSuit.Hearts),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid three of a kind - only two pairs
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Five, CardSuit.Hearts),
                    new Card(CardFace.Four, CardSuit.Diamonds),
                    new Card(CardFace.Four, CardSuit.Hearts),
                }),
            }
        };

        #endregion

        [TestCaseSource(nameof(IsTwoPairTestCases))]
        public void IsTwoPair_ShouldReturnExpectedValue(bool expected, IHand hand)
        {
            var result = PokerHandsChecker.IsTwoPair(hand);

            Assert.AreEqual(expected, result);
        }

        private static List<object> IsTwoPairTestCases = new List<object>()
            #region IsTwoPairTestCases

        {
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid two pair - its a full house
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.Three, CardSuit.Clubs),
                    new Card(CardFace.Three, CardSuit.Diamonds),
                    new Card(CardFace.Three, CardSuit.Hearts),
                    new Card(CardFace.Two, CardSuit.Clubs),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid two pair - its a pair
                    new Card(CardFace.Two, CardSuit.Hearts),
                    new Card(CardFace.Two, CardSuit.Clubs),
                    new Card(CardFace.Queen, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.Six, CardSuit.Hearts),
                }),
            },
            new object[]
            {
                true,
                new Hand(new List<ICard>()
                {
                    //Valid two pair
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Five, CardSuit.Hearts),
                    new Card(CardFace.Four, CardSuit.Diamonds),
                    new Card(CardFace.Four, CardSuit.Hearts),
                }),
            }
        };

        #endregion

        [TestCaseSource(nameof(IsFullHouseTestCases))]
        public void IsFullHouse_ShouldReturnExpectedValue(bool expected, IHand hand)
        {
            var result = PokerHandsChecker.IsFullHouse(hand);

            Assert.AreEqual(expected, result);
        }

        private static List<object> IsFullHouseTestCases = new List<object>()
            #region IsFullHouseTestCases

        {
            new object[]
            {
                true,
                new Hand(new List<ICard>()
                {
                    //Valid full house
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.Three, CardSuit.Clubs),
                    new Card(CardFace.Three, CardSuit.Diamonds),
                    new Card(CardFace.Three, CardSuit.Hearts),
                    new Card(CardFace.Two, CardSuit.Clubs),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid full house - a pair
                    new Card(CardFace.Two, CardSuit.Hearts),
                    new Card(CardFace.Two, CardSuit.Clubs),
                    new Card(CardFace.Queen, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Diamonds),
                    new Card(CardFace.Six, CardSuit.Hearts),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid full house - a three of a kind
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Diamonds),
                    new Card(CardFace.Four, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Hearts),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid full house - a four of a kind
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Diamonds),
                    new Card(CardFace.Ten, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Hearts),
                }),
            }
        };

        #endregion

        [TestCaseSource(nameof(IsOnePairTestCases))]
        public void IsOnePair_ShouldReturnExpectedValue(bool expected, IHand hand)
        {
            var result = PokerHandsChecker.IsOnePair(hand);

            Assert.AreEqual(expected, result);
        }

        private static List<object> IsOnePairTestCases = new List<object>()
            #region IsOnePairTestCases

        {
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid pair - full house
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.Three, CardSuit.Clubs),
                    new Card(CardFace.Three, CardSuit.Diamonds),
                    new Card(CardFace.Three, CardSuit.Hearts),
                    new Card(CardFace.Two, CardSuit.Clubs),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid pair - two pairs
                    new Card(CardFace.Two, CardSuit.Hearts),
                    new Card(CardFace.Two, CardSuit.Clubs),
                    new Card(CardFace.Queen, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Diamonds),
                    new Card(CardFace.Six, CardSuit.Hearts),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid pair - a three of a kind
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Diamonds),
                    new Card(CardFace.Four, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Hearts),
                }),
            },
            new object[]
            {
                true,
                new Hand(new List<ICard>()
                {
                    //Valid pair
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Six, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Hearts),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid pair - high card
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Clubs),
                    new Card(CardFace.Six, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Hearts),
                }),
            }
        };

        #endregion

        [TestCaseSource(nameof(IsHighCardTestCases))]
        public void IsHighCard_ShouldReturnExpectedValue(bool expected, IHand hand)
        {
            var result = PokerHandsChecker.IsHighCard(hand);

            Assert.AreEqual(expected, result);
        }

        private static List<object> IsHighCardTestCases = new List<object>()
            #region IsHighCardTestCases

        {
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid high - full house
                    new Card(CardFace.Two, CardSuit.Spades),
                    new Card(CardFace.Three, CardSuit.Clubs),
                    new Card(CardFace.Three, CardSuit.Diamonds),
                    new Card(CardFace.Three, CardSuit.Hearts),
                    new Card(CardFace.Two, CardSuit.Clubs),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid high - two pairs
                    new Card(CardFace.Two, CardSuit.Hearts),
                    new Card(CardFace.Two, CardSuit.Clubs),
                    new Card(CardFace.Queen, CardSuit.Spades),
                    new Card(CardFace.Queen, CardSuit.Diamonds),
                    new Card(CardFace.Six, CardSuit.Hearts),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid high - a three of a kind
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Ten, CardSuit.Diamonds),
                    new Card(CardFace.Four, CardSuit.Diamonds),
                    new Card(CardFace.King, CardSuit.Hearts),
                }),
            },
            new object[]
            {
                true,
                new Hand(new List<ICard>()
                {
                    //Valid high
                    new Card(CardFace.Two, CardSuit.Hearts),
                    new Card(CardFace.Ten, CardSuit.Clubs),
                    new Card(CardFace.Six, CardSuit.Diamonds),
                    new Card(CardFace.Seven, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Hearts),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid high - straight
                    new Card(CardFace.Ten, CardSuit.Hearts),
                    new Card(CardFace.Ace, CardSuit.Clubs),
                    new Card(CardFace.Jack, CardSuit.Diamonds),
                    new Card(CardFace.Queen, CardSuit.Spades),
                    new Card(CardFace.King, CardSuit.Hearts),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid high - flush
                    new Card(CardFace.Two, CardSuit.Hearts),
                    new Card(CardFace.Four, CardSuit.Hearts),
                    new Card(CardFace.Jack, CardSuit.Hearts),
                    new Card(CardFace.Queen, CardSuit.Hearts),
                    new Card(CardFace.King, CardSuit.Hearts),
                }),
            },
            new object[]
            {
                false,
                new Hand(new List<ICard>()
                {
                    //Invalid high - straight flush
                    new Card(CardFace.Two, CardSuit.Hearts),
                    new Card(CardFace.Four, CardSuit.Hearts),
                    new Card(CardFace.Three, CardSuit.Hearts),
                    new Card(CardFace.Five, CardSuit.Hearts),
                    new Card(CardFace.Six, CardSuit.Hearts),
                }),
            }
        };

        #endregion
    }
}