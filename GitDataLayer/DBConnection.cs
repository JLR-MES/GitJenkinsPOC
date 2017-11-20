# region "History"
/*
File Name:                  DBConnection.cs
Create By:                  Janmejay Thakur
Purpose:                    This file will have all common methods related to databse call.
Change History:             Changed By          Changed Date            Comment
*********************************************************************************************
1                           Janmejay Thakur     20/11/2017          Added method CreateSqlConnection
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace GitDataLayer
{
    public static class DBConnection
    {
        /// <summary>
        /// This method is used to open SQL database connection.
        /// </summary>
        /// <param name="myConnString"></param>
        public static SqlConnection  CreateSqlConnection()
        {
            // string myConnString = ConfigurationManager.ConnectionStrings[DBConstant.STR_CONNECTION_STRING].ConnectionString;
            SqlConnection myConnection = new SqlConnection(DBConstant.STR_CONNECTION_STRING);
            myConnection.Open();
            return myConnection;
        }
    }
}
