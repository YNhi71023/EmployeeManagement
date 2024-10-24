﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace empmanwebapi.CORE
{
    public class Security
    {


        public static string GenerateJwtToken(int employeeId, string employeeName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("iKfolJLNwhnuMayeSPlgVoeJzPYWjCUb"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, employeeName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("employee_id", employeeId.ToString())

            };

            var token = new JwtSecurityToken(
                issuer: "JwtIssuer",
                audience: "JwtAudience",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
