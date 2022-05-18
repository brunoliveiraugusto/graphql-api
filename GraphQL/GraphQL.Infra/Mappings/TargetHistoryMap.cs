using GraphQL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Infra.Mappings
{
    public class TargetHistoryMap : IEntityTypeConfiguration<TargetHistory>
    {
        public void Configure(EntityTypeBuilder<TargetHistory> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Sequence).IsRequired();
            builder.Property(p => p.Target).IsRequired();
            builder.Property(p => p.Date).IsRequired();
        }
    }
}
