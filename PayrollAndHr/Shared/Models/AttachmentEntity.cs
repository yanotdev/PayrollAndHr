using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollAndHr.Shared.Models
{
    [Table("tblAttachment")]
    public class AttachmentEntity
    {
        public long RegistrationID { get; set; }
        public string FileUrl { get; set; }
        public int ID { get; set; }
    }
}