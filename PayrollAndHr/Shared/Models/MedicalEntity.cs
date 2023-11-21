﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollAndHr.Shared.Models
{
    [Table("tblMedical")]
    public class MedicalEntity
    {
        public long RegistrationID { get; set; }
        public string BGroup { get; set; }
        public string Genotype { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string Smoke { get; set; }
        public string Drink { get; set; }
        public string Allergies { get; set; }
        public string MedHistory { get; set; }
        public string Comments { get; set; }
        public long ID { get; set; }
    }
}