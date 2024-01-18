using Microsoft.AspNetCore.Mvc;
using PayrollAndHr.Server.Services;
using PayrollAndHr.Shared.Models;
using System;
using System.Data;
using System.IO;
using System.Linq;


namespace Payroll_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : Controller
    {
        private readonly IPayrollService _payrollService;

        public PayrollController(IPayrollService payrollService)
        {
            _payrollService = payrollService;
        }

        //=================================NEW ALLOWANCE===================================================
        [HttpGet("GetAllowanceCode")]
        public ActionResult GetAllowanceCode()
        {
            try
            {
                string code = _payrollService.GetNextDocumentNo("Allowance", 1100).ToString();
                return Ok(code);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveAllowance")]
        public async Task<ActionResult<ServiceResponse<AllowanceEntity>>> SaveAllowancesSet([FromBody] AllowanceEntity allowance)
        {

            try
            {
                var result = await _payrollService.SaveAllowance(allowance);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("GetAllowances")]
        public async Task<ActionResult<ServiceResponse<List<AllowanceEntity>>>> LoadAllowances()
        {
            try
            {
                var result = await _payrollService.LoadAllowances();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        //==============================================================================================

        //=================================NEW PENSION===================================================
        //Get Pension Code
        [HttpGet("GetPensionCode")]
        public ActionResult GetPensionCode()
        {
            try
            {
                string code = _payrollService.GetNextDocumentNo("Pension", 2200).ToString();
                return Ok(code);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SavePension")]
        public async Task<ActionResult<ServiceResponse<AllowanceEntity>>> SavePensionSet([FromBody] PensionEntity pension)
        {

            try
            {
                var result = await _payrollService.SavePension(pension);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetPensions")]
        public async Task<ActionResult<ServiceResponse<List<AllowanceEntity>>>> LoadPensions()
        {
            try
            {
                var result = await _payrollService.LoadPensions();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //==============================================================================================

        //        //=================================NEW LOAN===================================================
        //        //Get Loan Code

        [HttpGet("GetLoanCode")]
        public ActionResult GetLoanCode()
        {
            try
            {
                string code = _payrollService.GetNextDocumentNo("Loan", 3300).ToString();
                return Ok(code);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveLoan")]
        public async Task<ActionResult<ServiceResponse<LoanEntity>>> SaveLoanSet([FromBody] LoanEntity loan)
        {

            try
            {
                var result = await _payrollService.SaveLoan(loan);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("GetLoans")]
        public async Task<ActionResult<ServiceResponse<List<LoanEntity>>>> LoadLoans()
        {
            try
            {
                var result = await _payrollService.LoadLoans();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //==============================================================================================

        //        //=================================NEW PENALTY===================================================
        //        //Get Penalty Code

        [HttpGet("GetPenaltyCode")]
        public ActionResult GetPenaltyCode()
        {
            try
            {
                string code = _payrollService.GetNextDocumentNo("Penalty", 4400).ToString();
                return Ok(code);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SavePenalty")]
        public async Task<ActionResult<ServiceResponse<PenaltyEntity>>> SavePenaltySet([FromBody] PenaltyEntity penalty)
        {

            try
            {
                var result = await _payrollService.SavePenalty(penalty);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetPenalty")]
        public async Task<ActionResult<ServiceResponse<List<PenaltyEntity>>>> LoadPenalties()
        {
            try
            {
                var result = await _payrollService.LoadPenalties();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //==============================================================================================
        //        //=================================NEW OTHER ALLOWANCE===================================================
        //        //Get OtherAllowance Code
        [HttpGet("GetOtherAllowanceCode")]
        public ActionResult GetOtherAllowanceCode()
        {
            try
            {
                string code = _payrollService.GetNextDocumentNo("OtherAllowance", 5500).ToString();
                return Ok(code);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveOtherAllowance")]
        public async Task<ActionResult<ServiceResponse<OtherAllowancesEntity>>> SaveOtherAllowancesSet([FromBody] OtherAllowancesEntity otherAllowancesEntity)
        {

            try
            {
                var result = await _payrollService.SaveOtherAllowance(otherAllowancesEntity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetOtherAllowances")]
        public async Task<ActionResult<ServiceResponse<List<OtherAllowancesEntity>>>> LoadOtherAllowances()
        {
            try
            {
                var result = await _payrollService.LoadOtherAllowances();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

//        // GET: Loan & PenaltyStatus
//        public ActionResult PenaltyStatus()
//        {
//            if (Session["UserID"] == null)
//            {
//                return RedirectToAction("Index", "Home");
//            }
//            return View();
//        }
//        //public ActionResult exportReportt() 
//        //{
//        //    ReportDocument rd = new ReportDocument();
//        //    rd.Load(Server.MapPath("~/Reports/PayrollReport.rpt"));

//        //   rd.SetDataSource(db.Payroll.ToList().OrderByDescending(d => d.GrossPay));
//        //    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Crystal");
//        //} 
//        [HttpGet]

//        public ActionResult exportReport(string format, string months)
//        {
//            PayrollClass.GeneratePayroll(months);
//            DateTime Name = DateTime.Now.Date;
//            ReportDocument rd = new ReportDocument();
//            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "PayrollReport.rpt"));
//            rd.SetDataSource(db.Payroll.ToList().OrderByDescending(d=>d.GrossPay));
//            Response.Buffer = false;
//            Response.ClearContent();
//            Response.ClearHeaders();
//            try
//            {

//                if (format == "pdf")
//                {
//                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
//                    stream.Seek(0, SeekOrigin.Begin);
//                    return File(stream, "application/pdf", $"Payroll Sheet {Name}.pdf");
//                }
//                else {
//                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
//                    stream.Seek(0, SeekOrigin.Begin);
//                    return File(stream, "application/vnd.ms-excel", $"Payroll Sheet {Name}.xls");
//                }

//            }
//            catch
//            {
//                throw;
//            }
//        }

//        [HttpGet]
//        public ActionResult GeneratePayrollHistory(string months) 
//        {
//            string Month = months + " " + DateTime.Now.Year;
//            var payrollData = db.payrollHistories.Where(d => d.Month == Month).ToList();
//            if (payrollData.Count == 0)
//            {
//                PayrollClass.SavePayrollHistory(months);
//                return Json("Payroll saved sucessfully", JsonRequestBehavior.AllowGet);
//            }
//            else 
//            {
//                return Json("Payroll already generated and confirmed", JsonRequestBehavior.AllowGet);
//            }

//        }
//        [HttpGet]
//        public ActionResult DownloadPayrollHistory(string date ,string format)
//        {
//            string Month = Convert.ToDateTime(date).ToString("MMMM");
//            string Year = Convert.ToDateTime(date).Year.ToString();
//            string FullDate = Month + " " + Year;
//            var check = db.payrollHistories.Where(f => f.Month == FullDate).ToList().OrderByDescending(f => f.GrossPay);
//            if (check != null)
//            {
//                ReportDocument rd = new ReportDocument();
//                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "PayrollReport.rpt"));
//                rd.SetDataSource(db.payrollHistories.Where(d => d.Month == FullDate).ToList().OrderByDescending(d => d.GrossPay));
//                Response.Buffer = false;
//                Response.ClearContent();
//                Response.ClearHeaders();
//                try
//                {

//                    if (format == "pdf")
//                    {
//                        Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
//                        stream.Seek(0, SeekOrigin.Begin);
//                        return File(stream, "application/pdf", $"Payroll Sheet {FullDate}.pdf");
//                    }
//                    else
//                    {
//                        Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
//                        stream.Seek(0, SeekOrigin.Begin);
//                        return File(stream, "application/vnd.ms-excel", $"Payroll Sheet {FullDate}.xls");
//                    }

//                }
//                catch
//                {
//                    throw;
//                }
//            }
//            else 
//            {
//                return Json("Payroll not found", JsonRequestBehavior.AllowGet);
//            }



//        }
//        //=================================NEW ALLOWANCE===================================================
//        //Get Allowance Code
//        [HttpGet]
//            public ActionResult GetAllowanceCode()
//            {
//                try
//                {
//                    int code = int.Parse(DataClass.GetNextDocumentNo("Allowance", 1100).ToString());
//                    return Json(code, JsonRequestBehavior.AllowGet);
//                }
//                catch (Exception ex)
//                {
//                    return Json(ex.Message);
//                }
//            }
//            //save Allowance
//            [HttpPost]
//            public ActionResult SaveAllowancesSet(AllowanceEntity allowance)
//            {
//                bool check = false; string desc = "";
//                try
//                {
//                    PayrollClass.SaveAllowance(allowance);
//                    check = true;
//                }
//                catch (Exception ex)
//                {
//                    desc = ex.Message;
//                    check = false;
//                }
//                return new JsonResult { Data = new { Status = check, Desc = desc } };
//            }
//            //load all allowances
//            [HttpGet]
//            public ActionResult LoadAllowances()
//            {
//                var data = db.Allowances.OrderBy(d => d.Description).ToList();
//                return Json(data, JsonRequestBehavior.AllowGet);
//            }
//            //Delete Allowance
//            [HttpPost]
//            public ActionResult DeleteAllowance(int Code)
//            {
//                bool check = false; string desc = "";
//                try
//                {
//                    var data = db.Allowances.Where(d => d.Code == Code).FirstOrDefault();
//                    db.Allowances.Remove(data);
//                    db.SaveChanges();
//                    check = true;
//                }
//                catch (Exception ex)
//                {
//                    desc = ex.Message;
//                    check = false;
//                }
//                return Json(check);
//            }

//            //edit Allowance
//            [HttpGet]
//            public ActionResult EditAllowance(int Code)
//            {
//                var dept = db.Allowances.Where(d => d.Code == Code).FirstOrDefault();
//                return Json(dept, JsonRequestBehavior.AllowGet);
//            }
//            //==============================================================================================

//            //=================================NEW PENSION===================================================
//            //Get Pension Code
//            [HttpGet]
//            public ActionResult GetPensionCode()
//            {
//                try
//                {
//                    int code = int.Parse(DataClass.GetNextDocumentNo("Pension", 2200).ToString());
//                    return Json(code, JsonRequestBehavior.AllowGet);
//                }
//                catch (Exception ex)
//                {
//                    return Json(ex.Message);
//                }
//            }
//            //save Allowance
//            [HttpPost]
//            public ActionResult SavePensionSet(PensionEntity pension)
//            {
//                bool check = false; string desc = "";
//                try
//                {
//                    PayrollClass.SavePension(pension);
//                    check = true;
//                }
//                catch (Exception ex)
//                {
//                    desc = ex.Message;
//                    check = false;
//                }
//                return new JsonResult { Data = new { Status = check, Desc = desc } };
//            }
//        //save Allowance
//        [HttpPost]
//        public ActionResult SaveStaffOtherAllowance(StaffOtherAllowancesEntity staffOther)
//        {
//            bool check = false; string desc = "";
//            try
//            {
//                PayrollClass.SaveStaffOtherAllowance(staffOther);
//                check = true;
//            }
//            catch (Exception ex)
//            {
//                desc = ex.Message;
//                check = false;
//            }
//            return new JsonResult { Data = new { Status = check, Desc = desc } };
//        }
//        //load all StaffLoan
//        [HttpGet]
//            public ActionResult LoadStaffLoan(string StaffID)
//            {
//                var data = db.StaffLoans.Where(d => d.StaffNo == StaffID).ToList();
//                return Json(data, JsonRequestBehavior.AllowGet);
//            }
//            //load all Staff Penalties
//            [HttpGet]
//            public ActionResult LoadStaffPenalty(string StaffID)
//            {
//                var data = db.StaffDeductions.Where(d => d.StaffNo == StaffID).ToList();
//                return Json(data, JsonRequestBehavior.AllowGet);
//            }
//        public ActionResult LoadStaffOtherAllowances(string StaffID)
//        {
//            var data = db.staffOtherAllowances.Where(d => d.StaffNo == StaffID).ToList();
//            return Json(data, JsonRequestBehavior.AllowGet);
//        }
//        //load all allowances
//        [HttpGet]
//            public ActionResult LoadPensions()
//            {
//                var data = db.Pensions.OrderBy(d => d.Code).ToList();
//                return Json(data, JsonRequestBehavior.AllowGet);
//            }
//            //Delete Allowance
//            [HttpPost]
//            public ActionResult DeletePension(int Code)
//            {
//                bool check = false; string desc = "";
//                try
//                {
//                    var data = db.Pensions.Where(d => d.Code == Code).FirstOrDefault();
//                    db.Pensions.Remove(data);
//                    db.SaveChanges();
//                    check = true;
//                }
//                catch (Exception ex)
//                {
//                    desc = ex.Message;
//                    check = false;
//                }
//                return Json(check);
//            }
//           //Delete StaffLoan
//            [HttpPost]
//            public ActionResult DeleteStaffLoan(int ID)
//            {
//                int newCode = Convert.ToInt32(ID);
//                bool check = false; string desc = "";
//                try
//                {
//                    var data = db.StaffLoans.Where(d => d.ID == newCode).FirstOrDefault();
//                    db.StaffLoans.Remove(data);
//                    db.SaveChanges();
//                    check = true;
//                }
//                catch (Exception ex)
//                {
//                    desc = ex.Message;
//                    check = false;
//                }
//                return Json(check);
//            }
//            [HttpGet]
//            public ActionResult EditStaffLoan(string ID)
//            {
//                int newCode = Convert.ToInt32(ID);
//                var dept = db.StaffLoans.Where(d => d.ID == newCode).FirstOrDefault();
//                return Json(dept, JsonRequestBehavior.AllowGet);
//            }


//            //Delete StaffPenalty
//            [HttpPost]
//            public ActionResult DeleteStaffPenalty(string ID)
//            {
//            int newCode = Convert.ToInt32(ID);
//            bool check = false; string desc = "";
//            try
//            {
//                var data = db.StaffDeductions.Where(d => d.ID == newCode).FirstOrDefault();
//                db.StaffDeductions.Remove(data);
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
//        [HttpGet]
//        public ActionResult EditStaffPenalty(string ID)
//        {
//            int newCode = Convert.ToInt32(ID);
//            var dept = db.StaffDeductions.Where(d => d.ID == newCode).FirstOrDefault();
//            return Json(dept, JsonRequestBehavior.AllowGet);
//        }
//        //edit Allowance
//        [HttpGet]
//            public ActionResult EditPension(int Code)
//            {
//                var dept = db.Pensions.Where(d => d.Code == Code).FirstOrDefault();
//                return Json(dept, JsonRequestBehavior.AllowGet);
//            }
//        //==============================================================================================

//        //=================================NEW LOAN===================================================
//        //Get Loan Code
//        [HttpGet]
//        public ActionResult GetLoanCode()
//        {
//            try
//            {
//                int code = int.Parse(DataClass.GetNextDocumentNo("Loan", 3300).ToString());
//                return Json(code, JsonRequestBehavior.AllowGet);
//            }
//            catch (Exception ex)
//            {
//                return Json(ex.Message);
//            }
//        }
//        //save Loan
//        [HttpPost]
//        public ActionResult SaveLoanSet(LoanEntity loan)
//        {
//            bool check = false; string desc = "";
//            try
//            {
//                PayrollClass.SaveLoan(loan);
//                check = true;
//            }
//            catch (Exception ex)
//            {
//                desc = ex.Message;
//                check = false;
//            }
//            return new JsonResult { Data = new { Status = check, Desc = desc } };
//        }
//        //load all Loans
//        [HttpGet]
//        public ActionResult LoadLoans()
//        {
//            var data = db.Loans.OrderBy(d => d.Code).ToList();
//            return Json(data, JsonRequestBehavior.AllowGet);
//        }
//        //Delete Loan
//        [HttpPost]
//        public ActionResult DeleteLoan(int Code)
//        {
//            bool check = false; string desc = "";
//            try
//            {
//                var data = db.Loans.Where(d => d.Code == Code).FirstOrDefault();
//                db.Loans.Remove(data);
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

//        //edit Loan
//        [HttpGet]
//        public ActionResult EditLoan(int Code)
//        {
//            var dept = db.Loans.Where(d => d.Code == Code).FirstOrDefault();
//            return Json(dept, JsonRequestBehavior.AllowGet);
//        }
//        //==============================================================================================

//        //=================================NEW PENALTY===================================================
//        //Get Penalty Code
//        [HttpGet]
//        public ActionResult GetPenaltyCode()
//        {
//            try
//            {
//                int code = int.Parse(DataClass.GetNextDocumentNo("Penalty", 4400).ToString());
//                return Json(code, JsonRequestBehavior.AllowGet);
//            }
//            catch (Exception ex)
//            {
//                return Json(ex.Message);
//            }
//        }
//        [HttpGet]
//        public ActionResult GetOtherAllowanceCode()
//        {
//            try
//            {
//                int code = int.Parse(DataClass.GetNextDocumentNo("Penalty", 4400).ToString());
//                return Json(code, JsonRequestBehavior.AllowGet);
//            }
//            catch (Exception ex)
//            {
//                return Json(ex.Message);
//            }
//        }
//        //save Loan
//        [HttpPost]
//        public ActionResult SavePenaltySet(PenaltyEntity penalty)
//        {
//            bool check = false; string desc = "";
//            try
//            {
//                PayrollClass.SavePenalty(penalty);
//                check = true;
//            }
//            catch (Exception ex)
//            {
//                desc = ex.Message;
//                check = false;
//            }
//            return new JsonResult { Data = new { Status = check, Desc = desc } };
//        }
//        //save other allowances
//        [HttpPost]
//        public ActionResult SaveOtherAllowanceSetup(OtherAllowancesEntity otherAllowances)
//        {
//            bool check = false; string desc = "";
//            try
//            {
//                PayrollClass.SaveOtherAllowance(otherAllowances);
//                check = true;
//            }
//            catch (Exception ex)
//            {
//                desc = ex.Message;
//                check = false;
//            }
//            return new JsonResult { Data = new { Status = check, Desc = desc } };
//        }
//        //load all Loans
//        [HttpGet]
//        public ActionResult LoadPenalties()
//        {
//            var data = db.Penalties.OrderBy(d => d.Code).ToList();
//            return Json(data, JsonRequestBehavior.AllowGet);
//        }


//        [HttpGet]
//        public ActionResult LoadOtherAllowances()
//        {
//            var data = db.otherAllowances.OrderBy(d => d.Code).ToList();
//            return Json(data, JsonRequestBehavior.AllowGet);
//        }
//        //Delete Loan
//        [HttpPost]
//        public ActionResult DeletePenalty(int Code)
//        {
//            bool check = false; string desc = "";
//            try
//            {
//                var data = db.Penalties.Where(d => d.Code == Code).FirstOrDefault();
//                db.Penalties.Remove(data);
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
//        [HttpPost]
//        public ActionResult DeleteOtherAllowances(int Code)
//        {
//            bool check = false; string desc = "";
//            try
//            {
//                var data = db.otherAllowances.Where(d => d.Code == Code).FirstOrDefault();
//                db.otherAllowances.Remove(data);
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
//        //edit Loan
//        [HttpGet]
//        public ActionResult EditPenalty(int Code)
//        {
//            var dept = db.Penalties.Where(d => d.Code == Code).FirstOrDefault();
//            return Json(dept, JsonRequestBehavior.AllowGet);
//        }
//        [HttpGet]
//        public ActionResult EditOtherAllowances(int Code)
//        {
//            var dept = db.otherAllowances.Where(d => d.Code == Code).FirstOrDefault();
//            return Json(dept, JsonRequestBehavior.AllowGet);
//        }
//        //==============================================================================================


//        //Loading Staff
//        [HttpGet]
//        public ActionResult LoadAllStaff()
//        {
//            var data = db.PersonalInfo.OrderBy(d => d.StaffNo).ToList();
//            return Json(data, JsonRequestBehavior.AllowGet);
//        }

//        //loading staff names
//        [HttpGet]
//        public ActionResult GetStaffName(string staff)
//        {
//            var res = db.PersonalInfo.Where(d => d.StaffNo == staff).ToList();
//            return Json(res, JsonRequestBehavior.AllowGet);
//        }
//        [HttpGet]
//        public ActionResult GetSpecialAllowance(string description)
//        {
//            var res = db.otherAllowances.Where(d => d.Description == description).ToList();
//            return Json(res, JsonRequestBehavior.AllowGet);
//        }

//        //Loading allowance description
//        [HttpGet]
//        public ActionResult LoadAllType(string type)
//        {
//            var model = db.Allowances.Where(d=>d.AllType == type).OrderBy(d => d.Code).ToList();
//            return Json(model, JsonRequestBehavior.AllowGet);
//        }

//        //Loading allowance types and percent value
//        [HttpGet]
//        public ActionResult LoadAllowanceType(string descript)
//        {
//            var model = db.Allowances.Where(d => d.Description == descript).ToList();
//            return Json(model, JsonRequestBehavior.AllowGet);
//        }

//        //Saving Salary Information
//        [HttpPost]
//        public ActionResult SaveSalaryDet(SalaryEntity salary)
//        {
//            bool check = false; string desc = "";
//            try
//            {
//                PayrollClass.SaveSalary(salary);
//                check = true;
//            }
//            catch (Exception ex)
//            {
//                desc = ex.Message;
//                check = false;
//            }
//            return new JsonResult { Data = new { status = check, Desc = desc } };
//        }

//        //Loading Net Salary for Staff
//        [HttpGet]
//        public ActionResult LoadNetSalary(string staffName, string staffID)
//        {
//            decimal nS = 0;
//            var model = db.Salaries.Where(d => d.StaffNo == staffID || d.StaffName == staffName).ToList();
//            foreach (var period in model)
//            {
//                if (period.Period == "Annually")
//                {
//                    nS = (period.Amount) / 12;
//                }
//                else
//                {
//                    nS = period.Amount;
//                }
//            }
//            return Json(nS, JsonRequestBehavior.AllowGet);
//        }
//        //Loading Staff Salary Initial Setup
//        [HttpGet]
//        public ActionResult LoadStaffSalary(string staffID)
//        {
//           // decimal nS = 0;
//            var model = db.Salaries.Where(d => d.StaffNo == staffID).ToList();

//            return Json(model, JsonRequestBehavior.AllowGet);
//        }

//        //Saving Staff Loan
//        [HttpPost]
//        public ActionResult SaveStaffLoan(StaffLoanEntity indiviLoan)
//        {
//            bool check = false; string desc = "";
//            try
//            {
//                PayrollClass.SaveStaffLoan(indiviLoan);
//                check = true;
//            }
//            catch (Exception ex)
//            {
//                desc = ex.Message;
//                check = false;
//            }
//            return new JsonResult { Data = new { status = check, Desc = desc } };
//        }

//        //Loading Net Salary for Staff
//        [HttpGet]
//        public ActionResult LoadDeduction(string describe)
//        {
//            var model = db.Penalties.Where(d => d.Description == describe).ToList();
//            return Json(model, JsonRequestBehavior.AllowGet);
//        }

//        //Saving Staff Deduction
//        [HttpPost]
//        public ActionResult SaveStaffDeduction(DeductionEntity staffDeduction)
//        {
//            bool check = false; string desc = "";
//            try
//            {
//                PayrollClass.Savededuct(staffDeduction);
//                check = true;
//            }
//            catch (Exception ex)
//            {
//                desc = ex.Message;
//                check = false;
//            }
//            return new JsonResult { Data = new { status = check, Desc = desc } };
//        }

//        //load from Salary table with ID
//        [HttpGet]
//        public ActionResult LoadALL(string sID)
//        {
//            var data = db.Salaries.Where(d => d.StaffNo == sID && d.Period == "Monthly").ToList();
//            return Json(data, JsonRequestBehavior.AllowGet);
//        }

//        //load from Salary table with ID
//        [HttpGet]
//        public ActionResult LoadALLAnnual(string sID)
//        {
//            var data = db.Salaries.Where(d => d.StaffNo == sID && d.Period == "Annually").ToList();
//            return Json(data, JsonRequestBehavior.AllowGet);
//        }

//        //load from StaffLoan table with ID
//        [HttpGet]
//        public ActionResult PStaffLoan(string sID)
//        {
//            var data = db.StaffLoans.Where(d => d.StaffNo == sID && d.Status == false).ToList();
//            return Json(data, JsonRequestBehavior.AllowGet);
//        }

//        //load from StaffPenalty table with ID
//        [HttpGet]
//        public ActionResult PStaffDeduction(string sID)
//        {
//            var data = db.StaffDeductions.Where(d => d.StaffNo == sID && d.Status == false).ToList();
//            return Json(data, JsonRequestBehavior.AllowGet);
//        }

//        //Saving Staff PayE
//        [HttpPost]
//        public ActionResult SavePayE(PAYEEntity paye)
//        {
//            bool check = false; string desc = "";
//            try
//            {
//                PayrollClass.SaveStaffPayE(paye);
//                check = true;
//            }
//            catch (Exception ex)
//            {
//                desc = ex.Message;
//                check = false;
//            }
//            return new JsonResult { Data = new { status = check, Desc = desc } };
//        }

//        //Getting Deduction
//        [HttpGet]
//        public ActionResult GetAllStaffDed()
//        {
//            var data = db.StaffDeductions.Where(p => p.Status == false).ToList();
//            return Json(data, JsonRequestBehavior.AllowGet);
//        }

//        //Delete Staff Penalty Deduction
//        [HttpPost]
//        public ActionResult DeletePen(int ID)
//        {
//            bool check = false; string desc = "";
//            var emp = db.StaffDeductions.Where(d => d.ID == ID).FirstOrDefault();
//            try
//            {
//                db.StaffDeductions.Remove(emp);
//                check = true;
//            }
//            catch (Exception ex)
//            {
//                desc = ex.Message;
//                check = false;
//            }
//            db.SaveChanges();
//            return new JsonResult { Data = new { Status = check, Desc = desc } };
//        }

//        //Confirm Staff Penalty Deduction
//        [HttpPost]
//        public ActionResult ConfirmPen(int ID)
//        {
//            bool check = false; string desc = "";
//            var emp = db.StaffDeductions.Where(d => d.ID == ID).FirstOrDefault();
//            try
//            {
//                emp.Status = true;
//                db.SaveChanges();
//                check = true;
//            }
//            catch (Exception ex)
//            {
//                desc = ex.Message;
//                check = false;
//            }
//            return new JsonResult { Data = new { Status = check, Desc = desc } };
//        }

//        [HttpGet]
//        public ActionResult GetConStaffDed()
//        {
//            var data = db.StaffDeductions.Where(p => p.Status == false).ToList();
//            foreach(var e in data)
//            {
//                //if (e.Amount)
//            }
//            return Json(data, JsonRequestBehavior.AllowGet);
//        }

//        //Saving Staff Loan
//        [HttpPost]
//        public ActionResult SaveStaffAVC(string StaffID,string AVC)
//        {
//            bool check = false; string desc = "";
//            try
//            {
//                PayrollClass.SaveAvc(StaffID,AVC);
//                check = true;
//            }
//            catch (Exception ex)
//            {
//                desc = ex.Message;
//                check = false;
//            }
//            return new JsonResult { Data = new { status = check, Desc = desc } };
//        }

//        //Getting STAFF AVC
//        [HttpGet]
//        public ActionResult GetStaffAVC(string StaffID)
//        {
//            var data = db.staffAVC.Where(p => p.StaffID == StaffID).ToList();
//            return Json(data, JsonRequestBehavior.AllowGet);
//        }
//    }
//}
