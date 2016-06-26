using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.DAL;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class TestRequestManager
    {
        TestRequestGateway testRequestGateway = new TestRequestGateway();

        public int Save(TestRequest testRequest)
        {
            if (testRequestGateway.IsMobileNoExist(testRequest.MobileNo))
            {
                throw new Exception("Mobile no already exist.");
            }

            return testRequestGateway.Save(testRequest);
        }

        public int SavePatientTests(int patientId, int testId, string requestDate)
        {
            if (testRequestGateway.IsPatientTestExists(patientId,testId))
            {
                throw new Exception("Added Duplicate Tests, please select single test.");
            }
            else
            {
                return testRequestGateway.SavePatientTests(patientId, testId, requestDate);
            }

        }

        public TestRequest GetPatientByMobileNo(string mobileNo)
        {
            return testRequestGateway.GetPatientByMobileNo(mobileNo);
        }


    }
}