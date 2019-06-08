using FluentAssertions;
using PokerHands.Models;
using Xunit;

namespace PokerHands.Tests.Models
{
    public class PlayerHandTests
    {
        [Fact]
        public void BestHandIsCalculatedAsHighCardCorrectly()
        {
            var playerHand = new PlayerHand(
                new Player {Hand = "2H 3D 9C KD 5S", Name = "Alice"}
            );

            playerHand.Best.Should().BeEquivalentTo(new Hand
            {
                PlayedCards = new[] {new Card {Score = 13, Value = "K"}},
                Score = 13,
                Type = Hand.Types.HighCard
            });
        }

        [Fact]
        public void BestPairIsCalculatedCorrectly()
        {
            var playerHand = new PlayerHand(
                new Player {Hand = "2H 3D 3C KD 5S", Name = "Bob"}
            );

            playerHand.Best.Should().BeEquivalentTo(new Hand
            {
                PlayedCards = new[]
                {
                    new Card {Score = 3, Value = "3"},
                    new Card {Score = 3, Value = "3"}
                },
                Score = 6,
                Type = Hand.Types.Pair
            });
        }
    }
}