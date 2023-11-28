using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollAndHr.Server.Data;
using PayrollAndHr.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payroll_Application.Controllers
{
    public class AdminPortalController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public AdminPortalController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

       

        //        // GET: AdminPortal
        //        public ActionResult Index()
        //        {
        //            CompanyInfoEntity comp = db.CompanyInfo.FirstOrDefault();
        //            if (comp != null)
        //            {
        //                _localstorage.SetItemAsync("CompanyLogo", comp.ImageUrl);
        //                _localstorage.SetItemAsync("CompanyName", comp.CompanyName.ToUpper());

        //            }
        //            if (Session["Username"] != null)
        //            {
        //               // Session["CompanyName"] = "POS SHOP LTD";
        //                ViewBag.PageTitle = "Dashboard";
        //                return View();
        //            }
        //            else
        //            {
        //                return RedirectToAction("Index", "Home");
        //            }

        //        }

[HttpGet]
public ActionResult GetEmpCount()
{
    var EmpCount = _appDbContext.PersonalInfo.AsEnumerable().Where(d => d.ID > 0).ToList().Count();
    return Ok(EmpCount);
}
[HttpGet]
public ActionResult GetUserCount()
{
    var EmpCount = _appDbContext.Users.AsEnumerable().Where(d => d.ID > 0).ToList().Count();
    return Ok(EmpCount);
}

[HttpGet]
public ActionResult GetStaffLeaveCount()
{
    var EmpCount = _appDbContext.Leaves.AsEnumerable().Where(d => d.Status == true).ToList().Count();
    return Ok(EmpCount);
}

[HttpGet]
public ActionResult GetUnapproveCount()
{
    int unLeaves = _appDbContext.Leaves.AsEnumerable().Where(d => d.IsDeclined == true).ToList().Count();
    int unLoan = _appDbContext.Messages.AsEnumerable().Where(d => d.IsLoan == true).ToList().Count();
    int unapprove = unLeaves + unLoan;
    return Ok(unapprove);
}
    }
}