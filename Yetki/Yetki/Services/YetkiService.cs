using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Security.Cryptography;
using Yetki.Entites;
using Yetki.Helpers;
using Yetki.Models;

namespace Yetki.Services
{
    public class YetkiService
    {
        private readonly YetkiDbContext yetkiDbContext;

        public YetkiService(YetkiDbContext yetkiDbContext)
        {
            this.yetkiDbContext = yetkiDbContext;
        }

        public async Task<ProcessResult<bool>> SignUpAsync(RegistrationModel registrationModel)
        {

            try
            {
                var objUser = await yetkiDbContext.Users.FirstOrDefaultAsync(x => x.Username == registrationModel.Username);
                if (objUser != null)
                {
                    return new ProcessResult<bool>().Failed("User already exists in the database.");
                }
                var user = new User();
                user.Username = registrationModel.Username;
                user.Name = registrationModel.Name;
                user.LastName = registrationModel.LastName;
                user.Password = registrationModel.Password;
                user.UserType = registrationModel.UserType;
                user.RegistrationUserCode = Guid.NewGuid();
                user.ProcessCode = Guid.NewGuid();
                user.RegistrationDate = DateTime.Now;
                yetkiDbContext.Users.Add(user);

                    yetkiDbContext.SaveChanges();
                return new ProcessResult<bool>().Successful();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> SignInAsync(SignInModel signInModel)
        {
            try
            {
                var user = await yetkiDbContext.Users.FirstOrDefaultAsync(u => u.Username == signInModel.Username);
                if (user == null)
                {
                    return false;
                }

                if (user.Password != signInModel.Password)
                {
                    return false;
                }

                return true;
                // create jwt token
               // var resultJwt = JwtMaker(signInModel);



              //  return resultJwt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GenerateJwtToken(SignInModel signInModel)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            // var key = new Symmetric
        }

        //public string GenerateJwtToken(SignInModel signInModel)
        //{
        //    var claims = new[]
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, user.Username),
        //        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
        //    };

        //    // var key = new Symmetric
        //}

        //JwtMaker

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }


    }
}
