using System.Collections.Generic;
using System.Linq;

namespace PokerHands.Services
{
    public class Card
    {
        public string Value { get; set; }
        public int Score { get; set; }
        public static IEnumerable<Card> Deck => MakeDeck();

        private static IEnumerable<Card> MakeDeck()
        {
            const int firstCardValue = 2;
            var faceCards = new[] {"J", "Q", "K", "A"};

            return Enumerable.Range(firstCardValue, 9)
                .Select(i => i.ToString())
                .Concat(faceCards)
                .ToList()
                .Select((value, index) =>
                    new Card {Value = value, Score = index + firstCardValue}
                );
        }

        public static IEnumerable<Card> ConvertToHandOfCards(string hand)
        {
            return hand.Split(" ")
                // @TODO: Add suit back when testable
                .Select(cardValue => cardValue.Substring(0, 1))
                .SelectMany(handValue =>
                    Deck.Where(c => c.Value == handValue)
                );
        }
    }
}