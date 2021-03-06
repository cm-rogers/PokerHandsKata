﻿using System.Collections.Generic;
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
            Pair = 1,
            TwoPair = 2,
            ThreeOfAKind = 3,
            Straight = 4,
            Flush = 5,
            FullHouse = 6,
            FourOfAKind = 7,
            StraightFlush = 8
        }
    }
}