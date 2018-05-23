using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Laundry.Service.SqlServer.Tools
{
    public class DBTools
    {
        SqlConnection sqlConnection = new SqlConnection();
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        DataSet dataSet = new DataSet();

        public DBTools(string dbString)
        {
            sqlConnection.ConnectionString = dbString;
        }

        public bool DeleteRow(string deleteProcedure, string key)
        {
            sqlCommand.CommandText = "execute dbo." + deleteProcedure + " N'" + key + "';";

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

        public bool DeleteRow(string deleteProcedure, int key)
        {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "EXECUTE dbo." + deleteProcedure + " " + key + ";";

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
    }
}