
namespace Demo.Orders.Infastructure.Persistence.Configurations
{
    public class PurchaseOrderConfiguration : EntityTypeConfiguration<PurchaseOrder>
    {
        public override void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            builder.ToTable("purchaseorder");
            builder.HasKey(x => new { x.id});
           // builder.HasOne(x => x.customer).WithMany().HasForeignKey(x => x.customerid).OnDelete(DeleteBehavior.SetNull);
            // Configure the relationship with PurchaseOrderLine
            builder.HasMany(x => x.LineItems)
                   .WithOne(x => x.PurchaseOrder)
                   .HasForeignKey(x => x.PurchaseOrderid)
                   .OnDelete(DeleteBehavior.Cascade);
            // Add additional configurations here if needed
           // builder.Ignore(x => x.customer);
            base.Configure(builder);
        }
    }
}
