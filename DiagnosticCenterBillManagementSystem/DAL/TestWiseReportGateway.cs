using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.Models.ViewModels;

namespace DiagnosticCenterBillManagementSystem.DAL
{
    public class TestWiseReportGateway:CommonGateway
    {
        internal List<DateWiseTestReport> GetDateWiseTestReport(string startDate, string endDate)
        {
            //string query = "Create View DateWiseTestReport AS SELECT  t.TestName, t.TestFee, count(t.Tid) as TestCount,count(t.Tid)*t.TestFee AS TotalFee, pt.RequestDate FROM Test T INNER JOIN PatientTest pt ON t.[Tid] = pt.[TestId] group by t.TestName, t.TestFee,pt.RequestDate";
            //command = new SqlCommand(query,connection);

            //connection.Open();
            //command.ExecuteNonQuery();
            //connection.Close();
            


            
            string query = @"SELECT TestName, SUM(TestCount) as TestCount,SUM(TotalFee) as TotalFee  from DateWiseTestReport WHERE RequestDate BETWEEN '"+startDate+"' AND '"+endDate+"' group by TestName";
            command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<DateWiseTestReport> testWiseReportList = new List<DateWiseTestReport>();

            while (reader.Read())
            {
                DateWiseTestReport testReport = new DateWiseTestReport();

                testReport.TestName = reader["TestName"].ToString();
                testReport.TotalTest = Convert.ToInt32(reader["TestCount"].ToString());
                testReport.TotalFee = Convert.ToInt32(reader["TotalFee"].ToString());

                testWiseReportList.Add(testReport);
            }


            
            reader.Close();
            connection.Close();
            
            return testWiseReportList;
        }



        internal List<DateWiseTestReport> GetDateWiseTestReportNot()
        {


            string query = @"select TestId,TestName from Tests where TestId not in 
(select t.TestId from Tests t,PatientTests pt where  t.TestId=pt.TestId)";
            command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<DateWiseTestReport> testWiseReportList = new List<DateWiseTestReport>();

            while (reader.Read())
            {
                DateWiseTestReport testReport = new DateWiseTestReport();

                testReport.TestName = reader["TestName"].ToString();
                testReport.TotalTest = 0;
                testReport.TotalFee = 0;

                testWiseReportList.Add(testReport);
            }
            


            reader.Close();
            connection.Close();

            return testWiseReportList;
        }

    }

}