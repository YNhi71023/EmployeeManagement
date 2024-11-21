using empmanwebapi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using storeworkingapi.Models;
using System.Data;

namespace empmanwebapi.Data
{
    public class StoreDbContext:DbContext
    {
        private string connectionString = "";
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
            connectionString = Database.GetDbConnection().ConnectionString;
        }
        public async Task<DataTable> FilterLocationType_(int user_login, LocationType l)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[LocationType.GetList]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@location_type_code", l.location_type_code));
                    command.Parameters.Add(new SqlParameter("@location_type_name", l.location_type_name));
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> FilterLocation_(int user_login, LocationFilter l)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[Location.GetList]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@location_code", l.location_code));
                    command.Parameters.Add(new SqlParameter("@location_name", l.location_name));
                    command.Parameters.Add(new SqlParameter("@location_address", l.location_address));
                    command.Parameters.Add(new SqlParameter("@ward_code", l.ward_code));
                    command.Parameters.Add(new SqlParameter("@district_code", l.district_code));
                    command.Parameters.Add(new SqlParameter("@province_code", l.province_code));
                    command.Parameters.Add(new SqlParameter("@location_type_id", l.location_type_id));
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> CreateLocationType_(int user_login, LocationType l)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[LocationType.Create]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@location_type_code", l.location_type_code));
                    command.Parameters.Add(new SqlParameter("@location_type_name", l.location_type_name));
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> UpdateLocationType_(int user_login, LocationTypeUpdate l)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[LocationType.Update]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@location_type_id", l.location_type_id));
                    command.Parameters.Add(new SqlParameter("@location_type_code", l.location_type_code));
                    command.Parameters.Add(new SqlParameter("@location_type_name", l.location_type_name));
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
