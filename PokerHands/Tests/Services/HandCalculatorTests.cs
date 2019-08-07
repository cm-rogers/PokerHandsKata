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
            var deck = Card.Deck.ToList();
            var playerHand = Card.ConvertToHandOfCards(
                "2H AD KC JD 5S",
                ref deck
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
            var deck = Card.Deck.ToList();
            var playerHand = Card.ConvertToHandOfCards(
                "2H AD KC KD 5S",
                ref deck
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
            var deck = Card.Deck.ToList();
            var playerHand = Card.ConvertToHandOfCards(
                "2H 2D KC QD KS",
                ref deck
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
            var deck = Card.Deck.ToList();
            var playerHand = Card.ConvertToHandOfCards(
                "2H 2D 2C QD KS",
                ref deck
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
        public void CalculatesStraight()
        {
            var deck = Card.Deck.ToList();
            var playerHand = Card.ConvertToHandOfCards(
                "3H 4D 6C 5D 7S",
                ref deck
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

        [Fact]
        public void CalculatesFlush()
        {
            var deck = Card.Deck.ToList();
            var playerHand = Card.ConvertToHandOfCards(
                "3D 4D JD KD 8D",
                ref deck
            ).ToList();
            var expectedResponse = new Hand
            {
                PlayedCards = playerHand,
                Score = 39,
                Type = Hand.Types.Flush
            };

            var response = _calculator.BestHand(playerHand);

            response.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void CalculatesFullHouse()
        {
            var deck = Card.Deck.ToList();
            var playerHand = Card.ConvertToHandOfCards(
                "2H 2D 2C QD QS",
                ref deck
            ).ToList();
            var expectedResponse = new Hand
            {
                PlayedCards = playerHand,
                Score = 30,
                Type = Hand.Types.FullHouse
            };

            var response = _calculator.BestHand(playerHand);

            response.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void CalculatesFourOfAKind()
        {
            var deck = Card.Deck.ToList();
            var playerHand = Card.ConvertToHandOfCards(
                "2H 2D 2C QD 2S",
                ref deck
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
        public void CalculatesStraightFlush()
        {
            var deck = Card.Deck.ToList();
            var playerHand = Card.ConvertToHandOfCards(
                "5S 9S 6S 8S 7S",
                ref deck
            ).ToList();
            var expectedResponse = new Hand
            {
                PlayedCards = playerHand,
                Score = 35,
                Type = Hand.Types.StraightFlush
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
            const int highCard = (int) Hand.Types.HighCard;
            const int pair = (int) Hand.Types.Pair;

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
            const int threeOfAKind = (int) Hand.Types.ThreeOfAKind;
            const int straight = (int) Hand.Types.Straight;

            straight.Should().BeGreaterThan(threeOfAKind);
        }

        [Fact]
        public void FlushBeatsStraight()
        {
            const int straight = (int) Hand.Types.Straight;
            const int flush = (int) Hand.Types.Flush;

            flush.Should().BeGreaterThan(straight);
        }

        [Fact]
        public void FullHouseBeatsFlush()
        {
            const int flush = (int) Hand.Types.Flush;
            const int fullHouse = (int) Hand.Types.FullHouse;

            fullHouse.Should().BeGreaterThan(flush);
        }

        [Fact]
        public void FourOfAKindBeatsFullHouse()
        {
            const int fullHouse = (int) Hand.Types.FullHouse;
            const int fourOfAKind = (int) Hand.Types.FourOfAKind;

            fourOfAKind.Should().BeGreaterThan(fullHouse);
        }

        [Fact]
        public void StraightFlushBeatsFourOfAKind()
        {
            const int straightFlush = (int) Hand.Types.StraightFlush;
            const int fourOfAKind = (int) Hand.Types.FourOfAKind;

            straightFlush.Should().BeGreaterThan(fourOfAKind);
        }
    }
}