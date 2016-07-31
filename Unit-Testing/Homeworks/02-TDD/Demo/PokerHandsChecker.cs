using System;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }
            //Group by suit and face
            var g = hand.Cards.GroupBy(i => i.ToString());

            //Return false if any cards repeat
            return g.All(card => card.Count() == 1);
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!IsValidHand(hand)) return false;

            //Order cards by value
            var cards = hand.Cards.OrderBy(x => x.Face);
            ICard currentCard = null;

            foreach (var card in cards)
            {
                if (currentCard == null)
                {
                    currentCard = card;
                    continue;
                }
                //Check if cards are the same suit and in order
                if (card.Suit != currentCard.Suit
                   || (int)card.Face != (int)currentCard.Face + 1)
                {
                    return false;
                }
                currentCard = card;
            }
            return true;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if ( !IsValidHand(hand) ) return false;

            var groups = hand.Cards.GroupBy(x => x.Face);

            return groups.Any(g => g.Count() == 4);
        }

        public bool IsFullHouse(IHand hand)
        {
            if ( !IsValidHand(hand) ) return false;

            var groups = hand.Cards.GroupBy(x => x.Face).ToList();
            //If the hand is valid and we have two groups of 3 and 2 matches
            //=> there is a pair and a three of a kind in the hand
            var firstGroupCount = groups[0].Count();
            var secondGroupCount = groups[1].Count();

            return (firstGroupCount == 3 && secondGroupCount == 2)
                || (secondGroupCount == 3 && firstGroupCount == 2);
        }

        public bool IsFlush(IHand hand)
        {
            if ( !IsValidHand(hand) ) return false;

            var firstCard = hand.Cards.First();

            return hand.Cards
                .All(card => card.Suit == firstCard.Suit)
                && !IsStraightFlush(hand);
        }

        public bool IsStraight(IHand hand)
        {
            if ( !IsValidHand(hand) ) return false;

            //Order cards by value
            var cards = hand.Cards.OrderBy(x => x.Face);
            ICard currentCard = null;

            foreach ( var card in cards )
            {
                if ( currentCard == null )
                {
                    currentCard = card;
                    continue;
                }
                //Check if cards are in order
                if ( (int)card.Face != (int)currentCard.Face + 1 )
                {
                    return false;
                }
                currentCard = card;
            }
            //If its not a straight flush => its a straight
            return !IsStraightFlush(hand);
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if ( !IsValidHand(hand) || IsFourOfAKind(hand)) return false;

            var groups = hand.Cards.GroupBy(x => x.Face);
            //Check for a trio of cards
            return groups.Any(g => g.Count() == 3);
        }

        public bool IsTwoPair(IHand hand)
        {
            if ( !IsValidHand(hand) ) return false;
            var groups = hand.Cards.GroupBy(x => x.Face);
            //Check for two groups of pairs
            return groups.Count(g => g.Count() == 2) == 2;
        }

        public bool IsOnePair(IHand hand)
        {
            if ( !IsValidHand(hand)) return false;
            var groups = hand.Cards.GroupBy(x => x.Face);
            var cardGroups = groups as IGrouping<CardFace, ICard>[] ?? groups.ToArray();
            //Check if we have a pair and three distinct cards
            return cardGroups.Count(g => g.Count() == 2) == 1
                && cardGroups.Count(g => g.Count() == 1) == 3;

        }

        public bool IsHighCard(IHand hand)
        {
            if ( !IsValidHand(hand) ) return false;
            var groups = hand.Cards.GroupBy(x => x.Face);
            //Check if we have five distinct cards and they are not 
            // a straight, a flush, or a straight flush
            return groups
                    .Count(g => g.Count() == 1) == 5 
                    && !IsFlush(hand) 
                    && !IsStraight(hand) 
                    && !IsStraightFlush(hand);
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}