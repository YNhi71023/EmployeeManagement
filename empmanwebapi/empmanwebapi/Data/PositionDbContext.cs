using empmanwebapi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace empmanwebapi.Data
{
    public class PositionDbContext:DbContext
    {
        public PositionDbContext(DbContextOptions<PositionDbContext> options) : base(options)
        {
        }
        public async Task<DataTable> GetAllPosition_()
        {
            var connectionString = Database.GetDbConnection().ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("[dbo].[PositionList]", connection))
                {
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> CreatePosition_(Position position)
        {
            var connectionString = Database.GetDbConnection().ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[Position.Create]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@position_code", position.position_code));
                    command.Parameters.Add(new SqlParameter("@position_name", position.position_name));
                    command.Parameters.Add(new SqlParameter("@employee_type_id", position.employee_type_id));

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }

        }

        public async Task<bool> DeletePosition_(int positionId)
        {
            var connectionString = Database.GetDbConnection().ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[DeletePosition]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@position_id", positionId));

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }
        }
    }
}
