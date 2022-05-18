using GraphQL.Domain.Entities;
using GraphQL.Infra.Context;
using GraphQL.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GraphQL.Infra.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected GraphQLContext Context;
        protected DbSet<TEntity> DbSet;

        public Repository(GraphQLContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await Context.SaveChangesAsync();
        }
    }
}
