﻿using Microsoft.EntityFrameworkCore;
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
            var dir = _context.Directors.Include(x => x.Role).SingleOrDefault(a => a.Username.Equals(username));
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
            var dir = _context.Directors.Include(x => x.Role).ToList();

            if (!string.IsNullOrEmpty(searchDirector.Fullname))
            {
                dir = dir.Where(x => x.Fullname.ToLower().Contains(searchDirector.Fullname.ToLower())).ToList();
            }
            return dir;
        }

        public async Task<Director> getDirector(string id)
        {
            var dir = _context.Directors.Include(x => x.Role).SingleOrDefault(x => x.Id.Equals(id));
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
            var dir = _context.Directors.Include(x => x.Role).SingleOrDefault(x => x.Id.Equals(newDirector.Id));
            if (dir == null)
            {
                newDirector.Password = PinCodeSecurity.pinEncrypt(newDirector.Password);
                _context.Directors.Add(newDirector);
                _context.SaveChanges();
                return true;
                /*newDirector.ConfirmPassword = PinCodeSecurity.pinEncrypt(newDirector.ConfirmPassword);
                if (newDirector.Password.Equals(newDirector.ConfirmPassword))
                {
                    _context.Directors.Add(newDirector);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }*/

            }
            else
            {
                return false;
            }
        }


        public async Task<bool> updateDirector(string id, string oldPass, string Pass)
        {
            var model = _context.Directors.Include(x => x.Role).SingleOrDefault(x => x.Id.Equals(id));
            if (model != null)
            {
                var oldPassword = PinCodeSecurity.pinEncrypt(oldPass);
                var password = PinCodeSecurity.pinEncrypt(Pass);
                if (oldPassword.Equals(model.Password))
                {
                    model.Password = password;
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
    }
}
