using FluentAssertions;
using PokerHands.Models;
using Xunit;

namespace PokerHands.Tests.Models
{
    public class PlayerTests
    {
        [Fact]
        public void ConstructsAPlayerHand()
        {
            var player = new Player("myName", "2H 3D 3C KD 5S");
            var expectedPlayerHand = new PlayerHand("2H 3D 3C KD 5S");

            var playerHand = player.Hand;

            playerHand.Should().BeEquivalentTo(expectedPlayerHand);
        }
    }
}
