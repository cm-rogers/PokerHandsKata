﻿using System;
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

        public static IEnumerable<Card> ConvertToHandOfCards(string hand)
        {
            return hand.Split(" ").Select(cardValue =>
            {
                var value = cardValue.Substring(0, 1);
                var suit = cardValue.Substring(1, 1);

                return Deck.First(card => card.Value == value && card.Suit == StringToSuit(suit));
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

            // @TODO: Test failure case
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
}