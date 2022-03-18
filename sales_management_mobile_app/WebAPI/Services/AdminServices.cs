using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Helpers;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class AdminServices : IAdminServices
    {
        //private readonly Project4Context _context;
        private  Project4Context _context;

        public AdminServices(Project4Context context)
        {
            _context = context;
           
        }

    


        public Admin getAdmin(int id)
        {
            // return _context.Admins.FirstOrDefault(x => x.Id == id);

            return _context.Admins.Find(id);
        }

        public IEnumerable<Admin> GetAll()
        {
            return _context.Admins;
        }


        public Admin Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var admin = _context.Admins.SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (admin == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, admin.PasswordHash, admin.PasswordSalt))
                    return null;

            // authentication successful
            return admin;
        }

        public Admin Create(Admin admin, string password)
        {
            
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.Admins.Any(x => x.Username == admin.Username))
                throw new AppException("Username \"" + admin.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            admin.PasswordHash = passwordHash;
            admin.PasswordSalt = passwordSalt;

            _context.Admins.Add(admin);
            _context.SaveChanges();

            return admin;
        }

        public void Update(Admin adminParam, string password = null)
        {
            var admin = _context.Admins.Find(adminParam.Id);

            if (admin == null)
                throw new AppException("User not found");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(adminParam.Username) && adminParam.Username != admin.Username)
            {
                // throw error if the new username is already taken
                if (_context.Admins.Any(x => x.Username == adminParam.Username))
                    throw new AppException("Username " + adminParam.Username + " is already taken");

                admin.Username = adminParam.Username;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(adminParam.Fullname))
                admin.Fullname = adminParam.Fullname;

            if (!string.IsNullOrWhiteSpace(adminParam.Phone))
                admin.Phone = adminParam.Phone;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);
                admin.PasswordHash = passwordHash;
                admin.PasswordSalt = passwordSalt;

            }

            _context.Admins.Update(admin);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var admin = _context.Admins.Find(id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
                _context.SaveChanges();
            }
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }




        //public AuthenticateResponse Authenticate(AuthenticateRequest model)
        //{
        //    var admin = _context.Admins.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

        //    // return null if user not found
        //    if (admin == null) return null;

        //    // authentication successful so generate jwt token
        //    var token = generateJwtToken(admin);

        //    return new AuthenticateResponse(admin, token);
        //}


        //public async Task<Admin> checkLogin(string username, string password)
        //{
        //    var model = _context.Admins.SingleOrDefault(a => a.Username.Equals(username));
        //    if (model != null)
        //    {
        //        string pass = PinCodeSecurity.pinDecrypt(model.Password);
        //        if (password.Equals(pass))
        //        {
        //            return model;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}



        //public async Task<List<Admin>> getAdmins()
        //{
        //    return _context.Admins.ToList();
        //}

        //public async Task<Admin> getAdmin(int id)
        //{
        //    var model = _context.Admins.SingleOrDefault(x=>x.Id.Equals(id));
        //    if (model != null)
        //    {
        //        return model;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public async Task<bool> createAdmin(Admin newAdmin)
        //{
        //    var model = _context.Admins.SingleOrDefault(x=>x.Id.Equals(newAdmin.Id));
        //    if (model == null)
        //    {
        //        newAdmin.Password = PinCodeSecurity.pinEncrypt(newAdmin.Password);
        //        _context.Admins.Add(newAdmin);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public async Task<bool> updateAdmin(Admin editAdmin)
        //{
        //    var model = _context.Admins.SingleOrDefault(x=>x.Id.Equals(editAdmin.Id));
        //    if (model != null)
        //    {
        //        model.Username = editAdmin.Username;
        //        model.Password = PinCodeSecurity.pinEncrypt(editAdmin.Password);
        //        model.Fullname = editAdmin.Fullname;
        //        model.Email = editAdmin.Email;
        //        model.Phone = editAdmin.Phone;
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}



        //private string generateJwtToken(Admin admin)
        //{
        //    // generate token that is valid for 7 days
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[] { new Claim("id", admin.Id.ToString()) }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}

    }
}
