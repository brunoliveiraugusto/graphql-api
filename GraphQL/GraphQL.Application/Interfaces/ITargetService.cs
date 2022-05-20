using GraphQL.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Application.Interfaces
{
    public interface ITargetService
    {
        Task<TargetViewModel> ProcessCombinationAsync(IEnumerable<int> Sequence, int target);
        IEnumerable<TargetHistoryViewModel> GetHistoryByDateRange(DateTime start, DateTime end);
    }
}
