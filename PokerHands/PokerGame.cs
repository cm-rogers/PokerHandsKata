using System.Linq;
using PokerHands.Models;

namespace PokerHands
{
    public class PokerGame
    {
        public string PlayCards(Player player1, Player player2)
        {
            if (player1.Hand.Best.Type == player2.Hand.Best.Type)
            {
                return player1.Hand.Best.Score > player2.Hand.Best.Score
                    ? player1.Name
                    : player2.Name;
            }

            return player1.Hand.Best.Type > player2.Hand.Best.Type
                ? player1.Name
                : player2.Name;
        }
    }
}