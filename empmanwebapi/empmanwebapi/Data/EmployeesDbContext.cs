﻿using empmanwebapi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using storeworkingapi.Models;
using System.Data;

namespace empmanwebapi.Data
{
    public class EmployeesDbContext:DbContext
    {
        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options) : base(options)
        {
        }
      
        public async Task<DataTable> GetAllEmployee_()
        {
            var connectionString = Database.GetDbConnection().ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("[dbo].[Employee_Getall]", connection))
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
        public async Task<DataTable> CreateEmployeeAsync_(int user_login, Employees employee)
        {
            var connectionString = Database.GetDbConnection().ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("[dbo].[Employee.Create]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@user_login", user_login));
                    command.Parameters.Add(new SqlParameter("@employee_name", employee.employee_name));
                    command.Parameters.Add(new SqlParameter("@sex", employee.sex));
                    command.Parameters.Add(new SqlParameter("@card_number", employee.card_number));
                    command.Parameters.Add(new SqlParameter("@address", employee.address));


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
