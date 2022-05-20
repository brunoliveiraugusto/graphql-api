using GraphQL.Api.GraphQL.GraphQLQuery;
using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace GraphQL.Api.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<TargetQuery>();
        }
    }
}
