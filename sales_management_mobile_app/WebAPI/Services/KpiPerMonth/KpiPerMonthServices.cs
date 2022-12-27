using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;
using System.Timers;

namespace WebAPI.Services
{
    public class KpiPerMonthServices
    {
        private readonly Project4Context _context;

        public KpiPerMonthServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<KpiPerMonth>> getKpiPerMonths(string username)
        {
            var result = _context.KpiPerMonths.Where(x => x.UserName.Equals(username)).ToList();
            return result;
        }

        public async Task<List<KpiPerMonth>> getAll()
        {
            var result = _context.KpiPerMonths.ToList();
            return result;
        }

        public bool saveKpiPerMonth()
        {
            DateTime nowTime = DateTime.Now;
            DateTime scheduledTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day);
            if (nowTime.Month > scheduledTime.Month)
            {
                scheduledTime = scheduledTime.AddMonths(1);//run once every month
                List<Director> directorList = _context.Directors.ToList();

                foreach (Director director in directorList)
                {

                    int lastMonth = nowTime.Month - 1;
                    KpiPerMonth kpm = new KpiPerMonth(lastMonth, director.ActualKpi, director.Username);// save last month KPI
                    _context.KpiPerMonths.Add(kpm);
                    director.ActualKpi = 0;//reset ActualKpi on last month to save value of current month
                    _context.SaveChanges();
                }

                List<Manager> managerList = _context.Managers.ToList();
                foreach (Manager manager in managerList)
                {
                    int lastMonth = nowTime.Month - 1;
                    KpiPerMonth kpm = new KpiPerMonth(lastMonth, manager.ActualKpi, manager.Username);// save last month KPI
                    _context.KpiPerMonths.Add(kpm);
                    manager.ActualKpi = 0;//reset ActualKpi on last month to save value of current month
                    _context.SaveChanges();
                }

                List<User> salepersonList = _context.Users.ToList();
                foreach (User saleperson in salepersonList)
                {
                    int lastMonth = nowTime.Month - 1;
                    KpiPerMonth kpm = new KpiPerMonth(lastMonth, saleperson.ActualKpi, saleperson.Username);// save last month KPI
                    _context.KpiPerMonths.Add(kpm);
                    saleperson.ActualKpi = 0;//reset ActualKpi on last month to save value of current month
                    _context.SaveChanges();
                }
                return true;
            }
            
            return false;
        }


    }
}
