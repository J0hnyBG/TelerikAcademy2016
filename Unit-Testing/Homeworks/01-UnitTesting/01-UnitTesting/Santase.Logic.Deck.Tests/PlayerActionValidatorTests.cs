namespace Santase.Logic.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    using Santase.Logic.Cards;
    using Santase.Logic.Players;
    using Santase.Logic.RoundStates;
	//TODO:
	[TestFixture]
    public static class PlayerActionValidatorTests
    {
	    [Test]
	    public static void PAV_PossibleCards(PlayerTurnContext context,
										ICollection<Card> playerCards)
	    {
	        
	    }

        [Test]
        public static void PAV_IsMoveValid(PlayerTurnContext context,
                                ICollection<Card> playerCards)
        {

        }

	    private static readonly ICollection<Card> PlayerCards;

	    static PlayerActionValidatorTests()
	    {
	        var roundState = new FinalRoundState(new StateManager());
            PlayerActionValidatorTests.PlayerCards = new List<Card>();

            var card = new Card(CardSuit.Club, CardType.Ace);
            var n = new PlayerTurnContext(
                        new FinalRoundState(
                                        new StateManager()
                                        ),
                                 card, 5, 5, 5);
        }
    }
}
