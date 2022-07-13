using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{

    public class LoginService
    {

        private readonly Project4Context _context;

        public LoginService(Project4Context context)
        {
            _context = context;
        }

        public object checkLogin(string username, string password)
        {
            List<AccountDTO> accountList = new List<AccountDTO>();//contain all of account in Dir, Man, User table

            List<Director> directorList = _context.Directors.ToList();
            foreach (Director director in directorList)//mapping data of Dir account to AccountDTO 
            {
                accountList.Add(new AccountDTO(director.Username, director.Password, director.RoleId));
            }

            List<Manager> managerList = _context.Managers.ToList();
            foreach (Manager manager in managerList)//mapping data of Manager account to AccountDTO 
            {
                accountList.Add(new AccountDTO(manager.Username, manager.Password, manager.RoleId));
            }

            List<User> salepersonList = _context.Users.ToList();
            foreach (User saleperson in salepersonList)//mapping data of User account to AccountDTO 
            {
                accountList.Add(new AccountDTO(saleperson.Username, saleperson.Password, saleperson.RoleId));
            }


            //===== checkLogin =======

            foreach(AccountDTO acc in accountList)
            {
                if (acc.Username.Equals(username))
                {
                    string pass = PinCodeSecurity.pinEncrypt(password);
                    if (acc.Password.Equals(pass))
                    {
                        if (acc.RoleId == 1)
                        {
                            Director accChecked = _context.Directors.SingleOrDefault(d => d.Username.Equals(acc.Username));
                            return accChecked;
                        }
                        if(acc.RoleId == 2)
                        {
                            Manager accChecked = _context.Managers.SingleOrDefault(d => d.Username.Equals(acc.Username));
                            return accChecked;
                        }
                        else
                        {
                            User accChecked = _context.Users.SingleOrDefault(d => d.Username.Equals(acc.Username));
                            return accChecked;
                        }
                    }
                }
            }

            return null;
        }


    }
}
