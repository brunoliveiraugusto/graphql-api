namespace GraphQL.Tests.Utils.Builders
{
    public abstract class BuilderBaseTest<M>
    {
        protected M Model;

        public M Build()
        {
            return Model;
        }
    }
}
