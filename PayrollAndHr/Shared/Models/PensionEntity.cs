using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollAndHr.Shared.Models
{
    [Table("tblPension")]
    public class PensionEntity
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public int EmployeePer { get; set; }
        public int EmployerPer { get; set; }
        public int ID { get; set; }
    }
}