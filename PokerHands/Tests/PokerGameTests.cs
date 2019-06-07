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
            var player1 = new Player("Bob", "2H 3D 5S 9C KD");
            var player2 = new Player("Harry", "2C 3H 4S 8C AH");
            var expectedOutput = $"Player {player2.Name} wins with a "
                + $"{player2.Hand.Best.Type.ToString()}"
                + $" score of {player2.Hand.Best.Score}";

            var response = _pokerGame.PlayCards(player1, player2);

            response.Should().Be(expectedOutput);
        }

        [Fact]
        public void ReturnsTheNameOfThePlayerWhoWonAPair()
        {
            var player1 = new Player("Alice", "2H 3D 5S KC KD");
            var player2 = new Player("Frank", "2C 3H 8S 8C AH");
            var expectedOutput = $"Player {player1.Name} wins with a "
                 + $"{player1.Hand.Best.Type.ToString()}"
                 + $" score of {player1.Hand.Best.Score}";

            var response = _pokerGame.PlayCards(player1, player2);

            response.Should().Be(expectedOutput);
        }
    }
}
