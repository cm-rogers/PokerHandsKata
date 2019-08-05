using System.Linq;
using PokerHands.Models;
using PokerHands.Services;

namespace PokerHands
{
    public class PokerGame
    {
        public string PlayCards(Player player1, Player player2)
        {
            PlayerHand winningPlayerHand;

            var deck = Card.Deck.ToList();

            var player1Hand = new PlayerHand(player1, ref deck);
            var player2Hand = new PlayerHand(player2, ref deck);

            if (player1Hand.Best.Type == player2Hand.Best.Type)
            {
                winningPlayerHand = player1Hand.Best.Score > player2Hand.Best.Score
                    ? player1Hand
                    : player2Hand;
            }
            else
            {
                winningPlayerHand = player1Hand.Best.Type > player2Hand.Best.Type
                    ? player1Hand
                    : player2Hand;
            }

            return $"Player {winningPlayerHand.Player.Name} wins with a "
                   + $"{winningPlayerHand.Best.Type.ToString()}"
                   + $" score of {winningPlayerHand.Best.Score}";
        }
    }
}