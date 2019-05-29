using FluentAssertions;
using Xunit;

namespace PokerHands
{
    public class PokerGameTests
    {
        [Fact]
        public void ReturnsTheNameOfThePlayerWhoWonHighCard()
        {
            var player1Hand = "2H 3D 5S 9C KD";
            var player2Hand = "2C 3H 4S 8C AH";

            var response = PokerGame.PlayCards(player1Hand, player2Hand);

            response.Should().Be();
        }
    }
}
