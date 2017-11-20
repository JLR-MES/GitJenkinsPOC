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
        public DataSet LoginUser(string strLoginID, string strPassword)
        {
            DataSet dsUser = new DataSet();
            GitDLogin clsGitDLogin = new GitDLogin();

            dsUser = clsGitDLogin.LoginUser(strLoginID, strPassword);
            return dsUser;
        }
    }
    }
