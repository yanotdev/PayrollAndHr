using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollAndHr.Server.Data;
using PayrollAndHr.Server.Services;
using PayrollAndHr.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payroll_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPortalController : Controller
    {
        private readonly IAdminPortalService _adminPortalService;


        public AdminPortalController(IAdminPortalService adminPortalService)
        {
            _adminPortalService = adminPortalService;
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

[HttpGet("EmpCount")]
public ActionResult GetEmpCount()
{
    var EmpCount = _adminPortalService.GetEmpCount();

    return Ok(EmpCount);
}
[HttpGet("UserCount")]
public ActionResult GetUserCount()
{
    try
     {
        var EmpCount = _adminPortalService.GetUserCount();
       return Ok(EmpCount);
     }
     catch (Exception ex)
     {
          return BadRequest(ex.Message);
     }
    
}

[HttpGet("StaffLeaveCount")]
public ActionResult GetStaffLeaveCount()
{
    var EmpCount = _adminPortalService.GetStaffLeaveCount();
    return Ok(EmpCount);
}

[HttpGet("UnapproveCount")]
public ActionResult GetUnapproveCount()
{
    int unapprove = _adminPortalService.GetUnapproveCount();
    return Ok(unapprove);
}
    }
}