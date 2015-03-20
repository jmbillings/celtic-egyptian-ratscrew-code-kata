using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata.SnapRules
{
    /// <summary>
    /// Aggregates snap rules to see if any are true.
    /// </summary>
    public class CompositeSnapRule : ISnapRule
    {
        private readonly IEnumerable<ISnapRule> _rules;

        /// <summary>
        /// Create snap validator that will check against all the given <paramref name="rules"/>
        /// </summary>
        public CompositeSnapRule(params ISnapRule[] rules)
        {
            _rules = rules;
        }

        public bool IsSnapValid(Cards cardStack)
        {
            return _rules.Any(r => r.IsSnapValid(cardStack));
        }
    }
}