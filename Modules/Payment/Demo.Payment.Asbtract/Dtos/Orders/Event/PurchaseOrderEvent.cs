﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Payment.Asbtract.Common.Events;
using Newtonsoft.Json.Linq;
namespace Demo.Payment.Asbtract.Dtos.Orders.Event
{
    public class PurchaseOrderSagaEvent
    {
        public Guid OrderId { get; set; }
        public Guid customerid { get; set; }
        public string status { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
