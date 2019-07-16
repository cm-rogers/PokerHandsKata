using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using PokerHands.Services;
using Xunit;

namespace PokerHands.Tests.Services
{
    public class CardTests
    {
        [Fact]
        public void ConstructsADeckOfCards()
        {
            var expectedDeck = GetTheWhole52();

            var deck = Card.Deck;

            deck.Should().BeEquivalentTo(expectedDeck);
        }

        [Fact]
        public void ConstructsAnEnumerableOfCardsFromAString()
        {
            const string hand = "2H 3D 3C KD 5S";
            var expectedCards = new List<Card>
            {
                new Card {Score = 2, Suit = Card.Suits.Hearts, Value = "2"},
                new Card {Score = 3, Suit = Card.Suits.Diamonds, Value = "3"},
                new Card {Score = 3, Suit = Card.Suits.Clubs, Value = "3"},
                new Card {Score = 13, Suit = Card.Suits.Diamonds, Value = "K"},
                new Card {Score = 5, Suit = Card.Suits.Spades, Value = "5"}
            };

            var convertedCards = Card.ConvertToHandOfCards(hand);

            convertedCards.Should().BeEquivalentTo(expectedCards);
        }

        private List<Card> GetTheWhole52()
        {
            return new List<Card>
            {
                new Card {Score = 2, Value = "2", Suit = Card.Suits.Clubs},
                new Card {Score = 3, Value = "3", Suit = Card.Suits.Clubs},
                new Card {Score = 4, Value = "4", Suit = Card.Suits.Clubs},
                new Card {Score = 5, Value = "5", Suit = Card.Suits.Clubs},
                new Card {Score = 6, Value = "6", Suit = Card.Suits.Clubs},
                new Card {Score = 7, Value = "7", Suit = Card.Suits.Clubs},
                new Card {Score = 8, Value = "8", Suit = Card.Suits.Clubs},
                new Card {Score = 9, Value = "9", Suit = Card.Suits.Clubs},
                new Card {Score = 10, Value = "10", Suit = Card.Suits.Clubs},
                new Card {Score = 11, Value = "J", Suit = Card.Suits.Clubs},
                new Card {Score = 12, Value = "Q", Suit = Card.Suits.Clubs},
                new Card {Score = 13, Value = "K", Suit = Card.Suits.Clubs},
                new Card {Score = 14, Value = "A", Suit = Card.Suits.Clubs},
                new Card {Score = 2, Value = "2", Suit = Card.Suits.Diamonds},
                new Card {Score = 3, Value = "3", Suit = Card.Suits.Diamonds},
                new Card {Score = 4, Value = "4", Suit = Card.Suits.Diamonds},
                new Card {Score = 5, Value = "5", Suit = Card.Suits.Diamonds},
                new Card {Score = 6, Value = "6", Suit = Card.Suits.Diamonds},
                new Card {Score = 7, Value = "7", Suit = Card.Suits.Diamonds},
                new Card {Score = 8, Value = "8", Suit = Card.Suits.Diamonds},
                new Card {Score = 9, Value = "9", Suit = Card.Suits.Diamonds},
                new Card {Score = 10, Value = "10", Suit = Card.Suits.Diamonds},
                new Card {Score = 11, Value = "J", Suit = Card.Suits.Diamonds},
                new Card {Score = 12, Value = "Q", Suit = Card.Suits.Diamonds},
                new Card {Score = 13, Value = "K", Suit = Card.Suits.Diamonds},
                new Card {Score = 14, Value = "A", Suit = Card.Suits.Diamonds},
                new Card {Score = 2, Value = "2", Suit = Card.Suits.Hearts},
                new Card {Score = 3, Value = "3", Suit = Card.Suits.Hearts},
                new Card {Score = 4, Value = "4", Suit = Card.Suits.Hearts},
                new Card {Score = 5, Value = "5", Suit = Card.Suits.Hearts},
                new Card {Score = 6, Value = "6", Suit = Card.Suits.Hearts},
                new Card {Score = 7, Value = "7", Suit = Card.Suits.Hearts},
                new Card {Score = 8, Value = "8", Suit = Card.Suits.Hearts},
                new Card {Score = 9, Value = "9", Suit = Card.Suits.Hearts},
                new Card {Score = 10, Value = "10", Suit = Card.Suits.Hearts},
                new Card {Score = 11, Value = "J", Suit = Card.Suits.Hearts},
                new Card {Score = 12, Value = "Q", Suit = Card.Suits.Hearts},
                new Card {Score = 13, Value = "K", Suit = Card.Suits.Hearts},
                new Card {Score = 14, Value = "A", Suit = Card.Suits.Hearts},
                new Card {Score = 2, Value = "2", Suit = Card.Suits.Spades},
                new Card {Score = 3, Value = "3", Suit = Card.Suits.Spades},
                new Card {Score = 4, Value = "4", Suit = Card.Suits.Spades},
                new Card {Score = 5, Value = "5", Suit = Card.Suits.Spades},
                new Card {Score = 6, Value = "6", Suit = Card.Suits.Spades},
                new Card {Score = 7, Value = "7", Suit = Card.Suits.Spades},
                new Card {Score = 8, Value = "8", Suit = Card.Suits.Spades},
                new Card {Score = 9, Value = "9", Suit = Card.Suits.Spades},
                new Card {Score = 10, Value = "10", Suit = Card.Suits.Spades},
                new Card {Score = 11, Value = "J", Suit = Card.Suits.Spades},
                new Card {Score = 12, Value = "Q", Suit = Card.Suits.Spades},
                new Card {Score = 13, Value = "K", Suit = Card.Suits.Spades},
                new Card {Score = 14, Value = "A", Suit = Card.Suits.Spades},
            };
        }
    }
}