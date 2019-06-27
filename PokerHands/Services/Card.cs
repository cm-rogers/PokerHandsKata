using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PokerHands.Services
{
    public class Card
    {
        public string Value { get; set; }
        public int Score { get; set; }
        public Suits Suit { get; set; }

        public static IEnumerable<Card> Deck => MakeDeck();

        private static IEnumerable<Card> MakeDeck()
        {
            const int firstCardValue = 2;
            var faceCards = new[] {"J", "Q", "K", "A"};

            return Enumerable.Range(firstCardValue, 9)
                .Select(i => i.ToString())
                .Concat(faceCards)
                .ToList()
                .SelectMany((value, index) => new []
                    {
                        new Card {Score = index + firstCardValue, Suit = Suits.Clubs, Value = value},
                        new Card {Score = index + firstCardValue, Suit = Suits.Diamonds, Value = value},
                        new Card {Score = index + firstCardValue, Suit = Suits.Hearts, Value = value},
                        new Card {Score = index + firstCardValue, Suit = Suits.Spades, Value = value},
                    }
                );
        }

        public static IEnumerable<Card> ConvertToHandOfCards(string hand)
        {
            return hand.Split(" ")
                .Select(stringCard => Deck.First(card =>
                {
                    var valueAsString = stringCard.Substring(0, 1);
                    var suitAsString = stringCard.Substring(1, 1);

                    return card.Value == valueAsString && card.Suit == StringToSuit(suitAsString);
                }));
        }

        private static Suits StringToSuit(string suit)
        {
            if (suit == "C")
            {
                return Suits.Clubs;
            }
            else if (suit == "D")
            {
                return Suits.Diamonds;
            }
            else if (suit == "H")
            {
                return Suits.Hearts;
            }
            else if (suit == "S")
            {
                return Suits.Spades;
            }

            // @TODO: Test failure case
            throw new InvalidEnumArgumentException($"'{suit}' is not a valid suit");
        }

        public enum Suits
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades,
        }
    }
}