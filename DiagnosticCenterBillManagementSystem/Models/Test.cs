using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.Models
{
    [Serializable()]
    public class Test
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public decimal TestFee { get; set; }
        public int TestTypeId { get; set; }
        
    }
}