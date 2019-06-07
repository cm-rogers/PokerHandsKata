using System.Linq;
using PokerHands.Models;

namespace PokerHands
{
    public class PokerGame
    {
        public string PlayCards(Player player1, Player player2)
        {
            Player winningPlayer;

            if (player1.Hand.Best.Type == player2.Hand.Best.Type)
            {
                winningPlayer = player1.Hand.Best.Score > player2.Hand.Best.Score
                    ? player1
                    : player2;
            }
            else
            {
                winningPlayer = player1.Hand.Best.Type > player2.Hand.Best.Type
                    ? player1
                    : player2;
            }

            return $"Player {winningPlayer.Name} wins with a "
                       + $"{winningPlayer.Hand.Best.Type.ToString()}"
                       + $" score of {winningPlayer.Hand.Best.Score}";
        }
    }
}