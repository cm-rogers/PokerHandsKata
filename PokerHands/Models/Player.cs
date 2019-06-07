namespace PokerHands.Models
{
    public class Player
    {
        public string Name { get; }
        public PlayerHand Hand { get; }

        public Player(string name, string hand)
        {
            Name = name;
            Hand = new PlayerHand(hand);
        }
    }
}