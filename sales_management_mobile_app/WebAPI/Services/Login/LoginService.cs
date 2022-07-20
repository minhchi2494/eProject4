using System;
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

        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int Generate(int min, int max)
        {
            return _random.Next(min, max);
        }

        public List<AccountDTO> getAllAccount()
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

            return accountList;
        }

        public object checkLogin(string username, string password)
        {
            foreach (AccountDTO acc in this.getAllAccount())
            {
                if (acc.Username.Equals(username))
                {
                    string pass = PinCodeSecurity.pinEncrypt(password);

                    if (acc.RoleId == 1)
                    {
                        Director accChecked = _context.Directors.SingleOrDefault(d => d.Username.Equals(acc.Username));
                        return accChecked;
                    }
                    if (acc.RoleId == 2)
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

            return null;
        }


        public bool checkAccountExist(string username)
        {
            //========= generate new password for user if request valid

            foreach (AccountDTO acc in this.getAllAccount())
            {
                if (acc.Username.Equals(username))
                {
                    return true;
                }
            }
            return false;
        }

        public string generatePassword(string username)
        {
            foreach (AccountDTO acc in this.getAllAccount())
            {
                if (acc.Username.Equals(username))
                {
                    string convertRandom = Convert.ToString(this.Generate(000000, 999999));
                    string passRandom = PinCodeSecurity.pinEncrypt(convertRandom);

                    if (acc.RoleId == 1)
                    {
                        Director accChecked = _context.Directors.SingleOrDefault(d => d.Username.Equals(acc.Username));
                        accChecked.Password = passRandom;
                        _context.SaveChanges();
                        return convertRandom;
                    }
                    if (acc.RoleId == 2)
                    {
                        Manager accChecked = _context.Managers.SingleOrDefault(d => d.Username.Equals(acc.Username));
                        accChecked.Password = passRandom;
                        _context.SaveChanges();
                        return convertRandom;
                    }
                    else
                    {
                        User accChecked = _context.Users.SingleOrDefault(d => d.Username.Equals(acc.Username));
                        accChecked.Password = passRandom;
                        _context.SaveChanges();
                        return convertRandom;
                    }

                }
            }
            return null;
        }
    }
}
