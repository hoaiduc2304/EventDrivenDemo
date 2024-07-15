using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Domain.Entities
{
    public class PurchaseOrderLine : IEntity<Guid>
    {
        public Guid id { get; set; }

        [Column("purchaseorderid")]
        public virtual Guid PurchaseOrderid { get; set; }
        
        public string item { get; set; }
        public int quantity { get; set; }
        public decimal totalprice { get; set; }

        #region relationship
        public virtual PurchaseOrder? PurchaseOrder { get; set; }
        #endregion
    }
}
