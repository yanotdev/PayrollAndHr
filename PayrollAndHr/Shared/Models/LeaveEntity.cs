﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollAndHr.Shared.Models
{
    [Table("tblLeave")]
    public class LeaveEntity
    {
        public string StaffId { get; set; }
        public string StaffName { get; set; }
        public string LeaveType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string NoDays { get; set; }
        public string Recall { get; set; }
        public string Balance { get; set; }
        public string Reason { get; set; }
        public string Remark { get; set; }
        public bool Status { get; set; }
        public bool IsDeclined { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public int ID { get; set; }
        
    }
}