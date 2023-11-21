using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayrollAndHr.Shared.Models
{
    [Table("tblPrefix")]
    public class PrefixEntity
    {
        public string Prefix { get; set; }
        public int ID { get; set; }
    }
}