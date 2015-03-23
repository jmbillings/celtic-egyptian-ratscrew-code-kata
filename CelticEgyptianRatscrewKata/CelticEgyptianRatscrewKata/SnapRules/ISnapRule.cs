namespace CelticEgyptianRatscrewKata.SnapRules
{
    /// <summary>
    /// Represents a rule for a snap on a stack.
    /// </summary>
    public interface ISnapRule
    {
        /// <summary>
        /// Checks whether a snap is valid on the <paramref name="snapRuleData"/>.
        /// </summary>
        bool IsSnapValid(ISnapRuleData snapRuleData);
    }
}