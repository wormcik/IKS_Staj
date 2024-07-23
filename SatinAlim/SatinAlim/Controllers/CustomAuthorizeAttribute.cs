using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using SatinAlim.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;

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

            // Extract the JWT token from the Authorization header
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            var token = authorizationHeader?.StartsWith("Bearer ") == true
                ? authorizationHeader.Substring("Bearer ".Length).Trim()
                : null;

            if (token == null)
            {
                // Token is missing
                context.Result = new UnauthorizedResult();
                return;
            }

            // Optional: Log or debug the token
            Console.WriteLine("JWT Token: " + token);

            // Decode the token and extract roles (if needed)
            var jwtHandler = new JwtSecurityTokenHandler();
            if (jwtHandler.CanReadToken(token))
            {
                var jwtToken = jwtHandler.ReadJwtToken(token);
                var userRoles = jwtToken.Claims
                                       .Where(c => c.Type == "role") // Ensure this matches the claim type in JWT
                                       .Select(c => c.Value)
                                       .ToList();

                // Log roles for debugging
                Console.WriteLine("User Roles: " + string.Join(", ", userRoles));

                if (!_roles.Any(role => userRoles.Contains(role)))
                {
                    // User does not have the required role
                    context.Result = new ForbidResult();
                }
            }
            else
            {
                // Token is invalid
                context.Result = new UnauthorizedResult();
            }
        }
        }




    public class JwtTokenService
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _key;

        public JwtTokenService(string issuer, string audience, string key)
        {
            _issuer = issuer;
            _audience = audience;
            _key = key;
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

