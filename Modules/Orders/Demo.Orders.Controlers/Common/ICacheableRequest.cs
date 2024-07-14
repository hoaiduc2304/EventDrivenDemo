using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Orders.Application.Common
{
    public interface ICacheableRequest<TResponse> : IRequest<TResponse>
    {
        string CacheKey => string.Empty;
        MemoryCacheEntryOptions? Options { get; }
    }
}
