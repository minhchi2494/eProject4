using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface ITargetUserServices
    {
        Task<List<vTargetUser>> getTargetUsers(DateTime? fromDate, DateTime? toDate);
    }
}
