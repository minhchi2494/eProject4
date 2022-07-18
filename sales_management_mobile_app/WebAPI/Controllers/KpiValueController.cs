using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAPI.Models;
using WebAPI.Repository;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KpiValueController : ControllerBase
    {
        private readonly IKpiValueServices _services;
        private readonly Project4Context _context;
        public KpiValueController(IKpiValueServices services, Project4Context context)
        {
            _services = services;
            _context = context;
        }

        [HttpPost("{dirId}/{kpiValue}")]
        public Task<bool> createValueKpi(string dirId, int kpiValue)
        {
            return _services.createKpiValue(dirId, kpiValue);
        }

        [HttpGet("KpiCurrentTime")]
        public int getKpiOfAllObj(string username)
        {
            List<AccountDTO> accountList = new List<AccountDTO>();//contain all of account in Dir, Man, User table

            List<Director> directorList = _context.Directors.ToList();
            foreach (Director director in directorList)//mapping data of Dir account to AccountDTO 
            {
                accountList.Add(new AccountDTO(director.Username, null, director.RoleId));
            }

            List<Manager> managerList = _context.Managers.ToList();
            foreach (Manager manager in managerList)//mapping data of Manager account to AccountDTO 
            {
                accountList.Add(new AccountDTO(manager.Username, null, manager.RoleId));
            }

            List<User> salepersonList = _context.Users.ToList();
            foreach (User saleperson in salepersonList)//mapping data of User account to AccountDTO 
            {
                accountList.Add(new AccountDTO(saleperson.Username, null, saleperson.RoleId));
            }
            foreach (AccountDTO acc in accountList)//get acutualKpi for username parameter
            {
                if (acc.Username.Equals(username))
                {
                    if (acc.RoleId == 1)
                    {
                        Director accChecked = _context.Directors.SingleOrDefault(d => d.Username.Equals(acc.Username));
                        return accChecked.ActualKpi;
                    }
                    else if (acc.RoleId == 2)
                    {
                        Manager accChecked = _context.Managers.SingleOrDefault(d => d.Username.Equals(acc.Username));
                        return accChecked.ActualKpi;
                    }
                    else
                    {
                        User accChecked = _context.Users.SingleOrDefault(d => d.Username.Equals(acc.Username));
                        return accChecked.ActualKpi;
                        
                    }
                }
            }
            return 0;
        }

        [HttpGet("KpiPerMonth")]
        public List<KpiPerMonth> getList(string userName)
        {
            List<KpiPerMonth> listOwnerUserName = new List<KpiPerMonth>();
            List<KpiPerMonth> list = _context.KpiPerMonths.ToList();
            foreach(KpiPerMonth item in list)
            {
                if (item.UserName.Equals(userName))
                {
                    listOwnerUserName.Add(item);
                }
            }
            return listOwnerUserName;
        }
    }
}
