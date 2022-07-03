using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IOrderServices
    {
        Task<List<Order>> getOrders(DateTime? fromDate, DateTime? toDate);
        Task<Order> getOrder(int id);
    }
}
