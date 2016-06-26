using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.Models;
using DiagnosticCenterBillManagementSystem.Models.ViewModels;

namespace DiagnosticCenterBillManagementSystem.DAL
{
    public class TestGateway:CommonGateway
    {
        public int Save(Test test)
        {
            string query = "INSERT INTO Tests VALUES('" + test.TestName + "', "+test.TestFee+", "+test.TestTypeId+")";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }



        public bool IsTestNameExist(Test test)
        {
            string query = "SELECT * FROM Tests WHERE TestName='" + test.TestName + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isTestNameExist = false;
            if (reader.HasRows)
            {
                isTestNameExist = true;
            }
            reader.Close();
            connection.Close();
            return isTestNameExist;
        }


        public List<ViewTests> GetAllTests()
        {
            string query = "SELECT * FROM ViewTests ORDER BY TestName ASC";

            command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ViewTests> tests = new List<ViewTests>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ViewTests test = new ViewTests();                    
                    test.TestName = reader["TestName"].ToString();
                    test.TestFee = Convert.ToDecimal(reader["TestFee"].ToString());
                    test.TestTypeName = reader["TestTypeName"].ToString();
                    
                    tests.Add(test);
                }
                reader.Close();
            }
            connection.Close();
            return tests;
        }


        public List<Test> GetAllTestsForId()
        {
            string query = "SELECT * FROM Tests ORDER BY TestName ASC";

            command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Test> tests = new List<Test>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Test test = new Test();
                    test.TestId = Convert.ToInt32(reader["TestId"].ToString());
                    test.TestName = reader["TestName"].ToString();
                    test.TestFee = Convert.ToDecimal(reader["TestFee"].ToString());
                    test.TestTypeId = Convert.ToInt32(reader["TestTypeId"].ToString());

                    tests.Add(test);
                }
                reader.Close();
            }
            connection.Close();
            return tests;
        }

        public Test GetAllTestsById(int testId)
        {
            string query = "SELECT * FROM Tests WHERE TestId=" + testId;

            command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Test test = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    test = new Test();
                    test.TestId = Convert.ToInt32(reader["TestId"].ToString());
                    test.TestName = reader["TestName"].ToString();
                    test.TestFee = Convert.ToDecimal(reader["TestFee"].ToString());
                    test.TestTypeId = Convert.ToInt32(reader["TestTypeId"].ToString());
                    
                }
                reader.Close();
            }
            connection.Close();
            return test;
        }
    }
}