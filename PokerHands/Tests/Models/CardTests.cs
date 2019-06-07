using System.Collections.Generic;
using FluentAssertions;
using PokerHands.Models;
using Xunit;

namespace PokerHands.Tests.Models
{
    public class CardTests
    {
        [Fact]
        public void ConstructsADeckOfCards()
        {
            var expectedDeck = new List<Card>
            {
                new Card{Score = 2, Value = "2"},
                new Card{Score = 3, Value = "3"},
                new Card{Score = 4, Value = "4"},
                new Card{Score = 5, Value = "5"},
                new Card{Score = 6, Value = "6"},
                new Card{Score = 7, Value = "7"},
                new Card{Score = 8, Value = "8"},
                new Card{Score = 9, Value = "9"},
                new Card{Score = 10, Value = "10"},
                new Card{Score = 11, Value = "J"},
                new Card{Score = 12, Value = "Q"},
                new Card{Score = 13, Value = "K"},
                new Card{Score = 14, Value = "A"},
            };

            var deck = Card.Deck;

            deck.Should().BeEquivalentTo(expectedDeck);
        }

        [Fact]
        public void ConstructsAnEnumerableOfCardsFromAString()
        {
            const string hand = "2H 3D 3C KD 5S";
            var expectedCards = new List<Card>
            {
                new Card{Score = 2, Value = "2"},
                new Card{Score = 3, Value = "3"},
                new Card{Score = 3, Value = "3"},
                new Card{Score = 13, Value = "K"},
                new Card{Score = 5, Value = "5"},
            };

            var convertedCards = Card.ConvertToHandOfCards(hand);

            convertedCards.Should().BeEquivalentTo(expectedCards);
        }
    }
}
