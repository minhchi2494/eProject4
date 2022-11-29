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
                accountList.Add(new AccountDTO(director.Username, director.Password, director.Email, director.RoleId));
            }

            List<Manager> managerList = _context.Managers.ToList();
            foreach (Manager manager in managerList)//mapping data of Manager account to AccountDTO 
            {
                accountList.Add(new AccountDTO(manager.Username, manager.Password, manager.Email, manager.RoleId));
            }

            List<User> salepersonList = _context.Users.ToList();
            foreach (User saleperson in salepersonList)//mapping data of User account to AccountDTO 
            {
                accountList.Add(new AccountDTO(saleperson.Username, saleperson.Password, saleperson.Email, saleperson.RoleId));
            }
            return accountList;
        }

        public object checkLogin(string username, string password)
        {
            foreach (AccountDTO acc in this.getAllAccount())
            {
                if (acc.Username.Equals(username))
                {
                    if (acc.Password.Equals(PinCodeSecurity.pinEncrypt(password)))
                    {
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
            }

            return null;
        }


        public bool checkAccountExist(string username, string email)
        {
            //========= generate new password for user if request valid

            foreach (AccountDTO acc in this.getAllAccount())
            {
                if (acc.Username.Equals(username) && acc.Email.Equals(email))
                {
                    return true;
                }
            }
            return false;
        }

        public string generatePinCode(string username)
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
                        accChecked.PinCode = this.Generate(000000, 999999);
                        accChecked.Expired = DateTime.Now;
                        _context.SaveChanges();
                        return accChecked.PinCode.ToString();
                    }
                    if (acc.RoleId == 2)
                    {
                        Manager accChecked = _context.Managers.SingleOrDefault(d => d.Username.Equals(acc.Username));
                        accChecked.PinCode = this.Generate(000000, 999999);
                        accChecked.Expired = DateTime.Now;
                        _context.SaveChanges();
                        return accChecked.PinCode.ToString();
                    }
                    else
                    {
                        User accChecked = _context.Users.SingleOrDefault(d => d.Username.Equals(acc.Username));
                        accChecked.PinCode = this.Generate(000000, 999999);
                        accChecked.Expired = DateTime.Now;
                        _context.SaveChanges();
                        return accChecked.PinCode.ToString();
                    }

                }
            }
            return "PinCode has failure generate !!!.";
        }

        public string resetPassword(string username, int pinCode, string newPassword)
        {
            foreach (AccountDTO acc in this.getAllAccount())
            {
                if (acc.Username.Equals(username))
                {
                    if (acc.RoleId == 1)
                    {
                        Director accChecked = _context.Directors.SingleOrDefault(d => d.Username.Equals(acc.Username));
                        if (accChecked.PinCode == pinCode && accChecked.Expired.AddMinutes(5) > DateTime.Now)
                        {
                            accChecked.Password = PinCodeSecurity.pinEncrypt(newPassword);
                            _context.SaveChanges();
                            return "Password has change successfully !!!!.";
                        }
                        else
                        {
                            return "Pin Code expired !!!.";
                        }
                    }
                    if (acc.RoleId == 2)
                    {
                        Manager accChecked = _context.Managers.SingleOrDefault(d => d.Username.Equals(acc.Username));
                        if (accChecked.PinCode == pinCode && accChecked.Expired.AddMinutes(5) > DateTime.Now)
                        {
                            accChecked.Password = PinCodeSecurity.pinEncrypt(newPassword);
                            _context.SaveChanges();
                            return "Password has change successfully !!!!.";
                        }
                        else
                        {
                            return "Pin Code expired !!!.";
                        }
                    }
                    else
                    {
                        User accChecked = _context.Users.SingleOrDefault(d => d.Username.Equals(acc.Username));
                        if (accChecked.PinCode == pinCode && accChecked.Expired.AddMinutes(5) > DateTime.Now)
                        {
                            accChecked.Password = PinCodeSecurity.pinEncrypt(newPassword);
                            _context.SaveChanges();
                            return "Password has change successfully !!!!.";
                        }
                        else
                        {
                            return "Pin Code expired !!!.";
                        }
                    }
                }
            }
            return "Reset password failure";
        }

    }
}
