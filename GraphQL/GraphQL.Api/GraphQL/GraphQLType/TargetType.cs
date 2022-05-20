using GraphQL.Application.ViewModels;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL.GraphQLType
{
    public class TargetType : ObjectGraphType<TargetViewModel>
    {
        public TargetType()
        {
            Field(x => x.Combination);
        }
    }
}
