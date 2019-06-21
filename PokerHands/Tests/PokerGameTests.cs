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
            var expectedOutput = GenerateOutputForExpectedWinner(player2.Name, Hand.Types.HighCard, 14);

            var response = _pokerGame.PlayCards(player1, player2);

            response.Should().Be(expectedOutput);
        }

        [Fact]
        public void ReturnsTheNameOfThePlayerWhoWonAPair()
        {
            var player1 = new Player {Name = "Alice", Hand = "2H 3D 5S KC KD"};
            var player2 = new Player {Name = "Frank", Hand = "2C 3H 8S 8C AH"};
            var expectedOutput = GenerateOutputForExpectedWinner(player1.Name, Hand.Types.Pair, 26);

            var response = _pokerGame.PlayCards(player1, player2);

            response.Should().Be(expectedOutput);
        }

        [Fact]
        public void ReturnsTheNameOfThePlayerWhoWonTwoPair()
        {
            var player1 = new Player {Name = "Alice", Hand = "2H 2D 5S 5C KD"};
            var player2 = new Player {Name = "Frank", Hand = "2C 3H 8S 8C AH"};
            var expectedOutput = GenerateOutputForExpectedWinner(player1.Name, Hand.Types.TwoPair, 14);

            var response = _pokerGame.PlayCards(player1, player2);

            response.Should().Be(expectedOutput);
        }

        [Fact]
        public void PairBeatsHighCard()
        {
            var player1 = new Player {Name = "Alice", Hand = "2H 3D 5S QC KD"};
            var player2 = new Player {Name = "Frank", Hand = "2C 3H 5S AC AH"};
            var expectedOutput = GenerateOutputForExpectedWinner(player2.Name, Hand.Types.Pair, 28);

            var response = _pokerGame.PlayCards(player1, player2);

            response.Should().Be(expectedOutput);
        }

        private static string GenerateOutputForExpectedWinner(
            string playerName,
            Hand.Types handType,
            int handScore
        )
        {
            return $"Player {playerName} wins with a "
                   + $"{handType.ToString()}"
                   + $" score of {handScore}";
        }
    }
}