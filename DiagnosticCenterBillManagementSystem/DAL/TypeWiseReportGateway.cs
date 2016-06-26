using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.Models.ViewModels;

namespace DiagnosticCenterBillManagementSystem.DAL
{
    public class TypeWiseReportGateway:CommonGateway
    {

        internal List<DateWiseTypeReport> GetDateWiseTypeReport(string startDate, string endDate)
        {
            //string query = "Create View DateWiseTestReport AS SELECT  t.TestName, t.TestFee, count(t.Tid) as TestCount,count(t.Tid)*t.TestFee AS TotalFee, pt.RequestDate FROM Test T INNER JOIN PatientTest pt ON t.[Tid] = pt.[TestId] group by t.TestName, t.TestFee,pt.RequestDate";
            //command = new SqlCommand(query,connection);

            //connection.Open();
            //command.ExecuteNonQuery();
            //connection.Close();

            string query = @"SELECT TestTypeName, SUM(TestCount) as TestCount,COALESCE(SUM(TotalFee),0) as TotalFee FROM DateWiseTestTypeReport 
WHERE RequestDate BETWEEN '"+startDate+"' AND '"+endDate+"' group by TestTypeName";

            
            command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<DateWiseTypeReport> testWiseReportList = new List<DateWiseTypeReport>();

            while (reader.Read())
            {
                DateWiseTypeReport testReport = new DateWiseTypeReport();

                testReport.TestTypeName = reader["TestTypeName"].ToString();
                testReport.TotalTest = Convert.ToInt32(reader["TestCount"].ToString());
                testReport.TotalFee = Convert.ToInt32(reader["TotalFee"].ToString());

                testWiseReportList.Add(testReport);
            }
            reader.Close();
            connection.Close();
            return testWiseReportList;
        }

        internal List<DateWiseTypeReport> GetDateWiseTypeReportNot()
        {
           string query = @"select TestTypeId,TestTypeName from TestType where TestTypeId not in 
(select tt.TestTypeId from TestType tt,Tests t where  tt.TestTypeId=t.TestTypeId)";


            command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<DateWiseTypeReport> testWiseReportList = new List<DateWiseTypeReport>();

            while (reader.Read())
            {
                DateWiseTypeReport testReport = new DateWiseTypeReport();

                testReport.TestTypeName = reader["TestTypeName"].ToString();
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