using GraphQL.Infra.Interfaces;
using Moq;

namespace GraphQL.Tests.Utils.Builders.Repository
{
    public class BuilderTargetRepositoryTest : BuilderBaseTest<Mock<ITargetRepository>>
    {
        public BuilderTargetRepositoryTest()
        {
            Model = new Mock<ITargetRepository>();
        }
    }
}
