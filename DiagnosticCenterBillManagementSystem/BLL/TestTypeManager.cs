using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.DAL;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class TestTypeManager
    {
        TestTypeGateway testTypeGateway = new TestTypeGateway();
        public int Save(TestType testType)
        {
            if (IsTypeNameExist(testType))
            {
                throw new Exception("Type Name already exist.");
            }
            return testTypeGateway.Save(testType);
        }

        public bool IsTypeNameExist(TestType testType)
        {
            return testTypeGateway.IsTypeNameExist(testType);
        }

        public List<TestType> GetAllTestTypes()
        {
            return testTypeGateway.GetAllTestTypes();
        }

       
       
    }
}