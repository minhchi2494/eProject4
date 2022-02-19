using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IStoreSalesDetailServices
    {
        Task<List<StoreSalesDetail>> getStoreSalesDetails(StoreSalesDetail searchStoreSalesDetail, DateTime? fromDate, DateTime? toDate);
    }
}
