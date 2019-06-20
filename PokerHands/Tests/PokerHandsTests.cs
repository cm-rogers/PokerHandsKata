using FluentAssertions;
using PokerHands.Models;
using Xunit;

namespace PokerHands.Tests
{
    public class PokerHandsTests
    {
        [Fact]
        public void ReturnsTheNameOfThePlayerWithTheBestHighCard()
        {
            var player1 = new Player("player1", "");
            var player2 = new Player("player2", "");

            var result = PokerHands.Compare(player1, player2);

            result.Should().Be("player1");
        }
    }
}
