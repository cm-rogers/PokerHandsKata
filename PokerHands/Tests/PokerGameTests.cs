using FluentAssertions;
using PokerHands.Models;
using Xunit;

namespace PokerHands.Tests
{
    public class PokerGameTests
    {
        private readonly PokerGame _pokerGame;

        public PokerGameTests()
        {
            _pokerGame = new PokerGame();
        }

        [Fact]
        public void ReturnsTheNameOfThePlayerWhoWonHighCard()
        {
            var player1 = new Player("player1", "2H 3D 5S 9C KD");
            var player2 = new Player("player2", "2C 3H 4S 8C AH");

            var response = _pokerGame.PlayCards(player1, player2);

            response.Should().Be(player2.Name);
        }
    }
}
