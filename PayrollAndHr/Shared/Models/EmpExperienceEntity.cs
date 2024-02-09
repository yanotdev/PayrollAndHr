using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PayrollAndHr.Shared.Models
{
    [Table("tblEmpExperience")]
    public class EmpExperienceEntity
    {
        public long RegistrationID { get; set; }
        public string CompName { get; set; }
        public string JobPosition { get; set; }
        public DateTime DJoined { get; set; } = DateTime.Now;
        public DateTime DLeft { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public long ID { get; set; }
    }
}