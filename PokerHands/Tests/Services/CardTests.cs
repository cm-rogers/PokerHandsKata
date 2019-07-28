using System.Collections.Generic;
using System.ComponentModel;
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
            var expectedDeck = new List<Card>
            {
                new Card {Score = 2, Value = "2"},
                new Card {Score = 3, Value = "3"},
                new Card {Score = 4, Value = "4"},
                new Card {Score = 5, Value = "5"},
                new Card {Score = 6, Value = "6"},
                new Card {Score = 7, Value = "7"},
                new Card {Score = 8, Value = "8"},
                new Card {Score = 9, Value = "9"},
                new Card {Score = 10, Value = "10"},
                new Card {Score = 11, Value = "J"},
                new Card {Score = 12, Value = "Q"},
                new Card {Score = 13, Value = "K"},
                new Card {Score = 14, Value = "A"}
            }.SelectMany(card => new[]
            {
                new Card {Score = card.Score, Suit = Card.Suits.Clubs, Value = card.Value},
                new Card {Score = card.Score, Suit = Card.Suits.Diamonds, Value = card.Value},
                new Card {Score = card.Score, Suit = Card.Suits.Hearts, Value = card.Value},
                new Card {Score = card.Score, Suit = Card.Suits.Spades, Value = card.Value}
            });

            var deck = Card.Deck;

            deck.Should().BeEquivalentTo(expectedDeck);
        }

        [Fact]
        public void ConstructsAnEnumerableOfCardsFromAString()
        {
            const string hand = "10H 3D 3C KD 5S";
            IEnumerable<Card> expectedCards = new List<Card>
            {
                new Card {Score = 10, Suit = Card.Suits.Hearts, Value = "10"},
                new Card {Score = 3, Suit = Card.Suits.Diamonds, Value = "3"},
                new Card {Score = 3, Suit = Card.Suits.Clubs, Value = "3"},
                new Card {Score = 13, Suit = Card.Suits.Diamonds, Value = "K"},
                new Card {Score = 5, Suit = Card.Suits.Spades, Value = "5"}
            };

            var convertedCards = Card.ConvertToHandOfCards(hand);

            convertedCards.Should().BeEquivalentTo(expectedCards);
        }

        [Fact]
        public void PassingAnInvalidSuitThrows()
        {
            const string handWithInvalidSuits = "2Z 3G 3L KN 5I";

            var convertedCards = Card.ConvertToHandOfCards(handWithInvalidSuits);

            convertedCards.Invoking(Enumerable.ToList)
                .Should().Throw<InvalidEnumArgumentException>()
                .WithMessage("'Z' is not a valid suit");
        }
    }
}