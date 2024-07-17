using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Security.Cryptography;
using Yetki.Entites;
using Yetki.Helpers;
using Yetki.Models;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Azure.Identity;

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
                var objUser = await yetkiDbContext.User.FirstOrDefaultAsync(x => x.Username == registrationModel.Username);
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
                yetkiDbContext.User.Add(user);

                    yetkiDbContext.SaveChanges();
                return new ProcessResult<bool>().Successful();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ProcessResult<string>> SignInAsync(SignInModel signInModel)
        {
            try
            {
                var user = await yetkiDbContext.User.FirstOrDefaultAsync(u => u.Username == signInModel.Username);
                if (user == null)
                {
                    return new ProcessResult<string>().Failed("No user with this username");
                }

                if (user.Password != signInModel.Password)
                {
                    return new ProcessResult<string>().Failed("No user with this username and password");
                }

                

                var resultJwt = GenerateJwtToken(signInModel);


                return new ProcessResult<string>().Successful(resultJwt);

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
                new Claim(JwtRegisteredClaimNames.Sub, signInModel.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signInModel.Password));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddMinutes(30);



            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expires, signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
