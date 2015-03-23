namespace CelticEgyptianRatscrewKata.SnapRules
{
    /// <summary>
    /// Rule representing a sandwich somewhere in the stack.
    ///  A sandwich is where there are two cards of the same rank with exactly one other card of any rank between them, e.g. [1, 2, 1], [2, 1, 2], [1, 3, 1].
    /// </summary>
    public class SandwichSnapRule : ISnapRule
    {
        public bool IsSnapValid(ISnapRuleData snapRuleData)
        {
            Rank? previous = null;
            Rank? previousPrevious = null;
            foreach (var card in snapRuleData.Stack)
            {
                if (card.Rank == previousPrevious)
                {
                    return true;
                }
                previousPrevious = previous;
                previous = card.Rank;
            }
            return false;
        }
    }
}