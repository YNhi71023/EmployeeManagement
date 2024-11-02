using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace empmanwebapi.CORE
{
 
    public class APIController : ControllerBase
    {
        public int user_login
        {
            get
            {
                try
                {
                    string token = Request.Headers["Authorization"].ToString();
                    var handler = new JwtSecurityTokenHandler();
                    var jwtToken = handler.ReadToken(token.Replace("Bearer ", "")) as JwtSecurityToken;

                    if (jwtToken == null) return 0;
                    var employeeIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "employee_id");
                    if (employeeIdClaim != null && int.TryParse(employeeIdClaim.Value, out int user_login))
                    {
                        return user_login;
                    }

                    return 0;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            //get {
            //    try
            //    {
            //        string token = Request.Headers["Authorization"].ToString();
            //        var gentoken = new JwtSecurityTokenHandler();
            //        dynamic c = gentoken.ReadToken(token.Replace("Bearer ", ""));
            //        int user_login = Convert.ToInt32(c.Claims[2].Value);                   
            //        return user_login;
            //    }
            //    catch (Exception)
            //    {
            //        return 0;
            //    }

            //}
        }
        public int employee_type_id
        {
            get
            {
                try
                {
                    string token = Request.Headers["Authorization"].ToString();
                    var gentoken = new JwtSecurityTokenHandler();
                    dynamic c = gentoken.ReadToken(token.Replace("Bearer ", ""));

                    return Convert.ToInt32(c.Claims[3].Value);
                }
                catch (Exception)
                {

                    return 0;
                }

            }
        }
        public int position_id
        {
            get
            {
                try
                {
                    string token = Request.Headers["Authorization"].ToString();
                    var gentoken = new JwtSecurityTokenHandler();
                    dynamic c = gentoken.ReadToken(token.Replace("Bearer ", ""));
                    return Convert.ToInt32(c.Claims[4].Value);
                }
                catch (Exception)
                {

                    return 0;
                }

            }
        }

    }
}
