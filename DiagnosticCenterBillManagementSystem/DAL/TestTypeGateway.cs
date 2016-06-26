using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.DAL
{
    public class TestTypeGateway : CommonGateway
    {

        public int Save(TestType testType)
        {
            string query = "INSERT INTO TestType VALUES('" + testType.TestTypeName + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public bool IsTypeNameExist(TestType testType)
        {
            string query = "SELECT * FROM TestType WHERE TestTypeName='" + testType.TestTypeName + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isTypeNameExist = false;
            if (reader.HasRows)
            {
                isTypeNameExist = true;
            }
            reader.Close();
            connection.Close();
            return isTypeNameExist;
        }


        public List<TestType> GetAllTestTypes()
        {
            string query = "SELECT * FROM TestType ORDER BY TestTypeName ASC";

            command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<TestType> testTypes = new List<TestType>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestType testType = new TestType();
                    testType.TestTypeId =Convert.ToInt32(reader["TestTypeId"].ToString());
                    testType.TestTypeName = reader["TestTypeName"].ToString();
                    testTypes.Add(testType);
                }
                reader.Close();
            }
            connection.Close();
            return testTypes;
        }

        


    }
}