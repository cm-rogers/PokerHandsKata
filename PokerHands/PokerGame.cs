using System.Collections.Generic;
using System.Linq;
using PokerHands.Models;

namespace PokerHands
{
    public class PokerGame
    {
        public string PlayCards(Player player1, Player player2)
        {
            var player1HighCard = player1.Hand.Max(c => c.Score);
            var player2HighCard = player2.Hand.Max(c => c.Score);

            return player1HighCard > player2HighCard ? player1.Name : player2.Name;
        }
    }
}
