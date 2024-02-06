using Aplication.Common.Interfaces;
using Application.Common.Interfaces;
using Application.Common.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IDateTime _date;
        private readonly IConfiguration _configuration;
        private readonly IDataProtector _protector;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenService(
            IDateTime date,
            IConfiguration configuration,
            IDataProtectionProvider provider,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _date = date;
            _configuration = configuration;
            _protector = provider.CreateProtector(_configuration["Security:Encryption:Key"]);
            _httpContextAccessor = httpContextAccessor;
        }

        public string GenerarMainToken(IDictionary<string, string> datos)
        {
            var claims = new List<Claim>();

            foreach (var item in datos)
            {
                claims.Add(new Claim(item.Key, item.Value));
            }

            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Security:TokenKey").Value));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var expiration = _date.Now.AddMinutes(Convert.ToInt32(_configuration.GetSection("Security:TokenTime").Value));

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: _configuration.GetSection("Security:Dominio").Value,
               audience: _configuration.GetSection("Security:Dominio").Value,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IDictionary<string, string> ObtenerParametrosMainToken(IList<string> parametros, string token = null)
        {
            if(token == null)
                token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration.GetSection("Security:Dominio").Value,
                ValidAudience = _configuration.GetSection("Security:Dominio").Value,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Security:TokenKey").Value)),
                ClockSkew = TimeSpan.Zero
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            IDictionary<string, string> retorno = new Dictionary<string, string>();

            foreach(var item in parametros)
            {
                retorno.Add(item, principal.FindFirst(x => x.Type == item).Value);
            }

            return retorno;
        }

        public string ObtenerParametrosMainToken(string parametro, string token = null)
        {
            if (token == null)
                token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration.GetSection("Security:Dominio").Value,
                ValidAudience = _configuration.GetSection("Security:Dominio").Value,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Security:TokenKey").Value)),
                ClockSkew = TimeSpan.Zero
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal.FindFirst(x => x.Type == parametro).Value;
        }

        public string ObtenerMainToken()
        {
            return _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Substring("Bearer ".Length).Trim();
        }
    }
}
