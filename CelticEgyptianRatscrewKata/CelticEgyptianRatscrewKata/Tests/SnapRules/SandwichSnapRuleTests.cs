using CelticEgyptianRatscrewKata.SnapRules;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests.SnapRules
{
    [TestFixture]
    public class SandwichSnapRuleTests
    {
        [Test]
        public void ReturnsFalseOnEmptyStack()
        {
            //ARRANGE
            var sandwichSnapRule = new SandwichSnapRule();

            //ACT
            var result = sandwichSnapRule.IsSnapValid(TestSnapRuleData.Empty());

            //ASSERT
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnsTrueForABasicSandwichWith3Cards()
        {
            //ARRANGE
            var sandwichSnapRule = new SandwichSnapRule();
            var cardStack = new Cards(new []
            {
                new Card(Suit.Clubs, Rank.Ace), 
                new Card(Suit.Clubs, Rank.Two), 
                new Card(Suit.Diamonds, Rank.Ace), 
            });

            //ACT
            var result = sandwichSnapRule.IsSnapValid(new TestSnapRuleData(cardStack));

            //ASSERT
            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnsTrueForABasicSandwichWith3CardsOfSameRank()
        {
            //ARRANGE
            var sandwichSnapRule = new SandwichSnapRule();
            var cardStack = new Cards(new []
            {
                new Card(Suit.Clubs, Rank.Ace), 
                new Card(Suit.Spades, Rank.Ace), 
                new Card(Suit.Diamonds, Rank.Ace), 
            });

            //ACT
            var result = sandwichSnapRule.IsSnapValid(new TestSnapRuleData(cardStack));

            //ASSERT
            Assert.IsTrue(result);
        }
    }
}
