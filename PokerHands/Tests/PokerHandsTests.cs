using Xunit;

namespace PokerHands.Tests
{
    public class PokerHandsTests
    {
        [Fact]
        public void ReturnsTheNameOfThePlayerWithTheBestHighCard()
        {
            object player1 = new
            {
                Name = "player1",
                Hand = ""
            };

            object player2 = new
            {
                Name = "player2",
                Hand = ""
            };

            PokerHands.Compare(player1, player2);
        }
    }
}
