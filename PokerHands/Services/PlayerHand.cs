using System.Collections.Generic;
using System.Linq;
using PokerHands.Models;

namespace PokerHands.Services
{
    public class PlayerHand
    {
        public Hand Best { private set; get; }
        public Player Player { get; }

        private readonly IEnumerable<Card> _playedCards;
        private HandCalculator Calculator { get; }

        public PlayerHand(Player player)
        {
            Player = player;
            Calculator = new HandCalculator();

            _playedCards = Card.ConvertToHandOfCards(player.Hand);
            CalculateBestHand();
        }

        private void CalculateBestHand()
        {
            var calculatedHands = new List<Hand>
            {
                Calculator.HighCard(_playedCards),
                Calculator.Pair(_playedCards)
            };

            Best = calculatedHands.Aggregate((bestHand, nextHand) =>
                nextHand.Type > bestHand.Type && nextHand.PlayedCards.Any()
                    ? nextHand
                    : bestHand
            );
        }
    }
}