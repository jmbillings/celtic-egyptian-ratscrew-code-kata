namespace CelticEgyptianRatscrewKata.SnapRules
{
    public interface ISnapRuleData
    {
        Cards Stack { get; }
        Card CurrentCallout { get; }
    }
}