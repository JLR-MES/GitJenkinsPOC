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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GitDataLayer
{
    public class DBConnection
    {
        #region "Local variable declaration"
        private static readonly string S_CONNECTION = ConfigurationManager.ConnectionStrings[DBConstant.APP_CONNECTION_STRING].ConnectionString;
        #endregion
        /// <summary>
        /// Get Dataset
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataSet GetDataset(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet objDs = null;
            SqlConnection conn = new SqlConnection(S_CONNECTION);
            SqlDataAdapter objAdap;
            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                objAdap = new SqlDataAdapter(cmd);
                objDs = new DataSet();
                objDs.Clear();
                objAdap.Fill(objDs);
            }
            catch (Exception ex)
            {
                conn.Close();
                //LogManager.WriteErrorLog(ex);
            }
            finally
            {
                conn.Close();
            }
            return objDs;
        }

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                using (SqlConnection conn = new SqlConnection(S_CONNECTION))
                {
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                    int result = cmd.ExecuteNonQuery();
                    result = Convert.ToInt16(commandParameters[2].Value);
                    cmd.Parameters.Clear();
                    return result;
                }
            }
            catch (Exception ex)
            {
                //LogManager.WriteErrorLog(ex);
                return -2;
            }
        }


        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">SqlCommand object</param>
        /// <param name="conn">SqlConnection object</param>
        /// <param name="trans">SqlTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">SqlParameters to use in the command</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandTimeout = 1200;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

    }
}
