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
            var player1 = new Player {Name = "Bob", Hand = "2H 3D 5S 9C KD"};
            var player2 = new Player {Name = "Harry", Hand = "2C 3H 4S 8C AH"};

            var player2Hand = new PlayerHand(player2);
            var expectedOutput = $"Player {player2.Name} wins with a "
                                 + $"{player2Hand.Best.Type.ToString()}"
                                 + $" score of {player2Hand.Best.Score}";

            var response = _pokerGame.PlayCards(player1, player2);

            response.Should().Be(expectedOutput);
        }

        [Fact]
        public void ReturnsTheNameOfThePlayerWhoWonAPair()
        {
            var player1 = new Player {Name = "Alice", Hand = "2H 3D 5S KC KD"};
            var player2 = new Player {Name = "Frank", Hand = "2C 3H 8S 8C AH"};

            var player1Hand = new PlayerHand(player1);
            var expectedOutput = $"Player {player1.Name} wins with a "
                                 + $"{player1Hand.Best.Type.ToString()}"
                                 + $" score of {player1Hand.Best.Score}";

            var response = _pokerGame.PlayCards(player1, player2);

            response.Should().Be(expectedOutput);
        }
    }
}