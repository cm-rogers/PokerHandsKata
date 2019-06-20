using System.Linq;
using PokerHands.Models;

namespace PokerHands.Services
{
    public class PlayerHand
    {
        public Hand Best { get; }
        public Player Player { get; }

        public PlayerHand(Player player)
        {
            Player = player;
            var calculator = new HandCalculator();

            var playedCards = Card.ConvertToHandOfCards(player.Hand).ToList();
            Best = calculator.BestHand(playedCards);
        }
    }
}