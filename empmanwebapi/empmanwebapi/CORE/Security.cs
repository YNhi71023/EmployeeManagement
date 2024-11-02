using empmanwebapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace empmanwebapi.CORE
{
    public class Security
    {


        public static string GenerateJwtToken(int employeeId, string employeeName, int employee_Typeid, int PositionId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("iKfolJLNwhnuMayeSPlgVoeJzPYWjCUb"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, employeeName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("employee_id", employeeId.ToString()),
                new Claim("employee_type_id", employee_Typeid.ToString()),
                new Claim("position_id", PositionId.ToString()),

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

    public class SercurityTokenAttribute : Attribute, IAsyncActionFilter
    {
      

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            if(context.HttpContext.Request.Headers.Authorization.Count() == 0)
            {
                ReponseModel r = new ReponseModel();
                r.message = "Not Found";
                r.status = "error";
                context.Result = new BadRequestObjectResult(r);
                return;
            }
            if (context.HttpContext.Request.Headers.TryGetValue("Authorization", out var _poten))
            {
                //if (_poten.ToString() == "" || _poten.ToString() == null)
                //{

                //}
                if (string.IsNullOrEmpty(_poten))
                {
                    ReponseModel r = new ReponseModel();
                    r.message = "Not Found Token";
                    r.status = "error";
                    context.Result = new BadRequestObjectResult(r);
                    return;
                }
            }
            await next();
        }
    }

}
