using System.Linq;

namespace PokerHands
{
    public class PokerGame
    {
        public static void PlayCards(string hand1, string hand2)
        {
            var hand1Cards = hand1.Split(" ")
                .Select(card => new Card
                {
                    Value = card.Substring(0,1)
                });

            var hand2Cards = hand2.Split(" ");
        }
    }

    public class Card
    {
        public string Value { get; set; }
    }
}