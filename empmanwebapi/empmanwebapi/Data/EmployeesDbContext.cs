using empmanwebapi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using storeworkingapi.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection;

namespace empmanwebapi.Data
{
    public class EmployeesDbContext : DbContext
    {
        private string connectionString = "";
        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options) : base(options)
        {
            connectionString  = Database.GetDbConnection().ConnectionString;
        }
       
        public async Task<DataTable> FilterEmployee_(EmployeeFilterModel em)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[Employee.GetList]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", em.user_login));
                    command.Parameters.Add(new SqlParameter("@employee_id", em.employee_id));
                    command.Parameters.Add(new SqlParameter("@employee_name", em.employee_name));
                    command.Parameters.Add(new SqlParameter("@sex", em.sex));
                    command.Parameters.Add(new SqlParameter("@card_number", em.card_number));
                    command.Parameters.Add(new SqlParameter("@type_id", em.employee_type_id));
                    command.Parameters.Add(new SqlParameter("@mail", em.mail));
                    command.Parameters.Add(new SqlParameter("@mobile", em.mobile));
                    command.Parameters.Add(new SqlParameter("@position_id", em.position_id));                   
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }


        public async Task<DataTable> FilterType_(TypeFilterModel t)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[Type.GetList]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", t.user_login));
                    command.Parameters.Add(new SqlParameter("@type_id", t.type_id));
                    command.Parameters.Add(new SqlParameter("@emp_type_code", t.type_code));
                    command.Parameters.Add(new SqlParameter("@emp_type_name", t.type_name));
                    command.Parameters.Add(new SqlParameter("@level", t.level));
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> FilterPosition_(PositionFilterModel p)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[Position.GetList]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", p.user_login));
                    command.Parameters.Add(new SqlParameter("@position_id", p.position_id));
                    command.Parameters.Add(new SqlParameter("@emp_position_code", p.position_code));
                    command.Parameters.Add(new SqlParameter("@emp_position_name", p.position_name));
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> CreateEmployee_(int user_login, EmployeeCreateModel e)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[Employee.Create]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@employee_name", e.employee_name));
                    command.Parameters.Add(new SqlParameter("@sex", e.sex));
                    command.Parameters.Add(new SqlParameter("@card_number", e.card_number));
                    command.Parameters.Add(new SqlParameter("@image_before_card", e.image_before_card));
                    command.Parameters.Add(new SqlParameter("@image_after_card", e.image_after_card));
                    command.Parameters.Add(new SqlParameter("@birthday", e.birthday));
                    command.Parameters.Add(new SqlParameter("@address", e.address));                  
                    command.Parameters.Add(new SqlParameter("@mail", e.mail));
                    command.Parameters.Add(new SqlParameter("@mobile", e.mobile));
                    command.Parameters.Add(new SqlParameter("@image_profile", e.image_profile));
                    command.Parameters.Add(new SqlParameter("@position_id", e.position_id));
                    command.Parameters.Add(new SqlParameter("@employee_type_id", e.employee_type_id));   
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }

        }
        public async Task<DataTable> CreateType_(int user_login, EmpTypeModel et)
        {
            using (var connection = new SqlConnection(connectionString)) 
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[Type.Create]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@emp_type_code", et.type_code));
                    command.Parameters.Add(new SqlParameter("@emp_type_name", et.type_name));
                    command.Parameters.Add(new SqlParameter("@level", et.level));
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> CreatePosition_(int user_login, EmpPositionModel et)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[Position.Create]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@emp_position_code", et.position_code));
                    command.Parameters.Add(new SqlParameter("@emp_position_name", et.position_name));
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }
        public async Task<int> UpdateEmployee_(int user_login, Employees e)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[Employee.Update]", connection))
                {
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@employee_name", e.employee_id));
                    command.Parameters.Add(new SqlParameter("@employee_name", e.employee_name));
                    command.Parameters.Add(new SqlParameter("@sex", e.sex));
                    command.Parameters.Add(new SqlParameter("@card_number", e.card_number));
                    command.Parameters.Add(new SqlParameter("@image_before_card", e.image_before_card));
                    command.Parameters.Add(new SqlParameter("@image_after_card", e.image_after_card));
                    command.Parameters.Add(new SqlParameter("@birthday", e.birthday));
                    command.Parameters.Add(new SqlParameter("@address", e.address));
                    command.Parameters.Add(new SqlParameter("@mail", e.mail));
                    command.Parameters.Add(new SqlParameter("@mobile", e.mobile));
                    command.Parameters.Add(new SqlParameter("@image_profile", e.image_profile));
                    command.Parameters.Add(new SqlParameter("@position_id", e.position_id));
                    command.Parameters.Add(new SqlParameter("@employee_type_id", e.employee_type_id));

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        return 1;
                    }
                }
            }
        }

        public async Task<DataTable> UpdateType_(int user_login, EmpTypes et)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[Type.Update]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@type_id", et.type_id));
                    command.Parameters.Add(new SqlParameter("@type_code", et.type_code));
                    command.Parameters.Add(new SqlParameter("@type_name", et.type_name));
                    command.Parameters.Add(new SqlParameter("@level", et.level));
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }
        public async Task<DataTable> UpdatePosition_(int user_login, EmpPosition ep)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[Position.Update]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@position_id", ep.position_id));
                    command.Parameters.Add(new SqlParameter("@position_code", ep.position_code));
                    command.Parameters.Add(new SqlParameter("@position_name", ep.position_name));
                    command.Parameters.Add(new SqlParameter("@status",ep.status));
                    using (var adapter = new SqlDataAdapter(command))
                    {

                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                       
                    }
                }
            }
        }
        public async Task<DataTable> DeleteType_(int user_login, EmpTypeDelete ep)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[Type.Delete]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@typen_id", ep.type_id));
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;

                    }
                }
            }
        }
        public async Task<DataTable> DeletePosition_(int user_login, EmpPositionDelete ep)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("[dbo].[Position.Delete]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@position_id", ep.position_id));
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
