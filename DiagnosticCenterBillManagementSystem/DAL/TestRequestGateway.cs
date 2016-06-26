using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.DAL
{
    public class TestRequestGateway:CommonGateway
    {
        public int Save(TestRequest testRequest)
        {
            string query = "INSERT INTO Patient (PatientName,DOB,MobileNo,TotalAmount, DueDate) VALUES('" + testRequest.PatientName + "', '" + testRequest.DOB + "', '" + testRequest.MobileNo + "',"+testRequest.TotalAmount+",'"+testRequest.DueDate+"')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public int SavePatientTests(int patientId, int testId, string requestDate)
        {
            string query = "INSERT INTO PatientTests(PatientId,TestId,RequestDate) VALUES(" + patientId + "," + testId + ",'" + requestDate + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public TestRequest GetPatientByMobileNo(string mobileNo)
        {
            string query = "SELECT * FROM Patient WHERE MobileNo='"+mobileNo+"'";

            command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            TestRequest testRequest = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    testRequest = new TestRequest();

                    testRequest.PatientName = reader["PatientName"].ToString();
                    testRequest.MobileNo = reader["MobileNo"].ToString();
                    testRequest.BillNo = reader["BillNo"].ToString();
                    testRequest.PatientId = Convert.ToInt32(reader["PatientId"].ToString());

                }
                reader.Close();
            }
            connection.Close();
            return testRequest;
        }

        public bool IsPatientTestExists(int patientId, int testId)
        {
            string query = "SELECT * FROM PatientTests WHERE PatientId=" + patientId + " AND TestId=" + testId;
            command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isPatientTestExist = false;
            if (reader.HasRows)
            {
                isPatientTestExist = true;
            }
            reader.Close();
            connection.Close();
            return isPatientTestExist;
        }

        public bool IsMobileNoExist(string mobileNo)
        {
            string query = "SELECT * FROM Patient WHERE MobileNo='"+mobileNo+"'";
            command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool IsMobileNoExist = false;
            if (reader.HasRows)
            {
                IsMobileNoExist = true;
            }
            reader.Close();
            connection.Close();
            return IsMobileNoExist;
        }


        public TestRequest SearchByBillorMobile(string billNo,string mobileNo)
        {
            string query = "SELECT * FROM Patient WHERE BillNo='" + billNo + "' OR MobileNo='" + mobileNo + "'";

            command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            TestRequest testRequest = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    testRequest = new TestRequest();

                    testRequest.PatientId = Convert.ToInt32(reader["PatientId"].ToString());
                    testRequest.PatientName = reader["PatientName"].ToString();
                    testRequest.MobileNo = reader["MobileNo"].ToString();
                    testRequest.BillNo = reader["BillNo"].ToString();

                    testRequest.TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString());
                    testRequest.DueDate =Convert.ToDateTime( reader["DueDate"].ToString());
                    
                }
                reader.Close();
            }
            connection.Close();
            return testRequest;
        }

        public int UpdatePaymentStatus(string billNo, string mobileNo)
        {
            string query = "UPDATE Patient SET PaymentStatus='True' WHERE BillNo='" + billNo + "' OR MobileNo='" + mobileNo + "'";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        

        public List<TestRequest> GetUnPaidBillList(string fromDate, string toDate)
        {
            string query = "SELECT * FROM Patient WHERE PaymentStatus='False' AND DueDate BETWEEN '" + fromDate + "' AND '" + toDate + "'";

            command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<TestRequest> unpaidBillList = new List<TestRequest>(); 
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                  TestRequest testRequest = new TestRequest();

                    testRequest.BillNo = reader["BillNo"].ToString();
                    testRequest.MobileNo = reader["MobileNo"].ToString();
                    testRequest.PatientName = reader["PatientName"].ToString();
                    testRequest.TotalAmount = Convert.ToDecimal(reader["TotalAmount"].ToString());
                   
                    unpaidBillList.Add(testRequest);
                }
                reader.Close();
            }
            connection.Close();
            return unpaidBillList;
        }
    }
}