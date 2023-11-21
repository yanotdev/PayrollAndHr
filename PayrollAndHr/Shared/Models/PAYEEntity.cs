using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollAndHr.Shared.Models
{
    [Table("tblPAYE")]
    public class PAYEEntity
    {
        public string StaffID { get; set; }
        public string StaffName { get; set; }
        public string PayPeriod { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal Basic { get; set; }
        public decimal Housing { get; set; }
        public decimal Utility { get; set; }
        public decimal Transport { get; set; }
        public decimal Others { get; set; }
        public decimal Lunch { get; set; }
        public decimal LoanDeduct { get; set; }
        public decimal PenaltyDeduct { get; set; }
        public decimal Pension { get; set; }
        public decimal NationalHFC { get; set; }
        public decimal ConsolidatedR { get; set; }
        public decimal TDeduction { get; set; }
        public decimal TNonTDeduction { get; set; }
        public decimal NetTIncome { get; set; }
        public decimal CalPayE { get; set; }
        public decimal NetSalary { get; set; }
        public DateTime Date { get; set; }
        public int ID { get; set; }
    }
}