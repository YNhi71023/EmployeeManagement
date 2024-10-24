using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace empmanwebapi.CORE
{
 
    public class APIController : ControllerBase
    {
        public int employee_id
        {
            get {
                try
                {
                    string token = Request.Headers["Authorization"].ToString();
                    var gentoken = new JwtSecurityTokenHandler();
                    dynamic c = gentoken.ReadToken(token.Replace("Bearer ", ""));
                    int employee_id = Convert.ToInt32(c.Claims[2].Value);
                    return employee_id;
                }
                catch (Exception)
                {

                    return 0;
                }
            
            }
        }

    }
}
