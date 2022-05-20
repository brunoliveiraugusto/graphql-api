using GraphQL.Domain.Entities;
using GraphQL.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Infra.Context
{
    public class GraphQLContext : DbContext
    {
        public GraphQLContext(DbContextOptions<GraphQLContext> options) : base(options)
        {

        }

        public DbSet<TargetHistory> CallHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TargetHistoryMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("GraphQLDB");
            }
        }
    }
}
