﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.DAL;
using DiagnosticCenterBillManagementSystem.Models.ViewModels;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class TypeWiseReportManager
    {
       TypeWiseReportGateway testGateway = new TypeWiseReportGateway();
        internal bool ValidateInput(string startDate, string endDate)
        {
            if (startDate == String.Empty)
            {
                throw new Exception("Select a Date");
            }

            else if (endDate == String.Empty)
            {
                throw new Exception("Select a Date");
            }

            else if (Convert.ToDateTime(startDate) > DateTime.Now)
            {
                throw new Exception("Search Date Cannot Go Beyond Current Date!");
            }

            else if (Convert.ToDateTime(endDate) > DateTime.Now)
            {
                throw new Exception("Search Date Cannot Go Beyond Current Date!");
            }

            return true;
        }

        internal List<DateWiseTypeReport> GetDateWiseTypeReport(string startDate, string endDate)
        {
            try
            {
                return testGateway.GetDateWiseTypeReport(startDate, endDate);
            }

            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }


        internal List<DateWiseTypeReport> GetDateWiseTypeReportNot()
        {
            return testGateway.GetDateWiseTypeReportNot();

        }
    }
}