using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DiagnosticCenterBillManagementSystem.DAL
{
    public class CommonGateway
    {
        private static string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticCenterDB"].ConnectionString;
        public static SqlConnection connection;
        public static SqlCommand command;

        static CommonGateway()
        {
            connection = new SqlConnection(connectionString);
        }
    }
}