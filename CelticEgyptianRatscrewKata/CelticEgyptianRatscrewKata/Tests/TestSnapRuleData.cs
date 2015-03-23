using CelticEgyptianRatscrewKata.SnapRules;

namespace CelticEgyptianRatscrewKata.Tests
{
    class TestSnapRuleData : ISnapRuleData
    {
        public TestSnapRuleData(Cards stack, Card currentCallout = null)
        {
            Stack = stack;
            CurrentCallout = currentCallout;
        }

        public static ISnapRuleData Empty()
        {
            return new TestSnapRuleData(Cards.Empty());
        }

        public Cards Stack { get; private set; }
        public Card CurrentCallout { get; private set; }
    }
}
