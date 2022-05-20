using GraphQL.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Application.Interfaces
{
    public interface ITargetService
    {
        Task<IEnumerable<int>> ProcessCombinationAsync(CombinationViewModel combination);
        IEnumerable<TargetHistoryViewModel> GetHistoryByDateRange(DateTime start, DateTime end);
    }
}
