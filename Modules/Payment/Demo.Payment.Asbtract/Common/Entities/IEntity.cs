﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Payment.Asbtract.Common.Entities
{
    public interface IEntity
    {
    }

    public interface IEntity<T> : IEntity
    {
        T id { get; set; }
    }
}
