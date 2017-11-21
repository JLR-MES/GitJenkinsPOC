# region "History"
/*
File Name:                  DBConnection.cs
Create By:                  Janmejay Thakur
Purpose:                    This file will have methods related to application users.
Change History:             Changed By          Changed Date            Comment
*********************************************************************************************
1                           Janmejay Thakur     20/11/2017          Added method CreateSqlConnection
*/
#endregion

using System.Data;
using System.Data.SqlClient;

namespace GitDataLayer
{
    public class GitDLogin
    {
    /// <summary>
    /// Get logged in user details
    /// </summary>
    /// <param name="strLoginID"></param>
    /// <param name="strPassword"></param>
    /// <returns></returns>
        public DataSet GetUserDetails(string strLoginID)
        {
            DataSet dsUser = new DataSet();
            SqlParameter pLoginID = new SqlParameter("@LoginID", SqlDbType.VarChar, 20);
            pLoginID.Value = strLoginID;
            dsUser = DBConnection.GetDataset(CommandType.StoredProcedure, DBConstant.SP_UserDetails, pLoginID);
            return dsUser;
        }
        public int IsValidUser(string strLoginID,string strPassword)
        {
            SqlParameter pLoginID = new SqlParameter("@LoginID", SqlDbType.VarChar, 20);
            pLoginID.Value = strLoginID;
            SqlParameter pLoginPassword = new SqlParameter("@LoginPassword", SqlDbType.VarChar, 8);
            pLoginPassword.Value = strPassword;
            SqlParameter pIsValidUser = new SqlParameter("@IsValidUser", SqlDbType.Int, 6);
            pIsValidUser.Direction = ParameterDirection.Output;
            int result = DBConnection.ExecuteNonQuery(CommandType.StoredProcedure, DBConstant.SP_ValidUser, pLoginID, pLoginPassword,pIsValidUser);
            return result;
        }
    }
}