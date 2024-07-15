using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Domain.Entities
{
    //[Table("purchaseorder")]
    public class PurchaseOrder: IEntity<Guid>
    {
        public Guid id { get; set; }
        public Guid customerid { get; set; }
        public string status { get; set; }
        public DateTime? orderdate { get; set; }
        public virtual List<PurchaseOrderLine> LineItems { get; set; } = new List<PurchaseOrderLine>();
        public DateTime? createdate { get; set; }

        #region relationship
        //public virtual Customer? customer { get; set; }

        public void AddLineItem(PurchaseOrderLine item)
        {
            LineItems.Add(item);
        }

        public decimal GetTotalAmount()
        {
            return LineItems.Sum(item => item.totalprice * item.quantity);
        }
        #endregion

    }
}
