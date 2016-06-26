using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.DAL;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class UnpaidBillManager
    {
        private TestRequestGateway testRequestGateway = new TestRequestGateway();

      
        public List<TestRequest> GetUnPaidBillList(string fromDate, string toDate)
        {
            return testRequestGateway.GetUnPaidBillList(fromDate, toDate);
        }
    }
}