
using Microsoft.EntityFrameworkCore;

namespace Demo.Orders.Infastructure.Persistence.Configurations
{
    public class PurchaseOrderLineConfiguration : EntityTypeConfiguration<PurchaseOrderLine>
    {
        public override void Configure(EntityTypeBuilder<PurchaseOrderLine> builder)
        {
            builder.ToTable("purchaseorderline");
            builder.HasKey(x => new { x.id });
            
        }
    }
}
