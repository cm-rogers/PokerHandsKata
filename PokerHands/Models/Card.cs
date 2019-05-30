using System.Collections.Generic;
using System.Linq;

namespace PokerHands.Models
{
    public class Card
    {
        public string Value { get; set; }
        public int Score { get; set; }
        public static IEnumerable<Card> Deck => MakeDeck();

        private static IEnumerable<Card> MakeDeck()
        {
            return Enumerable.Range(2, 10)
                .Select(i => i.ToString())
                .Concat(new[] { "J", "Q", "K", "A" })
                .ToList()
                .Select((value, index) =>
                    new Card { Value = value, Score = index }
                );
        }
    }
}
