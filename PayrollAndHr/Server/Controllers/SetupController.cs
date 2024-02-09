using Microsoft.AspNetCore.Mvc;
using PayrollAndHr.Server.Data;
using PayrollAndHr.Server.Services;
using PayrollAndHr.Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace Payroll_Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SetupController : Controller
    {
        private readonly ISetUpService _SetUpService;
        private readonly IPayrollService _payrollService;

        public SetupController(ISetUpService setUpService, IPayrollService payrollService)
        {
            _SetUpService = setUpService;
            _payrollService = payrollService;
        }

        [HttpGet("LoadBranchInfo")]

        public ActionResult LoadBranchInfo()
        {
            var branchlist = _SetUpService.LoadBranchInfo();
            return Ok(branchlist);
        }


        //==================================================BRANCH INFORMATION SETUP=========================================

        [HttpGet("GetBranchCode")]

        public ActionResult GetNextBranchCode()
        {

            try
            {
                string Code = _payrollService.GetNextDocumentNo("Branch", 1000).ToString();
                return Ok(Code);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("SaveBranch")]
        public async Task<ActionResult<ServiceResponse<BranchEntity>>> SaveBranchInfo(BranchEntity Bra)
        {
            try
            {
                var branch = await _SetUpService.SaveBranchInfo(Bra);
                return Ok(branch);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetBranches")]
        public async Task<ActionResult<List<BranchEntity>>> GetBranches()
        {
            try
            {
                var res = await _SetUpService.LoadAllBranchInfo();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteBranch/{Code}")]
        public async Task<ActionResult<List<BranchEntity>>> DeleteBranch(int Code)
        {
            try
            {
                var res = await _SetUpService.DeleteBranch(Code);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("EditBranch/{Code}")]

        public async Task<ActionResult<BranchEntity>> EditBranch(int Code)
        {
            try
            {
                var res = await _SetUpService.EditBranchInfo(Code);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //===============================================================================================

        //====================================EMPLOYEE PARAMETER SETUP===================================

        //====================================title===================================
        [HttpGet("GetTitleCode")]
        public ActionResult GetTitleCode()
        {
            try
            {
                string code = _payrollService.GetNextDocumentNo("Title", 10).ToString();
                return Ok(code);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

       
        [HttpPost("SaveTitle")]
        public async Task<ActionResult<ServiceResponse<TitleEntity>>> SaveTitle([FromBody] TitleEntity title)
        {
            try
            {
                var tite = await _SetUpService.SaveTitles(title);
                return Ok(tite);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetTitles")]
        public async Task<ActionResult<List<TitleEntity>>> GetTitles()
        {
            try
            {
                var tite = await _SetUpService.LoadAllTitles();
                return Ok(tite);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteTitle/{Code}")]
        public async Task<ActionResult<List<TitleEntity>>> deleteTitle(int Code)
        {
            try
            {
                var tite = await _SetUpService.DeleteTitle(Code);
                return Ok(tite);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("EditTitle/{Code}")]

        public async Task<ActionResult<TitleEntity>> EditTitle(int Code)
        {
            try
            {
                var tite = await _SetUpService.EditTitle(Code);
                return Ok(tite);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
            //====================================Level===================================
            //Get Level Code
            [HttpGet("GetLevelCode")]
        public ActionResult GetLevelCode()
        {
            try
            {
                string code = _payrollService.GetNextDocumentNo("Level", 100).ToString();
                return Ok(code);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("Savelevel")]
        public async Task<ActionResult<ServiceResponse<LevelEntity>>> SaveLevel([FromBody] LevelEntity level)
        {
            try
            {
                var levl = await _SetUpService.SaveLevels(level);
                return Ok(levl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetLevels")]
        public async Task<ActionResult<List<TitleEntity>>> GetLevels()
        {
            try
            {
                var levels = await _SetUpService.LoadAllLevels();
                return Ok(levels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteLevel/{Code}")]
        public async Task<ActionResult<List<TitleEntity>>> DeleteLevel(int Code)
        {
            try
            {
                var res = await _SetUpService.DeleteLevel(Code);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("EditLevel/{Code}")]

        public async Task<ActionResult<TitleEntity>> EditLevel(int Code)
        {
            try
            {
                var res = await _SetUpService.EditLevel(Code);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //====================================Department==================================
        //Get Dept Code
        [HttpGet("GetDeptCode")]
        public ActionResult GetDeptCode()
        {
            try
            {
                string code = _payrollService.GetNextDocumentNo("Department", 50).ToString();
                return Ok(code);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveDept")]
        public async Task<ActionResult<ServiceResponse<DepartmentEntity>>> SaveDept([FromBody] DepartmentEntity departmnt)
        {
            try
            {
                var department = await _SetUpService.SaveDept(departmnt);
                return Ok(department);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetDepts")]
        public async Task<ActionResult<List<TitleEntity>>> GetDepts()
        {
            try
            {
                var depts = await _SetUpService.LoadAllDepartment();
                return Ok(depts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteDept/{Code}")]
        public async Task<ActionResult<List<TitleEntity>>> DeleteDept(int Code)
        {
            try
            {
                var res = await _SetUpService.DeleteDepartment(Code);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("EditDept/{Code}")]

        public async Task<ActionResult<TitleEntity>> EditDept(int Code)
        {
            try
            {
                var res = await _SetUpService.EditDepartment(Code);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //====================================Degree==================================
        //Get Degree Code
        [HttpGet("GetDegreeCode")]
        public ActionResult GetDegreeCode()
        {
            try
            {
                string code = _payrollService.GetNextDocumentNo("Degree", 400).ToString();
                return Ok(code);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("SaveDegrees")]
        public async Task<ActionResult<ServiceResponse<DegreeEntity>>> SaveDegrees([FromBody] DegreeEntity degree)
        {
            try
            {
                var deg = await _SetUpService.SaveDegrees(degree);
                return Ok(deg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetDegrees")]
        public async Task<ActionResult<List<TitleEntity>>> GetDegrees()
        {
            try
            {
                var degs = await _SetUpService.LoadAllDegrees();
                return Ok(degs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteDegree/{Code}")]
        public async Task<ActionResult<List<TitleEntity>>> DeleteDegree(int Code)
        {
            try
            {
                var res = await _SetUpService.DeleteDegree(Code);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("EditDegree/{Code}")]

        public async Task<ActionResult<TitleEntity>> EditDegree(int Code)
        {
            try
            {
                var res = await _SetUpService.EditDegrees(Code);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //====================================Designation==================================
        //Get Designation Code
        [HttpGet("GetDesignationCode")]
        public ActionResult GetDesignationCode()
        {
            try
            {
                string code = _payrollService.GetNextDocumentNo("Designation", 300).ToString();
                return Ok(code);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("SaveDesignation")]
        public async Task<ActionResult<ServiceResponse<DesignationEntity>>> SaveDesignation([FromBody] DesignationEntity designation)
        {
            try
            {
                var desig = await _SetUpService.SaveDesignation(designation);
                return Ok(desig);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetDesignation")]
        public async Task<ActionResult<List<DesignationEntity>>> GetDesignation()
        {
            try
            {
                var degs = await _SetUpService.LoadAllDesignation();
                return Ok(degs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteDesignation/{Code}")]
        public async Task<ActionResult<List<TitleEntity>>> DeleteDesignation(int Code)
        {
            try
            {
                var res = await _SetUpService.DeleteDesignation(Code);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("EditDesignation/{Code}")]

        public async Task<ActionResult<TitleEntity>> EditDesignation(int Code)
        {
            try
            {
                var res = await _SetUpService.EditDesignations(Code);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //====================================Employemnt type==================================
        //Get Employement Type Code
        [HttpGet("GetNextEmpTypeCode")]
        public ActionResult GetNextEmpTypeCode()
        {
            try
            {
                string code = _payrollService.GetNextDocumentNo("Employment type", 200).ToString();
                return Ok(code);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("SaveEmpType")]
        public async Task<ActionResult<ServiceResponse<EmploymentTypeEntity>>> SaveEmpType([FromBody] EmploymentTypeEntity employmentTypeEntity)
        {
            try
            {
                var emptype = await _SetUpService.SaveEmpType(employmentTypeEntity);
                return Ok(emptype);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetEmpType")]
        public async Task<ActionResult<List<TitleEntity>>> GetEmpType()
        {
            try
            {
                var degs = await _SetUpService.LoadAllEmpType();
                return Ok(degs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteEmpType/{Code}")]
        public async Task<ActionResult<List<TitleEntity>>> DeleteEmpType(int Code)
        {
            try
            {
                var res = await _SetUpService.DeleteEmpType(Code);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("EditEmpType/{Code}")]

        public async Task<ActionResult<TitleEntity>> EditEmpType(int Code)
        {
            try
            {
                var res = await _SetUpService.EditEmpType(Code);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


    //        //saving company Info
    //        [HttpPost]
    //        public JsonResult CompanyInfo_saving(CompanyInfoEntity info)
    //        {
    //            string errDesc = "", desc = ""; bool check = false;
    //            try
    //            {
    //                var imageurl = info.ImageUrl;
    //                var oldComp = db.CompanyInfo.FirstOrDefault();
    //                if (oldComp == null)
    //                {
    //                    CompanyInfoEntity newcompInfo = new CompanyInfoEntity();
    //                    newcompInfo.Address = info.Address;
    //                    newcompInfo.CompanyName = info.CompanyName;
    //                    newcompInfo.Email = info.Email;
    //                    newcompInfo.PhoneNo = info.PhoneNo;
    //                    if (!string.IsNullOrEmpty(info.ImageUrl))
    //                    {
    //                        newcompInfo.ImageUrl = info.ImageUrl;
    //                        Session["CompanyLogo"] = info.ImageUrl;
    //                    }
    //                    db.CompanyInfo.Add(newcompInfo);
    //                }
    //                else
    //                {
    //                    oldComp.Address = info.Address;
    //                    oldComp.CompanyName = info.CompanyName;
    //                    oldComp.Email = info.Email;
    //                    oldComp.PhoneNo = info.PhoneNo;
    //                    if (!string.IsNullOrEmpty(info.ImageUrl))
    //                    {
    //                        oldComp.ImageUrl = info.ImageUrl;
    //                        Session["CompanyLogo"] = info.ImageUrl;
    //                    }
    //                }
    //                db.SaveChanges();
    //                check = true;
    //                desc = "Company Info saved successfully!";
    //            }
    //            catch (Exception ex)
    //            {
    //                check = false;
    //                errDesc = ex.Message;
    //            }
    //            return new JsonResult { Data = new { status = check, error = errDesc, Desc = desc } };

    //        }

    //        [HttpPost]
    //        public JsonResult UploadCompanyLogo()
    //        {
    //            string _imgname = string.Empty, realImageUrl = "";
    //            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
    //            {
    //                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
    //                if (pic.ContentLength > 0)
    //                {
    //                    var fileName = Path.GetFileName(pic.FileName);
    //                    var _ext = Path.GetExtension(pic.FileName);

    //                    _imgname = Guid.NewGuid().ToString();
    //                    var _comPath = Server.MapPath("~/Images/") + _imgname + _ext;
    //                    _imgname = _imgname + _ext;

    //                    ViewBag.Msg = _comPath;
    //                    var path = _comPath;

    //                    // Saving Image in Original Mode
    //                    pic.SaveAs(path);
    //                    realImageUrl = "~/Images/" + Convert.ToString(_imgname);
    //                    // resizing image
    //                    MemoryStream ms = new MemoryStream();
    //                    WebImage img = new WebImage(_comPath);

    //                    if (img.Width > 300)
    //                    {
    //                        img.Resize(300, 250);
    //                        img.Save(_comPath);
    //                        realImageUrl = "~/Images/" + Convert.ToString(_imgname);
    //                    }

    //                    // end resize
    //                }
    //            }
    //            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
    //        }
    //        [HttpGet]
    //        public ActionResult GetCompanyInfo()
    //        {
    //            var data = db.CompanyInfo.FirstOrDefault();
    //            return Json(data, JsonRequestBehavior.AllowGet);
    //        }
    //        //==================================================BRANCH INFORMATION SETUP=========================================
    //        //Add New Branch
    //        public ActionResult AddNewBranch()
    //        {
    //            if (Session["Username"] == null)
    //            {
    //                return RedirectToAction("Index", "Home");
    //            }
    //            return View();
    //        }
    //        //get New Number
    //        [HttpGet]
    //        public ActionResult GetNextBranchCode()
    //        {
    //            int Code = 0;
    //            string errormsg = "";
    //            try
    //            {
    //                Code = int.Parse(DataClass.GetNextDocumentNo("Branch", 1000).ToString());
    //            }
    //            catch (Exception ex)
    //            {
    //                errormsg = ex.Message;
    //            }
    //            return Json(Code, JsonRequestBehavior.AllowGet);
    //        }
    //        //saving Branch Information
    //        [HttpPost]
    //        public JsonResult SaveBranchInfo(BranchEntity Bra)
    //        {
    //            bool check = false; string desc = "";
    //            try
    //            {
    //                SetupClass.SaveBranchInfo(Bra);
    //                check = true;
    //                desc = "Branch Information saved successfully!";
    //            }
    //            catch (Exception ex)
    //            {
    //                desc = ex.Message;
    //                check = false;
    //            }
    //            return new JsonResult { Data = new { Status = check, Desc = desc } };
    //        }
    //        //Load branch information

    //        public ActionResult LoadBranchInfo()
    //        {
    //            var model = db.Branches.Where(d => d.IsDeleted == false).OrderBy(d => d.BranchName).ToList();
    //            return PartialView("PartialBranchList", model);
    //        }
    //        //load all branches
    //        public ActionResult LoadAllBranches()
    //        {
    //            var model=db.Branches.Where(d => d.IsDeleted == false).OrderBy(d => d.BranchName).ToList();
    //            return Json(model, JsonRequestBehavior.AllowGet);
    //        }

    //        //Get Branch Information by Code
    //        [HttpGet]
    //        public ActionResult GetBranchData(int BranchCode)
    //        {
    //            var branch = db.Branches.Where(d => d.BranchCode == BranchCode).FirstOrDefault();
    //            return Json(branch, JsonRequestBehavior.AllowGet);
    //        }
    //        [HttpPost]
    //        public ActionResult DeleteBranch(int BranchCode)
    //        {
    //            bool isDeleted = false;
    //            try
    //            {
    //                SetupClass.deleteBranch(BranchCode);
    //                isDeleted = true;
    //            }
    //            catch (Exception ex)
    //            {
    //                isDeleted = false;
    //            }
    //            return Json(isDeleted);
    //        }

    //        //===============================================================================================

    //        //====================================EMPLOYEE PARAMETER SETUP===================================
    //        //Setup Form
    //        public ActionResult EmployeeParameterSetup()
    //        {
    //            if (Session["Username"] == null)
    //            {
    //                return RedirectToAction("Index", "Home");
    //            }
    //            return View();
    //        }
    //        //Get Title Code
    //        [HttpGet]
    //        public ActionResult GetTitleCode()
    //        {
    //            try
    //            {
    //                int code = int.Parse(DataClass.GetNextDocumentNo("Title", 10).ToString());
    //                return Json(code,JsonRequestBehavior.AllowGet);
    //            }
    //            catch (Exception ex)
    //            {
    //                return Json(ex.Message);
    //            }
    //        }
    //        //save Titles
    //        [HttpPost]
    //        public ActionResult SaveTitles(TitleEntity title)
    //        {
    //            bool check = false; string desc = "";
    //            try
    //            {
    //                SetupClass.SaveTitles(title);
    //                check = true;
    //            }
    //            catch (Exception ex)
    //            {
    //                desc = ex.Message;
    //                check = false;
    //            }
    //            return new JsonResult { Data = new { Status = check, Desc = desc } };
    //        }
    //        //load all Titles
    //        [HttpGet]
    //        public ActionResult LoadAllTitles()
    //        {
    //            var data = db.Titles.OrderBy(d => d.Description).ToList();
    //            return Json(data, JsonRequestBehavior.AllowGet);
    //        }
    //        //DeleteTitle
    //        [HttpPost]
    //        public ActionResult DeleteTitle(int Code)
    //        {
    //            bool check = false; string desc = "";
    //            try
    //            {
    //                var data = db.Titles.Where(d => d.Code == Code).FirstOrDefault();
    //                db.Titles.Remove(data);
    //                db.SaveChanges();
    //                check = true;
    //            }
    //            catch (Exception ex)
    //            {
    //                desc = ex.Message;
    //                check = false;
    //            }
    //            return Json(check);
    //        }

    //        //edit Level
    //        [HttpGet]
    //        public ActionResult EditTitle(int Code)
    //        {
    //            var title = db.Titles.Where(d => d.Code == Code).FirstOrDefault();
    //            return Json(title, JsonRequestBehavior.AllowGet);
    //        }
    //        //==============================================================================================
    //        //========================================================Staff Level============================

    //        //Get Level Code
    //        [HttpGet]
    //        public ActionResult GetLevelCode()
    //        {
    //            try
    //            {
    //                int code = int.Parse(DataClass.GetNextDocumentNo("Level", 100).ToString());
    //                return Json(code,JsonRequestBehavior.AllowGet);
    //            }
    //            catch (Exception ex)
    //            {
    //                return Json(ex.Message);
    //            }
    //        }
    //        //save Levels
    //        [HttpPost]
    //        public ActionResult SaveLevels(LevelEntity level)
    //        {
    //            bool check = false; string desc = "";
    //            try
    //            {
    //                SetupClass.SaveLevels(level);
    //                check = true;
    //            }
    //            catch (Exception ex)
    //            {
    //                desc = ex.Message;
    //                check = false;
    //            }
    //            return new JsonResult { Data = new { Status = check, Desc = desc } };
    //        }
    //        //load all Levels
    //        [HttpGet]
    //        public ActionResult LoadAllLevels()
    //        {
    //            var data = db.Levels.OrderBy(d => d.Description).ToList();
    //            return Json(data, JsonRequestBehavior.AllowGet);
    //        }
    //        //Delete Level
    //        [HttpPost]
    //        public ActionResult DeleteLevel(int Code)
    //        {
    //            bool check = false; string desc = "";
    //            try
    //            {
    //                var data = db.Levels.Where(d => d.Code == Code).FirstOrDefault();
    //                db.Levels.Remove(data);
    //                db.SaveChanges();
    //                check = true;
    //            }
    //            catch (Exception ex)
    //            {
    //                desc = ex.Message;
    //                check = false;
    //            }
    //            return Json(check);
    //        }
    //        //edit Level
    //        [HttpGet]
    //        public ActionResult EditLevel(int Code)
    //        {
    //            var level = db.Levels.Where(d => d.Code == Code).FirstOrDefault();
    //            return Json(level, JsonRequestBehavior.AllowGet);
    //        }
    //        //=============================================================================================
    //        //=============================Employement Type start from here======================================

    //        //Get Employement Type Code
    //        [HttpGet]
    //        public ActionResult GetNextEmpTypeCode()
    //        {
    //            try
    //            {
    //                int code = int.Parse(DataClass.GetNextDocumentNo("Employement Type", 200).ToString());
    //                return Json(code, JsonRequestBehavior.AllowGet);
    //            }
    //            catch (Exception ex)
    //            {
    //                return Json(ex.Message);
    //            }
    //        }
    //        //save Employement Types
    //        [HttpPost]
    //        public ActionResult SaveEmployementTypes(EmploymentTypeEntity empType)
    //        {
    //            bool check = false; string desc = "";
    //            try
    //            {
    //                SetupClass.SaveEmpType(empType);
    //                check = true;
    //            }
    //            catch (Exception ex)
    //            {
    //                desc = ex.Message;
    //                check = false;
    //            }
    //            return new JsonResult { Data = new { Status = check, Desc = desc } };
    //        }
    //        //load all Employment Types
    //        [HttpGet]
    //        public ActionResult LoadAllEmpTypes()
    //        {
    //            var data = db.EmployementType.OrderBy(d => d.Description).ToList();
    //            return Json(data, JsonRequestBehavior.AllowGet);
    //        }
    //        //Delete Employement Type
    //        [HttpPost]
    //        public ActionResult DeleteEmpType(int Code)
    //        {
    //            bool check = false; string desc = "";
    //            try
    //            {
    //                var data = db.EmployementType.Where(d => d.Code == Code).FirstOrDefault();
    //                db.EmployementType.Remove(data);
    //                db.SaveChanges();
    //                check = true;
    //            }
    //            catch (Exception ex)
    //            {
    //                desc = ex.Message;
    //                check = false;
    //            }
    //            return Json(check);
    //        }
    //        //edit employee type
    //        [HttpGet]
    //        public ActionResult EditEmpType(int Code)
    //        {
    //            var emp = db.EmployementType.Where(d => d.Code == Code).FirstOrDefault();
    //            return Json(emp, JsonRequestBehavior.AllowGet);
    //        }
    //        //=====================================================dept==============================================
    //        //Get Dept Code
    //        [HttpGet]
    //        public ActionResult GetDeptCode()
    //        {
    //            try
    //            {
    //                int code = int.Parse(DataClass.GetNextDocumentNo("Department", 50).ToString());
    //                return Json(code, JsonRequestBehavior.AllowGet);
    //            }
    //            catch (Exception ex)
    //            {
    //                return Json(ex.Message);
    //            }
    //        }
    //        //save Dept
    //        [HttpPost]
    //        public ActionResult SaveDepts(DepartmentEntity Dept)
    //        {
    //            bool check = false; string desc = "";
    //            try
    //            {
    //                SetupClass.SaveDept(Dept);
    //                check = true;
    //            }
    //            catch (Exception ex)
    //            {
    //                desc = ex.Message;
    //                check = false;
    //            }
    //            return new JsonResult { Data = new { Status = check, Desc = desc } };
    //        }

    //        //load all dept
    //        [HttpGet]
    //        public ActionResult LoadAllDepts()
    //        {
    //            var data = db.Depts.OrderBy(d => d.Description).ToList();
    //            return Json(data, JsonRequestBehavior.AllowGet);
    //        }
    //        //Delete Dept
    //        [HttpPost]
    //        public ActionResult DeleteDept(int Code)
    //        {
    //            bool check = false; string desc = "";
    //            try
    //            {
    //                var data = db.Depts.Where(d => d.DeptCode == Code).FirstOrDefault();
    //                db.Depts.Remove(data);
    //                db.SaveChanges();
    //                check = true;
    //            }
    //            catch (Exception ex)
    //            {
    //                desc = ex.Message;
    //                check = false;
    //            }
    //            return Json(check);
    //        }

    //        //edit Dept
    //        [HttpGet]
    //        public ActionResult EditDept(int Code)
    //        {
    //            var dept = db.Depts.Where(d => d.DeptCode == Code).FirstOrDefault();
    //            return Json(dept,JsonRequestBehavior.AllowGet);
    //        }

    //        //=====================================================================================================
    //        //=================================STAFF DESIGNATION===================================================
    //        //Get Dept Code
    //        [HttpGet]
    //        public ActionResult GetDesignationCode()
    //        {
    //            try
    //            {
    //                int code = int.Parse(DataClass.GetNextDocumentNo("Designation", 300).ToString());
    //                return Json(code, JsonRequestBehavior.AllowGet);
    //            }
    //            catch (Exception ex)
    //            {
    //                return Json(ex.Message);
    //            }
    //        }
    //        //save Dept
    //        [HttpPost]
    //        public ActionResult SaveDesignation(DesignationEntity des)
    //        {
    //            bool check = false; string desc = "";
    //            try
    //            {
    //                SetupClass.SaveDesignation(des);
    //                check = true;
    //            }
    //            catch (Exception ex)
    //            {
    //                desc = ex.Message;
    //                check = false;
    //            }
    //            return new JsonResult { Data = new { Status = check, Desc = desc } };
    //        }

    //        //load all dept
    //        [HttpGet]
    //        public ActionResult LoadAllDesignations()
    //        {
    //            var data = db.Designations.OrderBy(d => d.Description).ToList();
    //            return Json(data, JsonRequestBehavior.AllowGet);
    //        }
    //        //Delete Dept
    //        [HttpPost]
    //        public ActionResult DeleteDesignation(int Code)
    //        {
    //            bool check = false; string desc = "";
    //            try
    //            {
    //                var data = db.Designations.Where(d => d.Code == Code).FirstOrDefault();
    //                db.Designations.Remove(data);
    //                db.SaveChanges();
    //                check = true;
    //            }
    //            catch (Exception ex)
    //            {
    //                desc = ex.Message;
    //                check = false;
    //            }
    //            return Json(check);
    //        }

    //        //edit Dept
    //        [HttpGet]
    //        public ActionResult EditDesignation(int Code)
    //        {
    //            var dept = db.Designations.Where(d => d.Code == Code).FirstOrDefault();
    //            return Json(dept, JsonRequestBehavior.AllowGet);
    //        }
    //        //==============================================================================================
    //        //=====================================Academic Degree===========================================
    //        //Get Dept Code
    //        [HttpGet]
    //        public ActionResult GetDegreeCode()
    //        {
    //            try
    //            {
    //                int code = int.Parse(DataClass.GetNextDocumentNo("Degree", 400).ToString());
    //                return Json(code, JsonRequestBehavior.AllowGet);
    //            }
    //            catch (Exception ex)
    //            {
    //                return Json(ex.Message);
    //            }
    //        }
    //        //save Dept
    //        [HttpPost]
    //        public ActionResult SaveDegree(DegreeEntity deg)
    //        {
    //            bool check = false; string desc = "";
    //            try
    //            {
    //                SetupClass.SaveDegrees(deg);
    //                check = true;
    //            }
    //            catch (Exception ex)
    //            {
    //                desc = ex.Message;
    //                check = false;
    //            }
    //            return new JsonResult { Data = new { Status = check, Desc = desc } };
    //        }

    //        //load all dept
    //        [HttpGet]
    //        public ActionResult LoadAllDegrees()
    //        {
    //            var data = db.Degrees.OrderBy(d => d.Description).ToList();
    //            return Json(data, JsonRequestBehavior.AllowGet);
    //        }
    //        //Delete Dept
    //        [HttpPost]
    //        public ActionResult DeleteDegree(int Code)
    //        {
    //            bool check = false; string desc = "";
    //            try
    //            {
    //                var data = db.Degrees.Where(d => d.Code == Code).FirstOrDefault();
    //                db.Degrees.Remove(data);
    //                db.SaveChanges();
    //                check = true;
    //            }
    //            catch (Exception ex)
    //            {
    //                desc = ex.Message;
    //                check = false;
    //            }
    //            return Json(check);
    //        }

    //        //edit Dept
    //        [HttpGet]
    //        public ActionResult EditDegree(int Code)
    //        {
    //            var dept = db.Degrees.Where(d => d.Code == Code).FirstOrDefault();
    //            return Json(dept, JsonRequestBehavior.AllowGet);
    //        }
    //    }


