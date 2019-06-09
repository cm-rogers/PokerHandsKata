using System.Collections.Generic;
using System.Linq;

namespace PokerHands.Models
{
    public class PlayerHand
    {
        private readonly IEnumerable<Card> _playedCards;
        public Hand Best { get; private set; }
        public Player Player { get; }

        public PlayerHand(Player player)
        {
            Player = player;
            _playedCards = Card.ConvertToHandOfCards(player.Hand);
            CalculateBestHand();
        }

        private void CalculateBestHand()
        {
            var calculatedHands = new List<Hand>
            {
                CalculateHighCard(),
                CalculatePair()
            };

            Best = calculatedHands.Aggregate((bestHand, nextHand) =>
                nextHand.Type > bestHand.Type && nextHand.PlayedCards.Any()
                    ? nextHand
                    : bestHand
            );
        }

        private Hand CalculateHighCard()
        {
            var highCard = _playedCards.Aggregate((highestCard, nextCard) =>
                nextCard.Score > highestCard.Score ? nextCard : highestCard
            );

            return new Hand
            {
                PlayedCards = new[] {highCard},
                Score = highCard.Score,
                Type = Hand.Types.HighCard
            };
        }

        private Hand CalculatePair()
        {
            var pair = _playedCards
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