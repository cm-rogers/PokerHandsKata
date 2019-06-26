using System.Collections.Generic;
using System.Linq;
using PokerHands.Models;

namespace PokerHands.Services
{
    public class HandCalculator
    {
        public Hand BestHand(List<Card> playedCards)
        {
            var calculatedHands = new List<Hand>
            {
                HighCard(playedCards),
                Pairs(playedCards),
                ThreeOfAKind(playedCards),
                FourOfAKind(playedCards),
            };

            return calculatedHands.Aggregate((bestHand, nextHand) =>
                nextHand.Type > bestHand.Type && nextHand.PlayedCards.Any()
                    ? nextHand
                    : bestHand
            );
        }

        private static Hand HighCard(IEnumerable<Card> playedCards)
        {
            var highCard = playedCards.Aggregate((highestCard, nextCard) =>
                nextCard.Score > highestCard.Score ? nextCard : highestCard
            );

            return new Hand
            {
                PlayedCards = new[] {highCard},
                Score = highCard.Score,
                Type = Hand.Types.HighCard
            };
        }

        private static Hand Pairs(IEnumerable<Card> playedCards)
        {
            const int wantedCountOfCardsInGroup = 2;
            var cardGroups = CardGroups(playedCards, wantedCountOfCardsInGroup);

            return new Hand
            {
                PlayedCards = cardGroups,
                Score = cardGroups.Sum(c => c.Score),
                Type = cardGroups.Count == 2 ? Hand.Types.Pair : Hand.Types.TwoPair
            };
        }

        private static Hand ThreeOfAKind(IEnumerable<Card> playedCards)
        {
            const int wantedCountOfCardsInGroup = 3;
            var cardGroups = CardGroups(playedCards, wantedCountOfCardsInGroup);

            return new Hand
            {
                PlayedCards = cardGroups,
                Score = cardGroups.Sum(c => c.Score),
                Type = Hand.Types.ThreeOfAKind
            };
        }

        private static Hand FourOfAKind(IEnumerable<Card> playedCards)
        {
            const int wantedCountOfCardsInGroup = 4;
            var cardGroups = CardGroups(playedCards, wantedCountOfCardsInGroup);

            return new Hand
            {
                PlayedCards = cardGroups,
                Score = cardGroups.Sum(c => c.Score),
                Type = Hand.Types.FourOfAKind
            };
        }

        private static List<Card> CardGroups(IEnumerable<Card> playedCards, int wantedCountOfCardsInGroup)
        {
            return playedCards
                .GroupBy(card => card.Score)
                .Where(grouping => grouping.Count() == wantedCountOfCardsInGroup)
                .SelectMany(grouping => grouping)
                .ToList();
        }
    }
}