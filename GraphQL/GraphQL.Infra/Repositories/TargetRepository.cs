using GraphQL.Domain.Entities;
using GraphQL.Infra.Context;
using GraphQL.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.Infra.Repositories
{
    public class TargetRepository : Repository<TargetHistory>, ITargetRepository
    {
        public TargetRepository(GraphQLContext context) : base(context) { }

        public IEnumerable<TargetHistory> GetHistoryByDateRange(DateTime start, DateTime end)
        {
            return DbSet.Where(targetHistory => targetHistory.Date.Date >= start && targetHistory.Date.Date <= end);
        }
    }
}
