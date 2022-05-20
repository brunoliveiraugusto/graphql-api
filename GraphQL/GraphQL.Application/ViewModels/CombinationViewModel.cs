using System.Collections.Generic;

namespace GraphQL.Application.ViewModels
{
    public class CombinationViewModel
    {
        public IEnumerable<int> Sequence { get; set; }
        public int Target { get; set; }
    }
}
