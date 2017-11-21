using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GitDataLayer;
namespace GitBusinessLayer
{
    public class GitBLogin
    {

        /// <summary>
        ///This method will call Datalayer menthod  GetUserDetails
        /// </summary>
        /// <param name="strLoginID"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public DataSet GetUserDetails(string strLoginID)
        {
            DataSet dsUser = new DataSet();
            GitDLogin clsGitDLogin = new GitDLogin();

            dsUser = clsGitDLogin.GetUserDetails(strLoginID);
            return dsUser;
        }

        /// <summary>
        ///This method will call Datalayer menthod  GetUserDetails
        /// </summary>
        /// <param name="strLoginID"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public int IsValidUser(string strLoginID,string strLoginPassword)
        {
            GitDLogin clsGitDLogin = new GitDLogin();

            int result = clsGitDLogin.IsValidUser(strLoginID, strLoginPassword);
            return result;
        }

    }
}
