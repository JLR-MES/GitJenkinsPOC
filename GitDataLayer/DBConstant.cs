# region "History"
/*
File Name:                  DBConstant.cs
Create By:                  Janmejay Thakur
Purpose:                    This class fileis used to write all contant variables
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

namespace GitDataLayer
{
    public static class DBConstant
    {

        //Contant Variables
        public static String APP_CONNECTION_STRING = "GitConnection";

        //Stored Procedure Name
        public static String SP_UserDetails = "SP_UserDetails";
        public static String SP_ValidUser = "SP_ValidUser";



    }
}
