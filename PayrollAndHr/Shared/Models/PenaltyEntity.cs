﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollAndHr.Shared.Models
{
    [Table("tblPenalty")]
    public class PenaltyEntity
    {
        public int Code { get; set; }
        public string? Description { get; set; }
        public string DeductType { get; set; }
        public int? Percentage { get; set; }
        public int ID { get; set; }
    }
}