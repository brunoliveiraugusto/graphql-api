using GraphQL.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Application.Interfaces
{
    public interface ITargetService
    {
        Task<TargetViewModel> ProcessCombinationAsync(IEnumerable<int> sequence, int target);
    }
}
