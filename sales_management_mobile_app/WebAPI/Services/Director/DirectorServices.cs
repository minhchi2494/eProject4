using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class DirectorServices : IDirectorServices
    {
        private readonly Project4Context _context;

        public DirectorServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<Director> checkLogin(string username, string password)
        {
            var dir = _context.Directors.SingleOrDefault(a => a.Username.Equals(username));
            if (dir != null)
            {
                string pass = PinCodeSecurity.pinDecrypt(dir.Password);
                if (password.Equals(pass))
                {
                    return dir;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Director>> getDirectors(Director searchDirector)
        {
            var dir = _context.Directors.ToList();

            if (!string.IsNullOrEmpty(searchDirector.Fullname))
            {
                dir = dir.Where(x => x.Fullname.ToLower().Contains(searchDirector.Fullname.ToLower())).ToList();
            }
            return dir;
        }

        public async Task<Director> getDirector(string id)
        {
            var dir = _context.Directors.SingleOrDefault(x => x.Id.Equals(id));
            if (dir != null)
            {
                return dir;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> createDirector(Director newDirector)
        {
            var dir = _context.Directors.SingleOrDefault(x => x.Id.Equals(newDirector.Id));
            if (dir == null)
            {
                newDirector.Password = PinCodeSecurity.pinEncrypt(newDirector.Password);
                _context.Directors.Add(newDirector);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<bool> updateDirector(Director editDirector)
        {
            var model = _context.Directors.SingleOrDefault(x => x.Id.Equals(editDirector.Id));
            if (model != null)
            {
                model.Username = editDirector.Username;
                model.Password = PinCodeSecurity.pinEncrypt(editDirector.Password);
                model.Fullname = editDirector.Fullname;
                model.Email = editDirector.Email;
                model.Phone = editDirector.Phone;
                model.Address = editDirector.Address;
                model.KpiValue = editDirector.KpiValue;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> createKpiValue(string dirId, decimal kpiValue)
        {
            //kpiValue cho Director
            var director = _context.Directors.Include(x => x.Managers).SingleOrDefault(x => x.Id == dirId);
            director.KpiValue = kpiValue;
            _context.SaveChanges();

            //cập nhật kpiYear và kpiValue cho Manager dười quyền Director và Salesman dười sự quản lý của Manager đó
            var managers = _context.Managers.Include(x => x.Users).Where(x => x.DirectorId == dirId).ToList();
            int countManagers = managers.Where(x => x.DirectorId == dirId).Count();
            decimal kpiEachManager = kpiValue / countManagers;
            for (int i = 0; i < countManagers; i++)
            {
                managers[i].KpiValue = kpiEachManager;
                var userss = _context.Users.Include(x => x.Stores).Where(x => x.ManagerId == managers[i].Id).ToList();
                int countUser = userss.Where(x => x.ManagerId == managers[i].Id).Count();
                decimal kpiEachUser = kpiEachManager / countUser;
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
