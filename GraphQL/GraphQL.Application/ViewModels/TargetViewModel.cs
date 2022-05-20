using System.Collections.Generic;

namespace GraphQL.Application.ViewModels
{
    public class TargetViewModel
    {
        public IList<int> Combination { get; set; }

        public static TargetViewModel NewTarget(IList<int> combination) => new() { Combination = combination };
    }
}
