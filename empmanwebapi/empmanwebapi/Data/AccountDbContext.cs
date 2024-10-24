
using empmanwebapi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace empmanwebapi.Data
{
    public class AccountDbContext: DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options):base(options) { }
        public async Task<DataTable> RegisterAccountAsync_(RegisterModel account)
        {
            var connectionString = Database.GetDbConnection().ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("[dbo].[RegisterAccount]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@username", account.username));
                    command.Parameters.Add(new SqlParameter("@password", account.password));
                    command.Parameters.Add(new SqlParameter("@account_type", account.role));

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> LoginAccount_(LoginModel account)
        {
            var connectionString = Database.GetDbConnection().ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("[dbo].[LoginAccount]", connection))
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
