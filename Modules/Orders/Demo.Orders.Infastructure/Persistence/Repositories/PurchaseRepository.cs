using Demo.Orders.Domain.Entities;
using Demo.Orders.Domain.Interfaces.Repositories;
using DNH.Storage.EF;
using DNH.Storage.EF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Infastructure.Persistence.Repositories
{
    public class PurchaseRepository : EFRepository<PurchaseOrder>, IPurchaseRepository
    {
        public PurchaseRepository(EFDBContext dbContext) : base(dbContext)
        {

        }
    }
}
