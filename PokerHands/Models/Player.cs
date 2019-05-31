using System.Collections.Generic;
using System.Linq;

namespace PokerHands.Models
{
    public class Player
    {
        public string Name { get; }
        public PlayerHand Hand { get; }

        public Player(string name, string hand)
        {
            Name = name;
            Hand = new PlayerHand(hand);
        }
    }

    public class PlayerHand
    {
        public IEnumerable<Card> PlayedCards;
        public Hands Best;
        public int Score;

        public PlayerHand(string playedCards)
        {
            PlayedCards = ConvertToHandOfCards(playedCards);
        }

        public void CalculateHighCard()
        {
            // @TODO: Move high card calculation here
        }

        private static IEnumerable<Card> ConvertToHandOfCards(string hand)
        {
            return hand.Split(" ")
                // @TODO: Add suit back when testable
                .Select(v => v.Substring(0, 1))
                .SelectMany(handValue =>
                    Card.Deck.Where(c => c.Value == handValue)
                );
        }
    }

    public enum Hands {
        HighCard,
        Pair,
    }
}