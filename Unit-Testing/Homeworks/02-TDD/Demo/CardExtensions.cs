namespace Poker
{
    using System;

    public static class CardExtensions
    {
        public static string ToFriendlyString(this CardSuit cardSuit)
        {
            switch ( cardSuit )
            {
                case CardSuit.Clubs:
                    return "\u2663"; // ♣
                case CardSuit.Diamonds:
                    return "\u2666"; // ♦
                case CardSuit.Hearts:
                    return "\u2665"; // ♥
                case CardSuit.Spades:
                    return "\u2660"; // ♠
                default:
                    throw new ArgumentException("cardSuit");
            }
        }

        public static string ToFriendlyString(this CardFace cardFace)
        {
            switch ( cardFace )
            {
                case CardFace.Two:
                    return "2";
                case CardFace.Three:
                    return "3";
                case CardFace.Four:
                    return "4";
                case CardFace.Five:
                    return "5";
                case CardFace.Six:
                    return "6";
                case CardFace.Seven:
                    return "7";
                case CardFace.Eight:
                    return "8";
                case CardFace.Nine:
                    return "9";
                case CardFace.Ten:
                    return "10";
                case CardFace.Jack:
                    return "J";
                case CardFace.Queen:
                    return "Q";
                case CardFace.King:
                    return "K";
                case CardFace.Ace:
                    return "A";
                default:
                    throw new ArgumentException("CardFace");
            }
        }
    }
}