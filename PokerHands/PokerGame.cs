using System.Linq;
using PokerHands.Models;

namespace PokerHands
{
    public class PokerGame
    {
        public string PlayCards(Player player1, Player player2)
        {
            // @TODO: Make this a function
            var player1HighCard = player1.Hand.Max(c => c.Score);
            var player2HighCard = player2.Hand.Max(c => c.Score);

            var player1PairScore = player1.Hand
                .GroupBy(c => c.Score)
                .Where(g => g.Count() == 2)
                .SelectMany(g => g)
                .Sum(c => c.Score);
            var player2PairScore = player2.Hand
                .GroupBy(c => c.Score)
                .Where(g => g.Count() == 2)
                .SelectMany(g => g)
                .Sum(c => c.Score);

            if (player1PairScore > 0 || player2PairScore > 0)
            {
                return player1PairScore > player2PairScore
                    ? player1.Name
                    : player2.Name;
            }

            return player1HighCard > player2HighCard
                ? player1.Name
                : player2.Name;
        }
    }
}
