using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.DAL;
using DiagnosticCenterBillManagementSystem.Models;
using DiagnosticCenterBillManagementSystem.Models.ViewModels;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class TestManager
    {
        TestGateway testGateway = new TestGateway();
        public int Save(Test test)
        {
            if (IsTestNameExist(test))
            {
                throw new Exception("Test Name already exist.");
            }
            return testGateway.Save(test);
        }

        public bool IsTestNameExist(Test test)
        {
            return testGateway.IsTestNameExist(test);
        }

        public List<ViewTests> GetAllTests()
        {
            return testGateway.GetAllTests();
        }


        public List<Test> GetAllTestsForId()
        {
            return testGateway.GetAllTestsForId();
        }

        public Test GetAllTestsById(int testId)
        {
           return testGateway.GetAllTestsById(testId);

        }
    }
}