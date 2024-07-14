using DNH.Storage.EF.Paging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Payment.Asbtract.Common.Interfaces
{
    public interface IBaseServices<T, in ID> where T : class
    {
        Task<T> getbyIdAsync(ID id);
        Task<PagedResultDto<T>> PagingAsync(string filter = "");
        Task<T> SaveChangeAsync(T entity);
    }
}
