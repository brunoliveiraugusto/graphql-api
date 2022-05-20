using AutoMapper;
using GraphQL.Application.AutoMapper;

namespace GraphQL.Tests.Utils.Builders.Mapper
{
    public class BuilderMapperTest : BuilderBaseTest<IMapper>
    {
        public BuilderMapperTest()
        {
            var configuration = new MapperConfiguration(x =>
            {
                x.AddProfile(new EntitieToViewModel());
                x.AllowNullCollections = true;
                x.AllowNullDestinationValues = true;
                x.ValidateInlineMaps = false;
            });

            Model = configuration.CreateMapper();
        }
    }
}
