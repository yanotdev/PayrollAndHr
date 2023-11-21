using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayrollAndHr.Shared.Models
{
	[Table("tblStaffOtherAllowance")]
	public class StaffOtherAllowancesEntity
	{
		public int ID { get; set; }
		public string StaffNo { get; set; }
		public int AllowanceCode { get; set; }
		public string Amount { get; set; }
		public bool Status { get; set; }
		public string AllowanceType { get; set; }
	}
}