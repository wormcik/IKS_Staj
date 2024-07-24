using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using SatinAlim.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;

namespace SatinAlim.Controllers
{
        public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
        {
            private readonly string[] _roles;

            public CustomAuthorizeAttribute(params string[] roles)
            {
                _roles = roles;
            }

            public void OnAuthorization(AuthorizationFilterContext context)
            {
            var user = context.HttpContext.User;

            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            var token = authorizationHeader?.StartsWith("Bearer ") == true
                ? authorizationHeader.Substring("Bearer ".Length).Trim()
                : null;

            if (token == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            Console.WriteLine("JWT Token: " + token);

            var jwtHandler = new JwtSecurityTokenHandler();

            if (jwtHandler.CanReadToken(token))
            {
                var jwtToken = jwtHandler.ReadJwtToken(token);

                var expClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp);
                if (expClaim == null)
                {
                    throw new ArgumentException("The token does not contain an 'exp' claim.");
                }

                var expValue = long.Parse(expClaim.Value);
                var expirationTime = DateTimeOffset.FromUnixTimeSeconds(expValue);

                if(expirationTime < DateTimeOffset.UtcNow)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                var userRoles = jwtToken.Claims
                                       .Where(c => c.Type == "role") 
                                       .Select(c => c.Value)
                                       .ToList();

                Console.WriteLine("User Roles: " + string.Join(", ", userRoles));

                if (!_roles.Any(role => userRoles.Contains(role)))
                {
                    context.Result = new ForbidResult();
                }

                var userGuidClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "KullaniciKod");

                if (userGuidClaim == null)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                var userGuid = userGuidClaim.Value;
            }
            else
            {
                context.Result = new UnauthorizedResult();
            }
        }
        }




    public class JwtTokenService
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _key;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public JwtTokenService(string issuer, string audience, string key, IHttpContextAccessor httpContextAccessor,IConfiguration configuration)
        {
            _issuer = issuer;
            _audience = audience;
            _key = key;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public string GenerateToken(string username, string[] roles)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        }.Union(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)), SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }

}

