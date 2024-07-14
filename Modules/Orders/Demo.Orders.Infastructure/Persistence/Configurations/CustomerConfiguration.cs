
namespace Demo.Orders.Infastructure.Persistence.Configurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer");
            builder.HasKey(x => new { x.id });
            builder.Property(t => t.CustomerName).HasMaxLength(50).IsRequired();
          //  builder.Ignore(e => e.DomainEvents);
        }
    }
}
