using GraphQL.Api.GraphQL.GraphQLType;
using GraphQL.Application.Interfaces;
using GraphQL.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GraphQL.Api.GraphQL.GraphQLQuery
{
    public class TargetQuery : ObjectGraphType
    {
        public TargetQuery(ITargetService service)
        {
            Field<TargetType>(
                "combinations",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "sequence" },
                    new QueryArgument<IntGraphType> { Name = "target" }
                ),
                resolve: context =>
                {
                    List<int> sequence = JsonConvert.DeserializeObject<List<int>>(context.GetArgument<string>("sequence"));
                    int target = context.GetArgument<int>("target");

                    return service.ProcessCombinationAsync(sequence, target);
                }
            );

            Field<ListGraphType<TargetHistoryType>>(
                "historyCall",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "start" },
                    new QueryArgument<StringGraphType> { Name = "end" }
                ),
                resolve: context =>
                {
                    DateTime start = DateTime.Parse(context.GetArgument<string>("start"));
                    DateTime end = DateTime.Parse(context.GetArgument<string>("end"));

                    return service.GetHistoryByDateRange(start, end);
                }
            );
        }
    }
}
