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
        public async Task<DataTable> FilterProvince_(int user_login, Province p)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[Province.GetList]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@province_code", p.province_code));
                    command.Parameters.Add(new SqlParameter("@province_name", p.province_name));
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }

        public async Task<DataTable> FilterDistrict_(int user_login, District d)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[District.GetList]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@province_code", d.province_code));
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> FilterWard_(int user_login, Ward w)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[Ward.GetList]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@district_code", w.district_code));
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
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
                    command.Parameters.Add(new SqlParameter("@location_id", l.location_id));
                    command.Parameters.Add(new SqlParameter("@location_code", l.location_code));
                    command.Parameters.Add(new SqlParameter("@location_name", l.location_name));
                    command.Parameters.Add(new SqlParameter("@location_address", l.location_address));
                    command.Parameters.Add(new SqlParameter("@ward_code", l.ward_code));
                    command.Parameters.Add(new SqlParameter("@district_code", l.district_code));
                    command.Parameters.Add(new SqlParameter("@province_code", l.province_code));
                    command.Parameters.Add(new SqlParameter("@location_type_id", l.location_type_id));
                    command.Parameters.Add(new SqlParameter("@employee_id", l.employee_id));
                    command.Parameters.Add(new SqlParameter("@status", l.status));
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> FilterLocationManager_(int user_login, LocationManagerFilter l)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[LocationManager.GetList]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@employee_id", l.employee_id));
                    command.Parameters.Add(new SqlParameter("@status", l.status));
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> CreateLocation_(int user_login, LocationCreate l)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[Location.Create]", connection))
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
                    command.Parameters.Add(new SqlParameter("@lat", l.lat));
                    command.Parameters.Add(new SqlParameter("@lng", l.lng));
                    command.Parameters.Add(new SqlParameter("@image_overview ", l.image_overview));
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
        public async Task<DataTable> CreateLocationManager_(int user_login, LocationManager l)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[LocationMan.Create]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@location_id", l.location_id));
                    command.Parameters.Add(new SqlParameter("@employee_id", l.employee_id));
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> UpdateLocation_(int user_login, LocationUpdate l)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[Location.Update]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@location_id", l.location_id));
                    command.Parameters.Add(new SqlParameter("@location_code", l.location_code));
                    command.Parameters.Add(new SqlParameter("@location_name", l.location_name));
                    command.Parameters.Add(new SqlParameter("@location_address", l.location_address));
                    command.Parameters.Add(new SqlParameter("@ward_code", l.ward_code));
                    command.Parameters.Add(new SqlParameter("@district_code", l.district_code));
                    command.Parameters.Add(new SqlParameter("@province_code", l.province_code));
                    command.Parameters.Add(new SqlParameter("@location_type_id", l.location_type_id));
                    command.Parameters.Add(new SqlParameter("@lat", l.lat));
                    command.Parameters.Add(new SqlParameter("@lng", l.lng));
                    command.Parameters.Add(new SqlParameter("@image_overview ", l.image_overview));
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
        public async Task<DataTable> DeleteLocationManager_(int user_login, LocationManagerDelete l)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[LocationManager.Delete]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@location_id", l.location_id));
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
