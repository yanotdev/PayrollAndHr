using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayrollAndHr.Shared.Models
{
	[Table("tblOtherAllowances")]
	public class OtherAllowancesEntity
	{
		public int ID { get; set; }
		public int Code { get; set; }
		public string Description { get; set; }
	}
}