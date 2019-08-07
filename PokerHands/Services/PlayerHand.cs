using System.Collections.Generic;
using System.Linq;
using PokerHands.Models;

namespace PokerHands.Services
{
    public class PlayerHand
    {
        public Hand Best { get; }
        public Player Player { get; }

        public PlayerHand(Player player, ref List<Card> deck)
        {
            Player = player;
            var calculator = new HandCalculator();

            var playedCards = Card.ConvertToHandOfCards(player.Hand, ref deck).ToList();
            Best = calculator.BestHand(playedCards);
        }
    }
}