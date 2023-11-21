using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayrollAndHr.Shared.Models
{
	[Table("tblStaffAVC")]
	public class StaffAVCEntity
	{
		public int ID { get; set; }
		public string StaffID { get; set; }
		public string AVC { get; set; }
	}
}