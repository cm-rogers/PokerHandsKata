using FluentAssertions;
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
            const string player1Hand = "2H 3D 5S 9C KD";
            const string player2Hand = "2C 3H 4S 8C AH";

            var response = _pokerGame.PlayCards(player1Hand, player2Hand);

            response.Should().Be(2);
        }
    }
}
