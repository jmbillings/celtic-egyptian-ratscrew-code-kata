using CelticEgyptianRatscrewKata.SnapRules;
using NSubstitute;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    public class CompositeSnapRuleTests
    {
        [Test]
        public void ReturnsFalseIfNoRulesAndNoStack()
        {
            //ARRANGE
            var snapRule = new CompositeSnapRule();

            //ACT
            var result = snapRule.IsSnapValid(Cards.Empty());

            //ASSERT
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnsTrueIfThereIsOneRuleAndItReturnsTrue()
        {
            //ARRANGE
            var alwaysTrueRule = Substitute.For<ISnapRule>();
            alwaysTrueRule.IsSnapValid(Arg.Any<Cards>()).Returns(true);
            var snapRule = new CompositeSnapRule(alwaysTrueRule);

            //ACT
            var result = snapRule.IsSnapValid(Cards.Empty());

            //ASSERT
            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnsTrueOnlyOnSpecificStack()
        {
            //ARRANGE
            var cardStack = new Cards(new []
            {
                new Card(Suit.Clubs, Rank.Ace) 
            });

            var alwaysTrueRule = Substitute.For<ISnapRule>();
            alwaysTrueRule.IsSnapValid(Arg.Any<Cards>()).Returns(false);
            alwaysTrueRule.IsSnapValid(cardStack).Returns(true);

            var snapRule = new CompositeSnapRule(alwaysTrueRule);

            //ACT
            var result = snapRule.IsSnapValid(cardStack);

            //ASSERT
            Assert.IsTrue(result);
        }
    }
}
