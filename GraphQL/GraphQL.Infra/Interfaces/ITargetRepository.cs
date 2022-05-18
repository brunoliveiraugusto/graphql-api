using GraphQL.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GraphQL.Infra.Interfaces
{
    public interface ITargetRepository : IRepository<TargetHistory>
    {
        IEnumerable<TargetHistory> GetHistoryByDateRange(DateTime start, DateTime end);
    }
}
