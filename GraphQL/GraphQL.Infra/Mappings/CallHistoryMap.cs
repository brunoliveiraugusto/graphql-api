using GraphQL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Infra.Mappings
{
    public class CallHistoryMap : IEntityTypeConfiguration<CallHistory>
    {
        public void Configure(EntityTypeBuilder<CallHistory> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Sequence).IsRequired();
            builder.Property(p => p.Target).IsRequired();
            builder.Property(p => p.CallDate).IsRequired();
        }
    }
}
