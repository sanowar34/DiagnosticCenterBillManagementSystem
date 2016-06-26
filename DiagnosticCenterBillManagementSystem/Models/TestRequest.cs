using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.Models
{
    [Serializable()]
    public class TestRequest
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string DOB { get; set; }
        public string MobileNo { get; set; }
        public int TestId { get; set; }
        public string BillNo { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DueDate { get; set; }
        


    }
}