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

            response.Should().BeEquivalentTo(expectedResponse);
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

            response.Should().BeEquivalentTo(expectedResponse);
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

            response.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void CalculatesThreeOfAKind()
        {
            var playerHand = Card.ConvertToHandOfCards(
                "2H 2D 2C QD KS"
            ).ToList();
            var expectedResponse = new Hand
            {
                PlayedCards = playerHand.Where(card => card.Value == "2").ToList(),
                Score = 6,
                Type = Hand.Types.ThreeOfAKind
            };

            var response = _calculator.BestHand(playerHand);

            response.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void CalculatesFourOfAKind()
        {
            var playerHand = Card.ConvertToHandOfCards(
                "2H 2D 2C QD 2S"
            ).ToList();
            var expectedResponse = new Hand
            {
                PlayedCards = playerHand.Where(card => card.Value == "2").ToList(),
                Score = 8,
                Type = Hand.Types.FourOfAKind
            };

            var response = _calculator.BestHand(playerHand);

            response.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void CalculatesStraight()
        {
            var playerHand = Card.ConvertToHandOfCards(
                "3H 4D 6C 5D 7S"
            ).ToList();
            var expectedResponse = new Hand
            {
                PlayedCards = playerHand.OrderBy(card => card.Score),
                Score = 25,
                Type = Hand.Types.Straight
            };

            var response = _calculator.BestHand(playerHand);

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }

    public class HandCalculatorTypeTests
    {
        [Fact]
        public void PairBeatsHighCard()
        {
            const int highCard = (int)Hand.Types.HighCard;
            const int pair = (int)Hand.Types.Pair;

            pair.Should().BeGreaterThan(highCard);
        }

        [Fact]
        public void TwoPairBeatsPair()
        {
            const int pair = (int) Hand.Types.Pair;
            const int twoPair = (int) Hand.Types.TwoPair;

            twoPair.Should().BeGreaterThan(pair);
        }

        [Fact]
        public void ThreeOfAKindBeatsTwoPair()
        {
            const int twoPair = (int) Hand.Types.TwoPair;
            const int threeOfAKind = (int) Hand.Types.ThreeOfAKind;

            threeOfAKind.Should().BeGreaterThan(twoPair);
        }

        [Fact]
        public void StraightBeatsThreeOfAKind()
        {
            const int threeOfAKind = (int)Hand.Types.ThreeOfAKind;
            const int straight = (int)Hand.Types.Straight;

            straight.Should().BeGreaterThan(threeOfAKind);
        }

        [Fact]
        public void FourOfAKindBeatsStraight()
        {
            const int straight = (int)Hand.Types.Straight;
            const int fourOfAKind = (int)Hand.Types.FourOfAKind;

            fourOfAKind.Should().BeGreaterThan(straight);
        }
    }
}