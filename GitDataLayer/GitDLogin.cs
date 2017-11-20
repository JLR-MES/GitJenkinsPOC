using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace GitDataLayer
{
    public class GitDLogin
    {
        public DataSet LoginUser(string strLoginID, string strPassword)
        {
            DataSet dsUser = new DataSet();
            // Initialize the SQL command object.
            SqlConnection myCon = new SqlConnection();
            SqlCommand myCommand = new SqlCommand(DBConstant.SP_LOGIN, DBConnection.CreateSqlConnection());
            myCommand.CommandType = CommandType.StoredProcedure;
            // Add the parameters
            myCommand.Parameters.Add("@LoginID", SqlDbType.VarChar).Value = strLoginID;
            myCommand.Parameters.Add("@LoginPassword", SqlDbType.VarChar).Value = strPassword;

            //SqlParameter parameter1 = new SqlParameter("@LoginID", SqlDbType.VarChar);
            //parameter1.Value = strLoginID;
            //parameter1.Direction = ParameterDirection.Input;
            //myCommand.Parameters.Add(parameter1);

            //SqlParameter parameter2 = new SqlParameter("@LoginPassword", SqlDbType.VarChar);
            //parameter1.Value = strPassword;
            //parameter1.Direction = ParameterDirection.Input;
            //myCommand.Parameters.Add(parameter2);

            SqlDataAdapter adapter = new SqlDataAdapter(myCommand);

            adapter.Fill(dsUser);

            return dsUser;
        }
    }
}