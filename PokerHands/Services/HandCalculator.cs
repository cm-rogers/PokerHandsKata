using System.Collections.Generic;
using System.Linq;
using PokerHands.Models;

namespace PokerHands.Services
{
    public class HandCalculator
    {
        public Hand HighCard(IEnumerable<Card> playedCards)
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

        public Hand Pair(IEnumerable<Card> playedCards)
        {
            var pair = playedCards
                .GroupBy(card => card.Score)
                .Where(grouping => grouping.Count() == 2)
                .SelectMany(grouping => grouping)
                .ToList();

            return new Hand
            {
                PlayedCards = pair,
                Score = pair.Sum(c => c.Score),
                Type = Hand.Types.Pair
            };
        }
    }
}