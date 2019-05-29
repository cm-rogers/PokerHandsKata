using System.Collections.Generic;
using System.Linq;
using PokerHands.Models;

namespace PokerHands
{
    public class PokerGame
    {
        private readonly IEnumerable<Card> _deck;

        public PokerGame()
        {
            var cardValues = Enumerable.Range(2, 10)
                .Select(i => i.ToString())
                .ToList();

            cardValues.AddRange(new[] {"J", "Q", "K", "A"});

            _deck = cardValues.Select((value, index) =>
                new Card {Value = value, Score = index}
            );
        }

        public int PlayCards(string hand1, string hand2)
        {
            var handOfCards1 = ConvertHandToHandOfCards(hand1);
            var hand1BestCard = handOfCards1.Max(c => c.Score);

            var handOfCards2 = ConvertHandToHandOfCards(hand2);
            var hand2BestCard = handOfCards2.Max(c => c.Score);

            return hand1BestCard > hand2BestCard ? 1 : 2;
        }

        private IEnumerable<Card> ConvertHandToHandOfCards(string hand)
        {
            return hand.Split(" ")
                .Select(v => v.Substring(0,1)) // @TODO: Add suit back when testable
                .SelectMany(handValue => _deck.Where(c => c.Value == handValue));
        }
    }
}