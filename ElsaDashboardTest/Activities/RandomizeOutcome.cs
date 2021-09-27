using Elsa;
using Elsa.Attributes;
using Elsa.Design;
using Elsa.Expressions;
using Elsa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaDashboardTest.Activities
{
    [Action(Category = "Test",
        Outcomes = new[] { OutcomeNames.Done })]
    public class RandomizeOutcome : Activity
    {
        [ActivityInput(
             Hint = "Enter one or more outcome names.",
             UIHint = ActivityInputUIHints.MultiText,
             DefaultSyntax = SyntaxNames.Json,
             SupportedSyntaxes = new[] { SyntaxNames.Json },
             IsDesignerCritical = true
         )]
        public ISet<string> PossibleOutcomes { get; set; } = new HashSet<string>();
    }
}
