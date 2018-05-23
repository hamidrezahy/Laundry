using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Laundry.Data.Models;
using Laundry.Data;
using System.Linq;
using System.Linq.Expressions;
using Laundry.Service.SqlServer.Tools;
using Laundry.Data.Models.Employee;

namespace Laundry.Service.SqlServer
{
    public class EmployeeService : IEmployee
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataSet dataSet;

        DBTools dBTools;

        /// <param name="connectionString">Database connection string</param>
        public EmployeeService(string connectionString)
        {
            sqlConnection = new SqlConnection();
            sqlCommand = new SqlCommand();
            sqlDataAdapter = new SqlDataAdapter();
            dataSet = new DataSet();

            dBTools = new DBTools(connectionString);

            sqlConnection.ConnectionString = connectionString;
        }

        /// <summary>
        /// Add an employee to database
        /// </summary>
        public bool Add(EmployeeModel employee)
        {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "INSERT INTO Employee (E_FirstName, E_LastName, E_Phone, E_NCode, E_Email, E_Salary, E_EmergencyPhone, E_Gender, [E_State], E_City, E_Street, E_Other) VALUES (@FirstName, @LastName, @E_NCode, @Phone, @Email, @Salary, @EmergencyPhone, @Gender, @State, @City, @Street, @Other)";
            sqlCommand.Parameters.AddWithValue("@FirstName", employee.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", employee.LastName);
            sqlCommand.Parameters.AddWithValue("@Phone", employee.Phone);
            sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
            sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
            sqlCommand.Parameters.AddWithValue("@E_NCode", employee.NationalCode);
            sqlCommand.Parameters.AddWithValue("@EmergencyPhone", employee.EmergencyPhone);
            sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
            sqlCommand.Parameters.AddWithValue("@State", employee.State);
            sqlCommand.Parameters.AddWithValue("@City", employee.City);
            sqlCommand.Parameters.AddWithValue("@Street", employee.Street);
            sqlCommand.Parameters.AddWithValue("@Other", employee.Other);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }

            // TODO: (SqlException e) 
            catch (SqlException e)
            {
                // do something with the exception
                return false;
            }

        }

        // public Employee Edit(int id, Employee employee)
        // {
        //     throw new NotImplementedException();
        // }

        /// <summary>
        /// Get employee from ID
        /// </summary>
        public EmployeeDetailModel Get(string id)
        {
            DataSet dataSet = GetSelectQuery("execute dbo.GetEmployeeByNCode " + id + ";");

            if (dataSet.Tables[0].Rows.Count > 0)
                return GetEmployeeByNCode(dataSet.Tables[0].Rows[0], id);

            return null;


        }

        private EmployeeDetailModel GetEmployeeByNCode(DataRow row, string id) => new EmployeeDetailModel
        {
            FirstName = (string)row["E_FullName"],
            LastName = (string)row["E_LastName"],
            FullName = (string)row["E_FullName"],
            NationalCode = (string)row["E_NCode"],

            State = (string)row["E_State"],
            City = (string)row["E_City"],
            Street = (string)row["E_Street"],
            Other = (string)row["E_Other"],
            Address = (string)row["E_Address"],

            Gender = (string)row["E_Gender"],
            Salary = (int)row["E_Salary"],
            Email = (string)row["E_Email"],
            EmergencyPhone = (string)row["E_EmergencyPhone"],

            Phone = id
        };

        /// <summary>
        /// Get all employee
        /// </summary>
        public EmployeeIndexModel GetEmployeeList()
        {
            DataSet dataSet = GetSelectQuery("execute dbo.GetEmployeeList;");

            if (dataSet.Tables[0].Rows.Count > 0)
                return new EmployeeIndexModel
                {
                    Employees = GetEmployeeList(dataSet.Tables[0].AsEnumerable()).AsEnumerable<EmployeeIndexRowModel>()
                };

            return null;
        }

        private EnumerableRowCollection<EmployeeIndexRowModel> GetEmployeeList(EnumerableRowCollection<DataRow> enumerableRowCollection) => enumerableRowCollection.Select(row => new EmployeeIndexRowModel
        {
            NCode = (string)row["E_NCode"],
            FullName = (string)row["E_FullName"],

            Address = (string)row["E_Address"],

            Gender = (string)row["E_Gender"],
            Salary = (int)row["E_Salary"],

            Phone = (string)row["E_Phone"]
        });

        /// <summary>
        /// Get employee by city name
        /// </summary>
        public EmployeeIndexModel GetByCity(string city)
        {
            DataSet dataSet = GetSelectQuery("execute dbo.GetEmployeeByCity N" + city + ";");

            if (dataSet.Tables[0].Rows.Count > 0)
                return new EmployeeIndexModel
                {
                    Employees = GetEmployeeByCity(dataSet.Tables[0].AsEnumerable()).AsEnumerable<EmployeeIndexRowModel>()
                };

            return null;
        }

        private EnumerableRowCollection<EmployeeIndexRowModel> GetEmployeeByCity(EnumerableRowCollection<DataRow> enumerableRowCollection) => enumerableRowCollection.Select(row => new EmployeeIndexRowModel
        {
            FullName = (string)row["E_FullName"],

            Address = (string)row["E_Address"],

            Gender = (string)row["E_Gender"],
            Salary = (int)row["E_Salary"],

            Phone = (string)row["E_Phone"]
        });

        /// <summary>
        /// Get employee by gender
        /// </summary>
        public EmployeeIndexModel GetByGender(string gender)
        {
            DataSet dataSet = GetSelectQuery("execute dbo.GetEmployeeByGender N" + gender + ";");

            if (dataSet.Tables[0].Rows.Count > 0)
                return new EmployeeIndexModel
                {
                    Employees = GetEmployeeByGender(dataSet.Tables[0].AsEnumerable()).AsEnumerable<EmployeeIndexRowModel>()
                };

            return null;
        }

        private EnumerableRowCollection<EmployeeIndexRowModel> GetEmployeeByGender(EnumerableRowCollection<DataRow> enumerableRowCollection) => enumerableRowCollection.Select(row => new EmployeeIndexRowModel
        {
            FullName = (string)row["E_FullName"],

            Address = (string)row["E_Address"],

            Gender = (string)row["E_Gender"],
            Salary = (int)row["E_Salary"],

            Phone = (string)row["E_Phone"]
        });

        /// <summary>
        /// Get employee by state name
        /// </summary>
        public EmployeeIndexModel GetByState(string state)
        {
            DataSet dataSet = GetSelectQuery("execute dbo.GetEmployeeByState N" + state + ";");

            if (dataSet.Tables[0].Rows.Count > 0)
                return new EmployeeIndexModel
                {
                    Employees = GetEmployeeByState(dataSet.Tables[0].AsEnumerable()).AsEnumerable<EmployeeIndexRowModel>()
                };

            return null;
        }

        private EnumerableRowCollection<EmployeeIndexRowModel> GetEmployeeByState(EnumerableRowCollection<DataRow> enumerableRowCollection) => enumerableRowCollection.Select(row => new EmployeeIndexRowModel
        {
            FullName = (string)row["E_FullName"],

            Address = (string)row["E_Address"],

            Gender = (string)row["E_Gender"],
            Salary = (int)row["E_Salary"],

            Phone = (string)row["E_Phone"]
        });

        /// <summary>
        /// Remove Employee with id
        /// </summary>
        public bool Remove(string id) => dBTools.DeleteRow("DeleteEmployee", id);

        private DataSet GetSelectQuery(string query = "")
        {
            sqlConnection.Open();
            sqlCommand.CommandText = "SELECT * FROM dbo.[Employee] " + query;
            sqlCommand.Connection = sqlConnection;
            sqlDataAdapter.SelectCommand = sqlCommand;
            dataSet.Clear();
            sqlDataAdapter.Fill(dataSet, srcTable: "[Employee]");
            sqlConnection.Close();
            return dataSet;
        }

    }
}