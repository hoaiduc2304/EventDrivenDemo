using Demo.Payment.Asbtract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Payment.Repositories.Persistence.Configs
{
    public class PaymentTransactionConfig : EntityTypeConfiguration<PaymentTransaction>
    {

        public override void Configure(EntityTypeBuilder<PaymentTransaction> builder)
        {
            builder.ToTable("paymenttransaction");
            builder.HasKey(x => new { x.id });
        }
    }
}
