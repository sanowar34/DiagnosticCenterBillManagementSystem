﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.Models.ViewModels
{
    public class DateWiseTypeReport
    {
        public string TestTypeName { get; set; }
        public int TotalTest { get; set; }
        public int TotalFee { get; set; }

        public DateWiseTypeReport()
        {

        }

    }
}