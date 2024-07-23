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
using Microsoft.Extensions.Configuration;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Security.Principal;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Data;
using System.Net.Http.Json;
using Microsoft.OpenApi.Validations;

namespace Yetki.Services
{
    public class YetkiService
    {
        private readonly IConfiguration configuration;
        private readonly YetkiDbContext yetkiDbContext;
        private readonly string uniqueId;

        public YetkiService(YetkiDbContext yetkiDbContext, IConfiguration configuration)
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

                /*if (!IsPasswordEligible(registrationModel.Password))
                {
                    return new ProcessResult<bool>().Failed("Invalid Password.");
                }*/

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

                var roles = GetUserTypeRoles(user.UserType);


                var resultJwt = GenerateJwtToken(signInModel, roles);


                return new ProcessResult<string>().Successful(resultJwt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string GenerateJwtToken(SignInModel signInModel, List<string> roles)
        {
            var uniqueId = configuration["AppSettings:UniqueId"]; // Ensure this is long enough
                                                                  // var roles = new List<string> { "sat�n�ekmeyetki", "sat�nvermeyetki", "sat�nalmayetki" }; // Example roles
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, signInModel.Username),
               //new Claim("roles", JsonConvert.SerializeObject(roles)) //////////////////////
            };

            // Add roles to claims
            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role));
            }

            // Use UniqueId as signing key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(uniqueId));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddMinutes(30);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

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

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(token);

            List<string> roles = new List<string>();
            foreach (var claim in jwt.Claims.Where(c => c.Type == ClaimTypes.Role))
            {
                roles.Add(claim.Value);
            }

            return roles;
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
                    ClockSkew = TimeSpan.Zero
                };

                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);

                var userRoles = principal.Claims
                                    .Where(c => c.Type == ClaimTypes.Role)
                                    .Select(c => c.Value)
                                    .ToList();

                if (userRoles == null)
                {
                    throw new Exception("User not found.");
                }

                return userRoles;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception while validating token: {ex.Message}");
                throw ex;
            }
        }
    }
}
