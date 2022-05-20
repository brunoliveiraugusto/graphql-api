using GraphQL.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;

namespace GraphQL.Tests.Utils.Builders.Domain
{
    public class BuilderTargetHistoryTest : BuilderBaseTest<List<TargetHistory>>
    {
        public BuilderTargetHistoryTest()
        {
            Model = new List<TargetHistory>();
        }

        public List<TargetHistory> Historic()
        {
            Model = new List<TargetHistory>
            {
                new TargetHistory
                {
                    Id = 1,
                    Date = DateTime.Now.AddDays(-10),
                    Result = "[4, 4, 4]",
                    Sequence = "[1, 2, 3, 4]",
                    Target = 16
                },
                new TargetHistory
                {
                    Id = 2,
                    Date = DateTime.Now.AddDays(-15),
                    Result = "[6, 4]",
                    Sequence = "[12, 4, 6]",
                    Target = 10
                },
                new TargetHistory
                {
                    Id = 3,
                    Date = DateTime.Now,
                    Result = "[30]",
                    Sequence = "[100, 30, 20, 22]",
                    Target = 44
                }
            };

            return Model;
        }
    }
}
