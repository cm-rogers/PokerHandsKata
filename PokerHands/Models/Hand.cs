using System.Collections.Generic;
using PokerHands.Services;

namespace PokerHands.Models
{
    public class Hand
    {
        public IEnumerable<Card> PlayedCards;
        public int Score;
        public Types Type;

        public enum Types
        {
            HighCard = 0,
            Pair = 1
        }
    }
}