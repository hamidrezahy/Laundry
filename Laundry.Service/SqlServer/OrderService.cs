using Laundry.Data;
using Laundry.Data.Models.Order;
using Laundry.Service.SqlServer.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Laundry.Service.SqlServer
{
    public class OrderService : IOrder
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataSet dataSet;

        DBTools dBTools;

        /// <param name="connectionString">Database connection string</param>
        public OrderService(string connectionString)
        {
            sqlConnection = new SqlConnection();
            sqlCommand = new SqlCommand();
            sqlDataAdapter = new SqlDataAdapter();
            dataSet = new DataSet();

            dBTools = new DBTools(connectionString);

            sqlConnection.ConnectionString = connectionString;
        }

        /// <summary>
        /// Add an order to database
        /// </summary>
        public bool Add(OrderModel order)
        {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "INSERT INTO dbo.[Order] (E_NCode, C_Phone, S_ID, [O_Name], [O_Description], O_Cost, [O_Date], [O_DeliveryDate]) VALUES (@E_NCode, @C_Phone, @S_ID, @O_Name, @O_Description, @O_Cost, @O_Date, @O_DeliveryDate);";
            sqlCommand.Parameters.AddWithValue("@E_NCode", order.Employee_NationalCode);
            sqlCommand.Parameters.AddWithValue("@C_Phone", order.Customer_Phone);
            sqlCommand.Parameters.AddWithValue("@S_ID", order.Service_ID);
            sqlCommand.Parameters.AddWithValue("@O_Name", order.Name);
            sqlCommand.Parameters.AddWithValue("@O_Description", order.Description);
            sqlCommand.Parameters.AddWithValue("@O_Cost", order.Cost);
            sqlCommand.Parameters.AddWithValue("@O_Date", order.Date.ToString(@"yyyy/MM/dd HH:mm:ss"));
            sqlCommand.Parameters.AddWithValue("@O_DeliveryDate", order.DeliveryDate.ToString(@"yyyy/MM/dd HH:mm:ss"));

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

        // public Order Edit(int id, Order order)
        // {
        //     throw new NotImplementedException();
        // }

        /// <summary>
        /// Get order from ID
        /// </summary>
        public OrderDetailModel Get(int id)
        {
            DataSet dataSet = GetSelectQuery("execute dbo.GetOrderByID " + id + ";");

            if (dataSet.Tables[0].Rows.Count > 0)
                return GetOrderByID(dataSet.Tables[0].Rows[0], id);

            return null;


        }

        /// <summary>
        /// Get all order
        /// </summary>
        public IEnumerable<OrderIndexRowModel> GetOrderList()
        {
            DataSet dataSet = GetSelectQuery("execute dbo.GetOrderList;");

            if (dataSet.Tables[0].Rows.Count > 0)
                return GetOrderList(dataSet.Tables[0].AsEnumerable()).AsEnumerable<OrderIndexRowModel>();

            return null;

        }

        /// <summary>
        /// Get order by customer
        /// </summary>
        public IEnumerable<OrderIndexRowModel> GetByCustomer(string customer)
        {
            DataSet dataSet = GetSelectQuery("execute dbo.GetOrderByCustomer N'" + customer + "';");

            if (dataSet.Tables[0].Rows.Count > 0)
                return GetOrderByCustomer(dataSet.Tables[0].AsEnumerable(), customer).AsEnumerable<OrderIndexRowModel>();

            return null;
        }

        /// <summary>
        /// Get order by Employee name
        /// </summary>
        public IEnumerable<OrderIndexRowModel> GetByEmployee(string employee)
        {
            DataSet dataSet = GetSelectQuery("execute dbo.GetOrderByEmployee N'" + employee + "';");

            if (dataSet.Tables[0].Rows.Count > 0)
                return GetOrderByEmployee(dataSet.Tables[0].AsEnumerable(), employee).AsEnumerable<OrderIndexRowModel>();

            return null;
        }

        /// <summary>
        /// Get order by service
        /// </summary>
        public IEnumerable<OrderIndexRowModel> GetByService(int service)
        {
            DataSet dataSet = GetSelectQuery("execute dbo.GetOrderByEmployee " + service + ";");

            if (dataSet.Tables[0].Rows.Count > 0)
                return GetOrderByService(dataSet.Tables[0].AsEnumerable(), service).AsEnumerable<OrderIndexRowModel>();

            return null;
        }


        /// <summary>
        /// Remove Order with id
        /// </summary>
        public bool Remove(int id) => dBTools.DeleteRow("DeleteOrder", id);

        private DataSet GetSelectQuery(string query)
        {
            sqlConnection.Open();
            sqlCommand.CommandText = query;
            sqlCommand.Connection = sqlConnection;
            sqlDataAdapter.SelectCommand = sqlCommand;
            dataSet.Clear();
            sqlDataAdapter.Fill(dataSet, srcTable: "[Order]");
            sqlConnection.Close();
            return dataSet;
        }

        private EnumerableRowCollection<OrderIndexRowModel> GetOrderList(EnumerableRowCollection<DataRow> erc)
        {
            var data = erc.Select(row => new OrderIndexRowModel
            {
                Order_ID = (int)row["O_ID"],
                Employee = (string)row["E_FullName"],
                Customer = (string)row["C_FullName"],
                Service = (string)row["S_Name"],
                ServiceCategory = (string)row["S_Category"],
                Date = (DateTime)row["O_Date"],
                DeliveryDate = (DateTime)row["O_DeliveryDate"],
                Cost = (int)row["O_Cost"],
                Name = (string)row["O_Name"],
            });

            return data;
        }

        private EnumerableRowCollection<OrderIndexRowModel> GetOrderByEmployee(EnumerableRowCollection<DataRow> erc, string emp)
        {
            var data = erc.Select(row => new OrderIndexRowModel
            {
                Order_ID = (int)row["O_ID"],
                Employee = null,
                Customer = (string)row["C_FullName"],
                Service = (string)row["S_Name"],
                Date = (DateTime)row["O_Date"],
                DeliveryDate = (DateTime)row["O_DeliveryDate"],
                Cost = (int)row["O_Cost"],
                Name = (string)row["O_Name"],
            });

            return data;
        }

        private EnumerableRowCollection<OrderIndexRowModel> GetOrderByCustomer(EnumerableRowCollection<DataRow> erc, string ctm)
        {
            var data = erc.Select(row => new OrderIndexRowModel
            {
                Order_ID = (int)row["O_ID"],
                Employee = (string)row["E_FullName"],
                Customer = null,
                Service = (string)row["S_Name"],
                Date = (DateTime)row["O_Date"],
                DeliveryDate = (DateTime)row["O_DeliveryDate"],
                Cost = (int)row["O_Cost"],
                Name = (string)row["O_Name"],
            });

            return data;
        }

        private EnumerableRowCollection<OrderIndexRowModel> GetOrderByService(EnumerableRowCollection<DataRow> erc, int srv)
        {
            var data = erc.Select(row => new OrderIndexRowModel
            {
                Order_ID = (int)row["O_ID"],
                Employee = (string)row["E_FullName"],
                Customer = (string)row["C_FullName"],
                Service = null,
                Date = (DateTime)row["O_Date"],
                DeliveryDate = (DateTime)row["O_DeliveryDate"],
                Cost = (int)row["O_Cost"],
                Name = (string)row["O_Name"],
            });

            return data;
        }

        private OrderDetailModel GetOrderByID(DataRow row, int srv) => new OrderDetailModel
        {
            Order_ID = (int)row["O_ID"],
            Employee = (string)row["E_FullName"],
            EmployeePhone = (string)row["E_Phone"],
            EmployeeEmergencyPhone = (string)row["E_EmergencyPhone"],
            Customer = (string)row["C_FullName"],
            CustomerPhone = (string)row["C_Phone"],
            CustomerAddress = (string)row["C_Address"],
            Service = (string)row["S_Name"],
            ServiceCategory = (string)row["S_Category"],
            Date = (DateTime)row["O_Date"],
            DeliveryDate = (DateTime)row["O_DeliveryDate"],
            Cost = (int)row["O_Cost"],
            Name = (string)row["O_Name"],
        };

    }
}