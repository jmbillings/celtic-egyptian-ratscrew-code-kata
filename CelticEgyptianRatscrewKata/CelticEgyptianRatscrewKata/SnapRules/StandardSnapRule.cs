namespace CelticEgyptianRatscrewKata.SnapRules
{
    /// <summary>
    /// Represents a standard snap, i.e. any two adjacent cards have the same rank.
    /// </summary>
    public class StandardSnapRule : ISnapRule
    {
        public bool IsSnapValid(ISnapRuleData snapRuleData)
        {
            Rank? previous = null;
            foreach (var card in snapRuleData.Stack)
            {
                if (card.Rank == previous)
                {
                    return true;
                }
                previous = card.Rank;
            }
            return false;
        }
    }
}