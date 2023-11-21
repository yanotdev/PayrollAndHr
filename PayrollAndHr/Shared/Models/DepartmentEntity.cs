using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayrollAndHr.Shared.Models
{    [Table("tblDepartment")]  
    public class DepartmentEntity
    {
        public int DeptCode { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
    }
}