using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.DAL.MSSQL
{
    class MSSQLDBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            
            /*Hoang:*/
            //String serverName = @"LAPTOP-AQ0CD3L1";
            String serverName = @".\SQLEXPRESS";
            //string serverName = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|RiskWISE5ProcessData.mdf;Integrated Security=True;";
            String DbName = "rbi";
            return SQL_DBConnectUtils.GetDBConnect(serverName, DbName);
        }       
    }
}
