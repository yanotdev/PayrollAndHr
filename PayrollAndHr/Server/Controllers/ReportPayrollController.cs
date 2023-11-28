using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Payroll_Application.Controllers
{
    public class ReportPayrollController : Controller
    {
        // GET: ReportPayroll
        public ActionResult Index()
        {
            return View();
        }
    }
}