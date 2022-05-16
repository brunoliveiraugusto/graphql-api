namespace GraphQL.Domain.Entities
{
    public class Entity<TEntity> where TEntity : Entity<TEntity>
    {
        public int Id { get; set; }
    }
}
