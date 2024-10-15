using Dapper;
using empmanwebapi.Models;

namespace empmanwebapi.Repository
{
    public interface IJWTAuthManager
    {
        Response<string> GenerateJWT(Users user);
        Response<T> Execute_Command<T>(string query, DynamicParameters sp_params);
        Response<List<T>> getUserList<T>();
        
    }
}
