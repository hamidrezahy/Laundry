using Laundry.Data;
using Laundry.Data.Models.Service;
using Laundry.Service.SqlServer.Tools;
using Laundry.Service.Static;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Laundry.Service.SqlServer
{
    public class ServiceService : IService
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataSet dataSet;

        DBTools dBTools;

        /// <param name="connectionString">Database connection string</param>
        public ServiceService(string connectionString)
        {
            sqlConnection = new SqlConnection();
            sqlCommand = new SqlCommand();
            sqlDataAdapter = new SqlDataAdapter();
            dataSet = new DataSet();

            dBTools = new DBTools(connectionString);

            sqlConnection.ConnectionString = connectionString;
        }

        /// <summary>
        /// Add a service to database
        /// </summary>
        public bool Add(ServiceModel service)
        {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "INSERT INTO dbo.[Service] (S_Name,S_Cost,S_Category) VALUES (@S_Name,@S_Cost,@S_Category);";
            sqlCommand.Parameters.AddWithValue("@S_Name", service.Name);
            sqlCommand.Parameters.AddWithValue("@S_Cost", service.Cost);
            sqlCommand.Parameters.AddWithValue("@S_Category", service.Category);

            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }

            // TODO: (SqlException e) 
            catch
            {
                // do something with the exception
                return false;
            }

        }

        // public Service Edit(int id, Service service)
        // {
        //     throw new NotImplementedException();
        // }

        /// <summary>
        /// Get service from ID
        /// </summary>
        public ServiceModel Get(int id)
        {
            DataSet dataSet = GetSelectQuery("execute dbo.GetServiceByID " + id + ";");

            if (dataSet.Tables[0].Rows.Count > 0)
                return GetServiceByID(dataSet.Tables[0].Rows[0], id);

            return null;


        }

        /// <summary>
        /// Get all service
        /// </summary>
        public IEnumerable<ServiceIndexRowModel> GetServiceList()
        {
            DataSet dataSet = GetSelectQuery("execute dbo.GetServiceList;");

            if (dataSet.Tables[0].Rows.Count > 0)
                return GetServiceList(dataSet.Tables[0].AsEnumerable());

            return null;
        }

        private IEnumerable<ServiceIndexRowModel> GetServiceList(EnumerableRowCollection<DataRow> erc)
        {
            var data = erc.Select(row => new ServiceIndexRowModel
            {
                Service_ID = (int)row["S_ID"],
                Category = (string)row["S_Category"],
                Name = (string)row["S_Name"],
                Cost = (int)row["S_Cost"]
            });

            return data;
        }

        /// <summary>
        /// Get service by category
        /// </summary>
        public IEnumerable<ServiceIndexRowModel> GetByCategory(string Category)
        {
            DataSet dataSet = GetSelectQuery("execute dbo.GetServiceByCategory N'" + Category + "';");

            if (dataSet.Tables[0].Rows.Count > 0)
                return GetServiceByCategory(dataSet.Tables[0].AsEnumerable());

            return null;
        }

        /// <summary>
        /// Remove Service with id
        /// </summary>
        public bool Remove(int id) => dBTools.DeleteRow("DeleteService", id);

        private DataSet GetSelectQuery(string query)
        {
            sqlConnection.Open();
            sqlCommand.CommandText = query;
            sqlCommand.Connection = sqlConnection;
            sqlDataAdapter.SelectCommand = sqlCommand;
            dataSet.Clear();
            sqlDataAdapter.Fill(dataSet, srcTable: "[Service]");
            sqlConnection.Close();
            return dataSet;
        }

        private ServiceModel GetServiceByID(DataRow row, int srv) => new ServiceModel
        {
            Service_ID = srv,
            Name = (string)row["S_Name"],
            Category = (string)row["S_Category"],
            Cost = (int)row["S_Cost"]

        };

        private EnumerableRowCollection<ServiceIndexRowModel> GetServiceByCategory(EnumerableRowCollection<DataRow> erc)
        {
            var data = erc.Select(row => new ServiceIndexRowModel
            {
                Service_ID = (int)row["S_ID"],
                Name = (string)row["S_Name"],
                Cost = (int)row["S_Cost"]
            });

            return data;
        }

    }
}