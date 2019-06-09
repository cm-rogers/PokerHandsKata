using System.Collections.Generic;

namespace PokerHands.Models {
    public class Hand
    {
        public IEnumerable<Card> PlayedCards;
        public int               Score;
        public Types             Type;

        public enum Types
        {
            HighCard = 0,
            Pair = 1
        }
    }
}