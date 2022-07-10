using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class KpiValueServices : IKpiValueServices
    {
        private readonly Project4Context _context;

        public KpiValueServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<bool> createKpiValue(string dirId, int kpiValue)
        {
            //kpiValue cho Director
            var director = _context.Directors.Include(x => x.Managers).SingleOrDefault(x => x.Id == dirId);
            director.KpiValue = kpiValue;
            _context.SaveChanges();

            //cập nhật kpiYear và kpiValue cho Manager dười quyền Director và Salesman dười sự quản lý của Manager đó
            var managers = _context.Managers.Include(x => x.Users).Where(x => x.DirectorId == dirId).ToList();
            int countManagers = managers.Where(x => x.DirectorId == dirId).Count();
            int kpiEachManager = kpiValue / countManagers;
            for (int i = 0; i < countManagers; i++)
            {
                managers[i].KpiValue = kpiEachManager;
                var userss = _context.Users.Include(x => x.Stores).Where(x => x.ManagerId == managers[i].Id).ToList();
                int countUser = userss.Where(x => x.ManagerId == managers[i].Id).Count();
                int kpiEachUser = kpiEachManager / countUser;
                for (int j = 0; j < countUser; j++)
                {
                    userss[j].KpiValue = kpiEachUser;
                }
            }
            _context.SaveChanges();
            return true;
        }
    }
}
