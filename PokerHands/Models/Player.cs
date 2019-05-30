using System.Collections.Generic;
using System.Linq;

namespace PokerHands.Models
{
    public class Player
    {
        public string Name;
        public IEnumerable<Card> Hand;

        public Player(string name, string hand)
        {
            Name = name;
            Hand = ConvertToHandOfCards(hand);
        }

        private static IEnumerable<Card> ConvertToHandOfCards(string hand)
        {
            return hand.Split(" ")
                .Select(v => v.Substring(0, 1)) // @TODO: Add suit back when testable
                .SelectMany(handValue => Card.Deck.Where(c => c.Value == handValue));
        }
    }
}