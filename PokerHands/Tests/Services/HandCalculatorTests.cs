using System.Linq;
using FluentAssertions;
using PokerHands.Models;
using PokerHands.Services;
using Xunit;

namespace PokerHands.Tests.Services
{
    public class HandCalculatorTests
    {
        private readonly HandCalculator _calculator;

        public HandCalculatorTests()
        {
            _calculator = new HandCalculator();
        }

        [Fact]
        public void CalculatesHighCard()
        {
            var playerHand = Card.ConvertToHandOfCards(
                "2H AD KC JD 5S"
            ).ToList();
            var expectedResponse = new Hand
            {
                PlayedCards = playerHand.Where(card => card.Value == "A"),
                Score = 14,
                Type = Hand.Types.HighCard
            };

            var response = _calculator.BestHand(playerHand);

            response.ShouldBeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void CalculatesPair()
        {
            var playerHand = Card.ConvertToHandOfCards(
                "2H AD KC KD 5S"
            ).ToList();
            var expectedResponse = new Hand
            {
                PlayedCards = playerHand.Where(card => card.Value == "K"),
                Score = 26,
                Type = Hand.Types.Pair
            };

            var response = _calculator.BestHand(playerHand);

            response.ShouldBeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void CalculatesTwoPair()
        {
            var playerHand = Card.ConvertToHandOfCards(
                "2H 2D KC QD KS"
            ).ToList();
            var expectedResponse = new Hand
            {
                PlayedCards = playerHand.Where(card => card.Value == "K" || card.Value == "2").ToList(),
                Score = 30,
                Type = Hand.Types.TwoPair
            };

            var response = _calculator.BestHand(playerHand);

            response.ShouldBeEquivalentTo(expectedResponse);
        }
    }
}