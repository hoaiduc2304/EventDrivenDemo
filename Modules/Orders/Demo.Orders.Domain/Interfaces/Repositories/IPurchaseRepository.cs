﻿using Demo.Orders.Domain.Entities;
using DNH.Storage.EF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Domain.Interfaces.Repositories
{
    public interface IPurchaseRepository : IEFRepository<PurchaseOrder>
    {
    }
}
