using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollAndHr.Shared.Models
{
    [Table("tblStaffDeductions")]
    public class DeductionEntity
    {
        public string StaffNo { get; set; }
        public string StaffName { get; set; }
        public string PenaltyType { get; set; }
        public string DeductionType { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public int ID { get; set; }
    }
}