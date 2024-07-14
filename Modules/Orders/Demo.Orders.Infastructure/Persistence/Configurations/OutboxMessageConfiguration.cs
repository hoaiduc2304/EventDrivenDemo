
namespace Demo.Orders.Infastructure.Persistence.Configurations
{
    public class OutboxMessageConfiguration : EntityTypeConfiguration<OutboxMessage>
    {
        public override void Configure(EntityTypeBuilder<OutboxMessage> builder)
        {
            builder.ToTable("outboxmessage");
            builder.HasKey(x => new { x.id });
            //  builder.Ignore(e => e.DomainEvents);
        }
    }
}
