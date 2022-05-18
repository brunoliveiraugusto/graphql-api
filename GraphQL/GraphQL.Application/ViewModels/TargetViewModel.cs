using System.Collections.Generic;
using System.Linq;

namespace GraphQL.Application.ViewModels
{
    public class TargetViewModel
    {
        public IEnumerable<int> Combination
        {
            get => Combination.Sum(c => c) == Target ? Combination : new List<int>();
            set => Combination = value;
        }

        public int Target { get; set; }

        public static TargetViewModel NewTargetViewModel(IEnumerable<int> combination, int target) => new() 
        { 
            Combination = combination, Target = target 
        };
    }
}
