using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayrollAndHr.Shared.Models
{
    [Table("tblStartDocumentNo")]
    public class StartDocumentNoEntity
    {
        public string Description { get; set; }
        public long StartNo { get; set; }
        public int ID { get; set; }
    }
}