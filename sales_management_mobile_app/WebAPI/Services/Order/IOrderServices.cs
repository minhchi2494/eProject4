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

        Task<bool> saveOrder(string userId, string storeId, List<CartItem> orderList);

        Task<bool> setActualKPI(string userId);

        Task<string> getActualKpiFromSalePerson(string managerId);

        Task<string> getActualKpiFromManager(string dirId);
    }
}
