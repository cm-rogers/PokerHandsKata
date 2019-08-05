using System;
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
                .SelectMany((value, index) => Enum.GetValues(typeof(Suits))
                    .Cast<Suits>()
                    .Select(suit => new Card {Score = index + firstCardValue, Suit = suit, Value = value})
                );
        }

        public static IEnumerable<Card> ConvertToHandOfCards(string hand, ref List<Card> deck)
        {
            var _deck = deck;

            return hand.Split(" ").Select(stringCard =>
            {
                var valueLength = stringCard.Length - 1;
                var value = stringCard.Substring(0, valueLength);
                var suit = stringCard.Substring(valueLength, 1);

                var matchingCard = _deck.First(card =>
                    card.Value == value && card.Suit == StringToSuit(suit)
                );

                _deck.Remove(matchingCard);

                return matchingCard;
            });
        }

        private static Suits StringToSuit(string suit)
        {
            if (suit == "C")
            {
                return Suits.Clubs;
            }

            if (suit == "D")
            {
                return Suits.Diamonds;
            }

            if (suit == "H")
            {
                return Suits.Hearts;
            }

            if (suit == "S")
            {
                return Suits.Spades;
            }

            throw new InvalidEnumArgumentException($"'{suit}' is not a valid suit");
        }

        public enum Suits
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades
        }
    }

    internal static class ListExtensions { }
}