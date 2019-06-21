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
                Pairs(playedCards)
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
            var pairGroups = playedCards
                .GroupBy(card => card.Score)
                .Where(grouping => grouping.Count() == 2)
                .SelectMany(grouping => grouping)
                .ToList();

            return new Hand
            {
                PlayedCards = pairGroups,
                Score = pairGroups.Sum(c => c.Score),
                Type = pairGroups.Count == 2 ? Hand.Types.Pair : Hand.Types.TwoPair
            };
        }
    }
}