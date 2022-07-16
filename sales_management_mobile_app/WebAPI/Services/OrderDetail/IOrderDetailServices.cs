using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IOrderDetailServices
    {
        Task<List<OrderDetail>> getOrderDetails();
        Task<bool> createActualQuantity(OrderDetail ssd);
        Task<OrderDetail> getOrderDetail(int id);
        Task<bool> createOrderDetail(OrderDetail ssd);
        
    }
}
