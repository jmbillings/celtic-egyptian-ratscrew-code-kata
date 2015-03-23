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
            var result = snapRule.IsSnapValid(TestSnapRuleData.Empty());

            //ASSERT
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnsTrueIfThereIsOneRuleAndItReturnsTrue()
        {
            //ARRANGE
            var alwaysTrueRule = Substitute.For<ISnapRule>();
            alwaysTrueRule.IsSnapValid(Arg.Any<ISnapRuleData>()).Returns(true);
            var snapRule = new CompositeSnapRule(alwaysTrueRule);

            //ACT
            var result = snapRule.IsSnapValid(TestSnapRuleData.Empty());

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
            alwaysTrueRule.IsSnapValid(Arg.Any<ISnapRuleData>()).Returns(false);
            var snapRuleData = new TestSnapRuleData(cardStack);
            alwaysTrueRule.IsSnapValid(snapRuleData).Returns(true);

            var snapRule = new CompositeSnapRule(alwaysTrueRule);

            //ACT
            var result = snapRule.IsSnapValid(snapRuleData);

            //ASSERT
            Assert.IsTrue(result);
        }
    }
}
