﻿using System.Linq;
using FluentAssertions;
using PokerHands.Models;
using PokerHands.Services;
using Xunit;

namespace PokerHands.Tests.Services
{
    public class PlayerHandTests
    {
        [Fact]
        public void StoresThePlayer()
        {
            var deck = Card.Deck.ToList();
            var player = new Player {Hand = "2H 3D 9C KD 5S", Name = "Alice"};

            var playerHand = new PlayerHand(player, ref deck);

            playerHand.Player.Should().BeEquivalentTo(player);
        }

        [Fact]
        public void StoresTheBestHand()
        {
            var deck = Card.Deck.ToList();
            var player = new Player {Hand = "2H 3D 9C KD 5S", Name = "Alice"};
            var calculator = new HandCalculator();
            var outcomeDeck = Card.Deck.ToList();
            var playedCards = Card.ConvertToHandOfCards(player.Hand, ref outcomeDeck).ToList();
            var expectedOutcome = calculator.BestHand(playedCards);

            var playerHand = new PlayerHand(player, ref deck);

            playerHand.Best.Should().BeEquivalentTo(expectedOutcome);
        }
    }
}