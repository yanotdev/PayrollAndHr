using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayrollAndHr.Shared.Models
{
    [Table("tblPayrollHistory")]
    public class PayrollHistoryEntity
    {
        public int ID { get; set; }
        public string StaffID { get; set; }
        public string StaffName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public decimal GrossPayWithoutAllowance { get; set; }
        public decimal Basic { get; set; }
        public decimal HousingAllowance { get; set; }
        public decimal TransportAllowance { get; set; }

        public decimal LunchAllowance { get; set; }
        public decimal OtherAllowance { get; set; }
        public decimal GrossPay { get; set; }
        public decimal Pension { get; set; }
        public decimal PayeeTax { get; set; }
        public decimal OtherDeductions { get; set; }
        public decimal PensionAvcDeduction { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal Net { get; set; }
        public string Remarks { get; set; }
        public string Month { get; set; }

    }
}