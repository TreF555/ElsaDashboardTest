using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Design;
using Elsa.Expressions;
using Elsa.Metadata;
using Elsa.Serialization;
using Elsa.Services;
using Elsa.Services.Models;
using ElsaDashboardTest.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace ElsaDashboardTest.Activities
{
    [Trigger(
       Category = "Test",
       DisplayName = "User test UserTaskActivityTest2 ",
       Description = "User test UserTaskActivityTest2 for Depends CheckList"
       )]
    public class UserTaskActivityTest2 : Activity
        , IActivityPropertyOptionsProvider
        , IRuntimeSelectListProvider
    {
        private readonly IContentSerializer _serializer;
        public UserTaskActivityTest2(IContentSerializer serializer)
        {
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        }

        /// <summary>
        /// Выбранное значение справочника
        /// </summary>        
        [ActivityInput(
            Hint = "Dictionary provider.",
            Label = "Dictionary provider",
            UIHint = ActivityInputUIHints.Dropdown,
            OptionsProvider = typeof(UserTaskActivityTest2),
            DefaultSyntax = SyntaxNames.Literal,
            SupportedSyntaxes = new[] { SyntaxNames.Literal, SyntaxNames.JavaScript, SyntaxNames.Liquid }
        )]
        public Guid DictionaryId { get; set; } = default!;


        [ActivityInput(
            UIHint = ActivityInputUIHints.Dropdown,
            Label = "Dictionary provider Dropdown",
            DefaultSyntax = SyntaxNames.Literal,
            OptionsProvider = typeof(UserTaskActivityTest2),
            SupportedSyntaxes = new[] { SyntaxNames.Literal, SyntaxNames.JavaScript, SyntaxNames.Liquid },
            DependsOnEvents = new[] { nameof(DictionaryId) },
            DependsOnValues = new[] { nameof(DictionaryId) }
        )]
        public string? DictionaryValueDropdown1 { get; set; }

        //[ActivityInput(
        //    UIHint = ActivityInputUIHints.Dropdown,
        //    Label = "Dictionary provider Dropdown",
        //    DefaultSyntax = SyntaxNames.Literal,
        //    OptionsProvider = typeof(UserTaskActivityTest2),
        //    SupportedSyntaxes = new[] { SyntaxNames.Literal, SyntaxNames.JavaScript, SyntaxNames.Liquid },
        //    DependsOnEvents = new[] { nameof(DictionaryId) },
        //    DependsOnValues = new[] { nameof(DictionaryId) }
        //)]
        //public string? DictionaryValueDropdown2 { get; set; }


        [ActivityInput(
            UIHint = ActivityInputUIHints.CheckList,
            Label = "Dictionary provider Dropdown CheckList",
            OptionsProvider = typeof(UserTaskActivityTest2),
            SupportedSyntaxes = new[] { SyntaxNames.Literal, SyntaxNames.JavaScript, SyntaxNames.Liquid },
            DependsOnEvents = new[] { nameof(DictionaryId) },
            DependsOnValues = new[] { nameof(DictionaryId) }
        )]
        public ICollection<string> DictionaryValueCheckList1 { get; set; } = new List<string>();


        public ValueTask<SelectList> GetSelectListAsync(object context = null, CancellationToken cancellationToken = default)
        {
            var cascadingDropDownContext = (CascadingDropDownContext)context!;
            var dependencyValues = cascadingDropDownContext.DepValues;
            switch (cascadingDropDownContext.Name)
            {
                case nameof(DictionaryId):
                    {
                        if (DictionaryId == Guid.Empty)
                        {
                            var items0 = new List<SelectListItem>();
                            items0.Add(new SelectListItem("DictionaryId1", "{1CCC760B-DC2A-4879-AF69-1FE469FF51D3}"));
                            items0.Add(new SelectListItem("DictionaryId2", "{2CCC760B-DC2A-4879-AF69-1FE469FF51D3}"));
                            items0.Add(new SelectListItem("DictionaryId3", "{3CCC760B-DC2A-4879-AF69-1FE469FF51D3}"));
                            items0.Add(new SelectListItem("DictionaryId4", "{4CCC760B-DC2A-4879-AF69-1FE469FF51D3}"));
                            items0.Add(new SelectListItem("DictionaryId5", "{5CCC760B-DC2A-4879-AF69-1FE469FF51D3}"));
                            return new ValueTask<SelectList>(new SelectList(items0));
                        }
                        break;
                    }
                case nameof(DictionaryValueDropdown1):
                    {
                        dependencyValues.TryGetValue(nameof(DictionaryId), out var dictionaryValue);
                        if (string.IsNullOrWhiteSpace(dictionaryValue) || dictionaryValue.ToGuid() ==Guid.Empty) return new ValueTask<SelectList>();

                        var items1 = new List<SelectListItem>()
                            {
                               new SelectListItem($"dd111{dictionaryValue}",  "{11CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                               new SelectListItem($"dd112{dictionaryValue}",  "{12CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                               new SelectListItem($"dd113{dictionaryValue}",  "{13CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                               new SelectListItem($"dd114{dictionaryValue}",  "{14CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                               new SelectListItem($"dd115{dictionaryValue}",  "{15CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                               new SelectListItem($"dd116{dictionaryValue}",  "{16CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                               new SelectListItem($"dd117{dictionaryValue}",  "{17CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                               new SelectListItem($"dd118{dictionaryValue}",  "{18CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                               new SelectListItem($"dd119{dictionaryValue}",  "{19CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                               new SelectListItem($"dd120{dictionaryValue}",  "{20CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                            };

                        return new ValueTask<SelectList>(new SelectList(items1));
                    }
                //case nameof(DictionaryValueDropdown2):
                //    {
                //        dependencyValues.TryGetValue(nameof(DictionaryId), out var dictionaryValue);
                //        if (string.IsNullOrWhiteSpace(dictionaryValue) || dictionaryValue.ToGuid() == Guid.Empty) return new ValueTask<SelectList>();
                //        var items2 = new List<SelectListItem>()
                //            {
                //               new SelectListItem($"dd211{dictionaryValue}",  "{21CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                //               new SelectListItem($"dd212{dictionaryValue}",  "{22CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                //               new SelectListItem($"dd213{dictionaryValue}",  "{23CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                //               new SelectListItem($"dd214{dictionaryValue}",  "{24CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                //               new SelectListItem($"dd215{dictionaryValue}",  "{25CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                //               new SelectListItem($"dd216{dictionaryValue}",  "{26CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                //               new SelectListItem($"dd217{dictionaryValue}",  "{27CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                //               new SelectListItem($"dd218{dictionaryValue}",  "{28CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                //               new SelectListItem($"dd219{dictionaryValue}",  "{29CC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                //               new SelectListItem($"dd220{dictionaryValue}",  "{220C760B-DC2A-4879-AF69-1FE469FF51D3}"),
                //            };

                //        return new ValueTask<SelectList>(new SelectList(items2));
                //    }
                case nameof(DictionaryValueCheckList1):
                    {
                        dependencyValues.TryGetValue(nameof(DictionaryId), out var dictionaryValue);
                        if (string.IsNullOrWhiteSpace(dictionaryValue) || dictionaryValue.ToGuid() == Guid.Empty) return new ValueTask<SelectList>();
                        var items3 = new List<SelectListItem>()
                            {
                               new SelectListItem($"CheckList111{dictionaryValue}",  "{11AC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                               new SelectListItem($"CheckList112{dictionaryValue}",  "{12AC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                               new SelectListItem($"CheckList113{dictionaryValue}",  "{13AC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                               new SelectListItem($"CheckList114{dictionaryValue}",  "{14AC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                               new SelectListItem($"CheckList115{dictionaryValue}",  "{15AC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                               new SelectListItem($"CheckList116{dictionaryValue}",  "{16AC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                               new SelectListItem($"CheckList117{dictionaryValue}",  "{17AC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                               new SelectListItem($"CheckList118{dictionaryValue}",  "{18AC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                               new SelectListItem($"CheckList119{dictionaryValue}",  "{19AC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                               new SelectListItem($"CheckList120{dictionaryValue}",  "{20AC760B-DC2A-4879-AF69-1FE469FF51D3}"),
                            };

                        return new ValueTask<SelectList>(new SelectList(items3));
                    }
            }
            return new ValueTask<SelectList>();
        }



        public object GetOptions(PropertyInfo property) => new RuntimeSelectListProviderSettings(GetType(),
           new CascadingDropDownContext(property.Name,
               property.GetCustomAttribute<ActivityInputAttribute>()!.DependsOnEvents!,
               property.GetCustomAttribute<ActivityInputAttribute>()!.DependsOnValues!,
               new Dictionary<string, string>(),
               new Test2Context(DictionaryId)));



        public record CascadingDropDownContext(string Name
           , string[] DependsOnEvent
           , string[] DependsOnValue
           , IDictionary<string, string> DepValues
           , Test2Context? Context);
        public record Test2Context(Guid DictionaryId);
    }
}
