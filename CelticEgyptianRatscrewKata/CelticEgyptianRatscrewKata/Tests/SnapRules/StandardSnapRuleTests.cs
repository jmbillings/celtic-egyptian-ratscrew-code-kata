using System.Collections.Generic;
using System.Linq;
using CelticEgyptianRatscrewKata.SnapRules;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests.SnapRules
{
    [TestFixture]
    public class StandardSnapRuleTests
    {
        private StandardSnapRule _standardSnapRule;

        [SetUp]
        public void SetUp()
        {
            _standardSnapRule = new StandardSnapRule();
        }

        [Test]
        public void ReturnsFalseIfEmpty()
        {
            //ACT
            var result = _standardSnapRule.IsSnapValid(TestSnapRuleData.Empty());

            //ASSERT
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnsFalseForAStackWithASingleCard()
        {
            //ARRANGE
            var stack = new Cards(new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace)
            });

            //ACT
            var result = _standardSnapRule.IsSnapValid(new TestSnapRuleData(stack));

            //ASSERT
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnsTrueForAStackWithTwoCardsOfTheSameRank()
        {
            //ARRANGE
            var stack = new Cards(new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Diamonds, Rank.Ace)
            });

            //ACT
            var result = _standardSnapRule.IsSnapValid(new TestSnapRuleData(stack));

            //ASSERT
            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnsFalseForAStackWithTwoCardsOfDifferingRank()
        {
            //ARRANGE
            var stack = new Cards(new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Clubs, Rank.Two)
            });

            //ACT
            var result = _standardSnapRule.IsSnapValid(new TestSnapRuleData(stack));

            //ASSERT
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnsFalseForAStackWithTwoCardsOfSameRankNotAdjacentToEachOther()
        {
            //ARRANGE
            var stack = new Cards(new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Diamonds, Rank.Ace)
            });

            //ACT
            var result = _standardSnapRule.IsSnapValid(new TestSnapRuleData(stack));

            //ASSERT
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnsTrueForAStackWithTwoAdjacentCardsOfTheSameRankAreInTheMiddleOfTheStack()
        {
            //ARRANGE
            var stack = new Cards(new List<Card>
            {
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Diamonds, Rank.Ace),
                new Card(Suit.Diamonds, Rank.Two)
            });

            //ACT
            var result = _standardSnapRule.IsSnapValid(new TestSnapRuleData(stack));

            //ASSERT
            Assert.IsTrue(result);
        }
    }
}
