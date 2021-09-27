using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Design;
using Elsa.Expressions;
using Elsa.Serialization;
using Elsa.Services;
using Elsa.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaDashboardTest.Activities
{
    [Trigger(
        Category = "Test",
        DisplayName = "User tesr ",
        Description = ""
        //, Outcomes = new[] { OutcomeNames.Done, "x => x.state.actions" }
        )]
    public class UserTaskActivity : Activity
    {
        private readonly IContentSerializer _serializer;
        public UserTaskActivity(IContentSerializer serializer)
        {
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        }


        [ActivityInput(
           UIHint = ActivityInputUIHints.MultiText,
           Label = "Укажите список действий для сотрудника",
           Hint = "Предоставьте список доступных действий",
           DefaultSyntax = SyntaxNames.Json,
           SupportedSyntaxes = new[] { SyntaxNames.Json }
           )]
        public ICollection<string> Actions { get; set; } = new List<string>();


        [ActivityInput(
           UIHint = ActivityInputUIHints.Dropdown,
           Label = "Select user type for user",
           DefaultSyntax = SyntaxNames.Literal,
           SupportedSyntaxes = new[] { SyntaxNames.Literal, SyntaxNames.JavaScript, SyntaxNames.Liquid }
           )]
        public string TaskType { get; set; }


        [ActivityOutput] public string? Output { get; set; }

        protected override bool OnCanExecute(ActivityExecutionContext context)
        {
            var userAction = (string)context.Input;
            return Actions.Contains(userAction, StringComparer.OrdinalIgnoreCase);
        }

        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context) => Suspend();

        protected override async ValueTask<IActivityExecutionResult> OnExecuteAsync(ActivityExecutionContext context)
        {
            return Suspend();
        }
        
        protected override IActivityExecutionResult OnResume(ActivityExecutionContext context)
        {
            var userAction = (string)context.Input;
            Output = userAction;
            return Outcome(userAction);        
        }


    }
}
