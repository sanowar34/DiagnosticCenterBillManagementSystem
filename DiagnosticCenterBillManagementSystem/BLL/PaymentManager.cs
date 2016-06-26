using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.DAL;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class PaymentManager
    {
        TestRequestGateway testRequestGateway = new TestRequestGateway();

        public TestRequest SearchByBillorMobile(string billNo, string mobileNo)
        {
            return testRequestGateway.SearchByBillorMobile(billNo, mobileNo);
        }

        public int UpdatePaymentStatus(string billNo, string mobileNo)
        {
            return testRequestGateway.UpdatePaymentStatus(billNo, mobileNo);
        }
    }
}