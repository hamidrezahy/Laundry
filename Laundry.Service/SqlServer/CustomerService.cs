using Laundry.Data;
using Laundry.Data.Models.Customer;
using Laundry.Service.SqlServer.Tools;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Laundry.Service.SqlServer
{
    public class CustomerService : ICustomer
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataSet dataSet;

        DBTools dBTools;

        /// <param name="connectionString">Database connection string</param>
        public CustomerService(string connectionString)
        {
            sqlConnection = new SqlConnection();
            sqlCommand = new SqlCommand();
            sqlDataAdapter = new SqlDataAdapter();
            dataSet = new DataSet();

            dBTools = new DBTools(connectionString);

            sqlConnection.ConnectionString = connectionString;
        }

        /// <summary>
        /// Add a customer to database
        /// </summary>
        public bool Add(CustomerModel customer)
        {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "INSERT INTO Customer (C_FirstName, C_LastName, C_Phone, [C_State], C_City, C_Street, C_Other) VALUES (@FirstName, @LastName, @Phone, @State, @City, @Street, @Other)";
            sqlCommand.Parameters.AddWithValue("@FirstName", customer.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", customer.LastName);
            sqlCommand.Parameters.AddWithValue("@Phone", customer.Phone);
            sqlCommand.Parameters.AddWithValue("@State", customer.State);
            sqlCommand.Parameters.AddWithValue("@City", customer.City);
            sqlCommand.Parameters.AddWithValue("@Street", customer.Street);
            sqlCommand.Parameters.AddWithValue("@Other", customer.Other);

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

        // public Customer Edit(int id, Customer customer)
        // {
        //     throw new NotImplementedException();
        // }

        /// <summary>
        /// Get customer from ID
        /// </summary>
        public CustomerDetailModel Get(string id)
        {
            DataSet dataSet = GetSelectQuery("execute dbo.GetCustomerByPhone " + id + ";");

            if (dataSet.Tables[0].Rows.Count > 0)
                return GetCustomerByID(dataSet.Tables[0].Rows[0], id);

            return null;


        }

        private CustomerDetailModel GetCustomerByID(DataRow row, string id) => new CustomerDetailModel
        {
            FirstName= (string)row["C_FullName"],
            LastName= (string)row["C_LastName"],
            FullName= (string)row["C_FullName"],


            State= (string)row["C_State"],
            City = (string)row["C_City"],
            Street= (string)row["C_Street"],
            Other= (string)row["C_Other"],
            Address= (string)row["C_Address"],


            Phone = id
        };

        /// <summary>
        /// Get all customer
        /// </summary>
        /// 
        public IEnumerable<CustomerIndexRowModel> GetCustomerList()
        {
            DataSet dataSet = GetSelectQuery("execute dbo.GetCustomerList;");

            if (dataSet.Tables[0].Rows.Count > 0)
                return GetCustomerList(dataSet.Tables[0].AsEnumerable()).AsEnumerable<CustomerIndexRowModel>();

            return null;
        }

        private EnumerableRowCollection<CustomerIndexRowModel> GetCustomerList(EnumerableRowCollection<DataRow> enumerableRowCollection)=> enumerableRowCollection.Select(row => new CustomerIndexRowModel
            {
            FullName = (string)row["C_FullName"],

            Address = (string)row["C_Address"],

            Phone = (string)row["C_Phone"]
        });


        /// <summary>
        /// Get customer by city name
        /// </summary>
        public IEnumerable<CustomerIndexRowModel> GetByCity(string city)
        {
            DataSet dataSet = GetSelectQuery("execute dbo.GetCustomerByCity N" + city + ";");

            if (dataSet.Tables[0].Rows.Count > 0)
                return GetCustomerByCity(dataSet.Tables[0].AsEnumerable()).AsEnumerable<CustomerIndexRowModel>();

            return null;
        }

        private EnumerableRowCollection<CustomerIndexRowModel> GetCustomerByCity(EnumerableRowCollection<DataRow> enumerableRowCollection) => enumerableRowCollection.Select(row => new CustomerIndexRowModel
        {
            FullName = (string)row["C_FullName"],

            Address = (string)row["C_Address"],

            Phone = (string)row["C_Phone"]
        });





        /// <summary>
        /// Get customer by state name
        /// </summary>
        public IEnumerable<CustomerIndexRowModel> GetByState(string state)
        {
            DataSet dataSet = GetSelectQuery("execute dbo.GetCustomerByState N" + state + ";");

            if (dataSet.Tables[0].Rows.Count > 0)
                return GetCustomerByState(dataSet.Tables[0].AsEnumerable()).AsEnumerable<CustomerIndexRowModel>();

            return null;
        }

        private EnumerableRowCollection<CustomerIndexRowModel> GetCustomerByState(EnumerableRowCollection<DataRow> enumerableRowCollection) => enumerableRowCollection.Select(row => new CustomerIndexRowModel
        {
            FullName = (string)row["C_FullName"],

            Address = (string)row["C_Address"],

            Phone = (string)row["C_Phone"]
        });

        
        /// <summary>
        /// Remove Customer with id
        /// </summary>
        public bool Remove(string id) => dBTools.DeleteRow("DeleteCustomer", id);

        private DataSet GetSelectQuery(string query = "")
        {
            sqlConnection.Open();
            sqlCommand.CommandText = "SELECT * FROM dbo.[Customer] " + query;
            sqlCommand.Connection = sqlConnection;
            sqlDataAdapter.SelectCommand = sqlCommand;
            dataSet.Clear();
            sqlDataAdapter.Fill(dataSet, srcTable: "[Customer]");
            sqlConnection.Close();
            return dataSet;
        }

       

       

    }
}