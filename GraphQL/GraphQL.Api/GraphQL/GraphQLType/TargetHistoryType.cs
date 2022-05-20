using GraphQL.Application.ViewModels;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL.GraphQLType
{
    public class TargetHistoryType : ObjectGraphType<TargetHistoryViewModel>
    {
        public TargetHistoryType()
        {
            Field(x => x.Id, type: typeof(IntGraphType));
            Field(x => x.Sequence, type: typeof(StringGraphType));
            Field(x => x.Date, type: typeof(StringGraphType));
            Field(x => x.Result, type: typeof(StringGraphType));
            Field(x => x.Target, type: typeof(IntGraphType));
        }
    }
}
