using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Security.Cryptography;
using Yetki.Entites;
using Yetki.Helpers;
using Yetki.Models;
using Yetki.Models.Enums;
using System.Text.RegularExpressions;
using System;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Azure.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Yetki.Services
{
    public class YetkiService
    {
        private readonly IConfiguration configuration;
        private readonly YetkiDbContext yetkiDbContext;

        public YetkiService(IConfiguration configuration,YetkiDbContext yetkiDbContext)
        {

            this.configuration = configuration;
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

                if (!IsStringPartOfEnum<UserTypeEnum>(registrationModel.UserType))
                {
                    return new ProcessResult<bool>().Failed("Invalid User Type.");
                }

                if (!IsPasswordEligible(registrationModel.Password))
                {
                    return new ProcessResult<bool>().Failed("Invalid Password.");
                }

                var user = new User();
                user.Username = registrationModel.Username;
                user.Name = registrationModel.Name;
                user.LastName = registrationModel.LastName;
                user.Password = ComputeSha256Hash(registrationModel.Password);
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

                if (user.Password != ComputeSha256Hash(signInModel.Password))
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
                new Claim(JwtRegisteredClaimNames.Jti, configuration["Appsettings:UniqueId"])
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signInModel.Password));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddMinutes(30);
            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expires, signingCredentials: creds);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }




        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {

                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString().ToUpper();
            }
        }


        static bool IsStringPartOfEnum<TEnum>(string value) where TEnum : struct
        {
            return Enum.TryParse(value, true, out TEnum _);
        }


        static bool IsPasswordEligible(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }
            string numberPattern = @"\d";
            if (Regex.Matches(password, numberPattern).Count < 1)
            {
                return false;
            }
            string specialCharPattern = @"[!@#$%^&*(),.?""':{}|<>\+\-]";
            if (!Regex.IsMatch(password, specialCharPattern))
            {
                return false;
            }

            return true;
        }


        public List<string> GetUserTypeRoles(string userType)
        {
                var results = yetkiDbContext.UserRoleType
                                     .Where(x => x.UserTypeName == userType)
                                     .Select(x => x.UserRoleName)
                                     .ToList();
                return results;
        }



        public List<string> GetUserRoles(string token)
        {
            /* var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
             string username = jwt.Claims.First(c => c.Type == "Username").Value;*/

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(token);

            string username = jwt.Claims.First(c => c.Type == "Sub").Value;

            var objUser = yetkiDbContext.User.FirstOrDefault(x => x.Username == username);

            return GetUserTypeRoles(objUser.UserType);
        }




        public List<string> GetUserRoles2(string token)
        {
            var secretKey = configuration["AppSettings:UniqueId"];
            var key = Encoding.UTF8.GetBytes(secretKey);

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero // Adjust if necessary
                };

                // Validate the JWT token
                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);

                // Extract username from claims
                var username = principal.Claims.First(c => c.Type == "Sub").Value;

                // Fetch user from the database
                var objUser = yetkiDbContext.User.FirstOrDefault(x => x.Username == username);

                if (objUser == null)
                {
                    throw new Exception("User not found.");
                }

                // Retrieve roles based on user type
                return GetUserTypeRoles(objUser.UserType);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception while validating token: {ex.Message}");
                return new List<string>();
            }
        }
    }
}
