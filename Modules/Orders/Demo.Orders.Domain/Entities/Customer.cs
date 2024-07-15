using DNH.Storage.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Domain.Entities
{
    public class Customer:IEntity<Guid>
    {
        public Guid id { get; set; }
        public string CustomerName { get; set; }
    }
}
