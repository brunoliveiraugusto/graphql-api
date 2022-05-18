using System.Threading.Tasks;

namespace GraphQL.Infra.Interfaces
{
    public interface IRepository<TEntity>
    {
        public Task CreateAsync(TEntity entity);
    }
}
