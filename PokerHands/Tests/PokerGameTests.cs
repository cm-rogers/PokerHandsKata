using FluentAssertions;
using PokerHands.Models;
using Xunit;

namespace PokerHands.Tests
{
    public class PokerGameTests
    {
        private readonly PokerGame _pokerGame;

        public const string P1Name = "Alice";
        public const string P2Name = "Frank";

        public PokerGameTests()
        {
            _pokerGame = new PokerGame();
        }

        [Theory]
        [InlineData("2H 3D 5S 9C KD", "2C JH 4S 8C QH", P1Name, 13)]
        [InlineData("2H 3D 5S 9C KD", "2C 3H 4S 8C AH", P2Name, 14)]
        public void ReturnsTheNameOfThePlayerWhoWonHighCard(
            string p1Hand,
            string p2Hand,
            string expectedWinnerName,
            int expectedWinnerScore
        )
        {
            var player1 = new Player {Name = P1Name, Hand = p1Hand};
            var player2 = new Player {Name = P2Name, Hand = p2Hand};
            var expectedOutput = GenerateOutputForExpectedWinner(
                expectedWinnerName,
                Hand.Types.HighCard,
                expectedWinnerScore);

            var response = _pokerGame.PlayCards(player1, player2);

            response.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("2H 3D 5S 9C 5D", "2C JH 2S 8C QH", P1Name, 10)]
        [InlineData("2H KD 5S 9C KD", "2C AH 4S 8C AH", P2Name, 28)]
        public void ReturnsTheNameOfThePlayerWhoWonAPair(
            string p1Hand,
            string p2Hand,
            string expectedWinnerName,
            int expectedWinnerScore
        )
        {
            var player1 = new Player { Name = P1Name, Hand = p1Hand };
            var player2 = new Player { Name = P2Name, Hand = p2Hand };
            var expectedOutput = GenerateOutputForExpectedWinner(
                expectedWinnerName,
                Hand.Types.Pair,
                expectedWinnerScore);

            var response = _pokerGame.PlayCards(player1, player2);

            response.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("3H 9D 5S 9C 3D", "2C 5H 2S 9C 5S", P1Name, 24)]
        [InlineData("2H 3D 4S 4C KD", "2C AH KS KC AH", P2Name, 54)]
        public void ReturnsTheNameOfThePlayerWhoWonTwoPair(
            string p1Hand,
            string p2Hand,
            string expectedWinnerName,
            int expectedWinnerScore
        )
        {
            var player1 = new Player { Name = P1Name, Hand = p1Hand };
            var player2 = new Player { Name = P2Name, Hand = p2Hand };
            var expectedOutput = GenerateOutputForExpectedWinner(
                expectedWinnerName,
                Hand.Types.TwoPair,
                expectedWinnerScore);

            var response = _pokerGame.PlayCards(player1, player2);

            response.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("KH AD KS AC KD", "2C 2H 3S 2C AH", P1Name, 39)]
        [InlineData("2C 3H 3S 2S AH", "KH AD AS AC KD", P2Name, 42)]
        public void ReturnsTheNameOfThePlayerWhoWonThreeOfAKind(
            string p1Hand,
            string p2Hand,
            string expectedWinnerName,
            int expectedWinnerScore
        )
        {
            var player1 = new Player {Name = P1Name, Hand = p1Hand};
            var player2 = new Player {Name = P2Name, Hand = p2Hand};
            var expectedOutput = GenerateOutputForExpectedWinner(
                expectedWinnerName,
                Hand.Types.ThreeOfAKind,
                expectedWinnerScore);

            var response = _pokerGame.PlayCards(player1, player2);

            response.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("KH AD KS KC KD", "2C 2H 3S 2C AH", P1Name, 52)]
        [InlineData("2C 3H 3S 2S AH", "AH AD AS AC KD", P2Name, 56)]
        public void ReturnsTheNameOfThePlayerWhoWonFourOfAKind(
            string p1Hand,
            string p2Hand,
            string expectedWinnerName,
            int expectedWinnerScore
        )
        {
            var player1 = new Player { Name = P1Name, Hand = p1Hand };
            var player2 = new Player { Name = P2Name, Hand = p2Hand };
            var expectedOutput = GenerateOutputForExpectedWinner(
                expectedWinnerName,
                Hand.Types.FourOfAKind,
                expectedWinnerScore);

            var response = _pokerGame.PlayCards(player1, player2);

            response.Should().Be(expectedOutput);
        }

        [Theory]
        [InlineData("3H 4D 6C 5D 7S", "2H 3D 4C 5D 6S", P1Name, 25)]
        [InlineData("AH AD AS AC KD", "2H 3D 4C 5D 6S", P2Name, 20)]
        public void ReturnsTheNameOfThePlayerWhoWonAStraight(
            string p1Hand,
            string p2Hand,
            string expectedWinnerName,
            int expectedWinnerScore
        )
        {
            var player1 = new Player {Name = P1Name, Hand = p1Hand};
            var player2 = new Player {Name = P2Name, Hand = p2Hand};
            var expectedOutput = GenerateOutputForExpectedWinner(
                expectedWinnerName,
                Hand.Types.Straight,
                expectedWinnerScore);

            var response = _pokerGame.PlayCards(player1, player2);

            response.Should().Be(expectedOutput);
        }

        public static string GenerateOutputForExpectedWinner(
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