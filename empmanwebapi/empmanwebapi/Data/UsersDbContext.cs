
using empmanwebapi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace empmanwebapi.Data
{
    public class UsersDbContext: DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options):base(options) { }
        public async Task<DataTable> CreateUser(int user_login, CreateUserModel u)
        {
            var connectionString = Database.GetDbConnection().ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("[dbo].[User.Create]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@employee_id", u.employee_id));
                    command.Parameters.Add(new SqlParameter("@user_name", u.user_name));
                    command.Parameters.Add(new SqlParameter("@password", u.password));
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> LoginUser(LoginModel account)
        {
            var connectionString = Database.GetDbConnection().ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("[dbo].[LoginUser]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@username", account.username));
                    command.Parameters.Add(new SqlParameter("@password", account.password));


                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }
    }
}
