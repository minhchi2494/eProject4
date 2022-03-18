using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface ITargetUserManagerServices
    {
        Task<List<vTargetUserManager>> getTargetUserManagers(DateTime? fromDate, DateTime? toDate);
    }
}
