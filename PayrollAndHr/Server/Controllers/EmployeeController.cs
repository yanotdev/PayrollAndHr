using Microsoft.AspNetCore.Mvc;
using PayrollAndHr.Server.Services;
using PayrollAndHr.Shared.Dtos;
using PayrollAndHr.Shared.Models;


namespace Payroll_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPayrollService _payrollService;

        
        public EmployeeController(IEmployeeService employeeService, IPayrollService payrollService)
        {
            _employeeService = employeeService;
            _payrollService = payrollService;
        }
       
        [HttpGet]
        public ActionResult GetStates(string CountryName)
        {
            var model = _employeeService.GetStates(CountryName);
            return Ok(model);   
        }

        [HttpPost("SavePersonalInformation")]        
        public async Task<ActionResult<ServiceResponse<PersonalInformationEntity>>> SavePersonalInformation([FromBody]PersonalInformationEntity personal)
        {
            var result = await _employeeService.SavePersonalInformation(personal);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("EmployeeListTa")]          
        public ActionResult EmployeeListTa()
        {
            var employlist = _employeeService.EmployeeListTa();
            return Ok(employlist);
        }
        
        //save the Staff Prefix
        [HttpPost("SavePrefix")]
        public async Task<ActionResult<ServiceResponse<PrefixEntity>>> SavePrefix ([FromBody]PrefixEntity prefix)
        {
            try
            {
                var res = await _employeeService.SavePrefix(prefix);
                return Ok(res);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        //load the prefix
     
        public ActionResult<PrefixEntity> LoadPrefix()
        {
            try
            {
                var res = _employeeService.GetPrefixNo();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Get reg number
        [HttpGet("GetRegistrationNo")]
        public ActionResult<RegistrationPara> GetRegistrationNo()
        {
            RegistrationPara para = new RegistrationPara();
            try
            {

                var pref = _employeeService.GetPrefixNo();
                long RegNo = _payrollService.GetNextDocumentNo("Registration Number", 1000);
                string staffNo = pref + RegNo.ToString();
                para.RegistrationID = RegNo;
                para.StaffNo = staffNo;

                return Ok(para);    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //save contact info
        [HttpPost("SaveContact")]

        public async Task<ActionResult<ServiceResponse<EmpContactInfoEntity>>> SaveContact([FromBody]EmpContactInfoEntity empContactInfoEntity)
        {
            try
            {
                var res = await _employeeService.SaveContact(empContactInfoEntity);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveNextOfKin")]

        public async Task<ActionResult<ServiceResponse<EmpContactInfoEntity>>> SaveNextOfKin([FromBody] NextofKinEntity nextofKinEntity)
        {
            try
            {
                var res = await _employeeService.SaveNoKin(nextofKinEntity);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("SaveGuarantor")]

        public async Task<ActionResult<ServiceResponse<GurrantorEntity>>> SaveGuarantor([FromBody] GurrantorEntity gurrantorEntity)
        {
            try
            {
                var res = await _employeeService.SaveGuarantor(gurrantorEntity);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveReference")]

        public async Task<ActionResult<ServiceResponse<ReferenceEntity>>> SaveReference([FromBody] ReferenceEntity referenceEntity)
        {
            try
            {
                var res = await _employeeService.SaveReference(referenceEntity);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveMedicalHis")]

        public async Task<ActionResult<ServiceResponse<MedicalEntity>>> SaveMedicalHis([FromBody] MedicalEntity medicalEntity)
        {
            try
            {
                var res = await _employeeService.SaveMedicalHis(medicalEntity);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveEmp")]

        public async Task<ActionResult<ServiceResponse<EmpEmploymentEntity>>> SaveEmp([FromBody] EmpEmploymentEntity empEmploymentEntity)
        {
            try
            {
                var res = await _employeeService.SaveEmp(empEmploymentEntity);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("SaveEmpExp")]

        public async Task<ActionResult<ServiceResponse<EmpExperienceEntity>>> SaveEmpExp([FromBody]EmpExperienceEntity empExperienceEntity)
        {
            try
            {
                var res = await _employeeService.SaveEmpExp(empExperienceEntity);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveEmpQua")]

        public async Task<ActionResult<ServiceResponse<EmpQualificationEntity>>> SaveEmpQua([FromBody]EmpQualificationEntity empQualificationEntity)
        {
            try
            {
                var res = await _employeeService.SaveEmpQua(empQualificationEntity);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Upload Image
        //[HttpPost]
        //public ActionResult UploadEmployeePhoto()
        //{
        //    string _imgname = string.Empty, realImageUrl = "";
        //    if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
        //    {
        //        var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
        //        if (pic.ContentLength > 0)
        //        {
        //            var fileName = Path.GetFileName(pic.FileName);
        //            var _ext = Path.GetExtension(pic.FileName);

        //            _imgname = Guid.NewGuid().ToString();
        //            var _comPath = Server.MapPath("~/EmployeeImages/") + _imgname + _ext;
        //            _imgname = _imgname + _ext;

        //            ViewBag.Msg = _comPath;
        //            var path = _comPath;

        //            // Saving Image in Original Mode
        //            pic.SaveAs(path);
        //            realImageUrl = "~/EmployeeImages/" + Convert.ToString(_imgname);
        //            // resizing image
        //            MemoryStream ms = new MemoryStream();
        //            WebImage img = new WebImage(_comPath);

        //            if (img.Width > 200)
        //            {
        //                img.Resize(200, 180);
        //                img.Save(_comPath);
        //                realImageUrl = "~/EmployeeImages/" + Convert.ToString(_imgname);
        //            }

        // end resize
        //        }
        //    }
        //    return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        //}

        //        //Upload Attachment
        //        [HttpPost]
        //        public ActionResult UploadEmployeeAttachment()
        //        {
        //            string FileName = "";
        //            HttpFileCollectionBase files = Request.Files;
        //            for (int i = 0; i < files.Count; i++)
        //            {
        //                HttpPostedFileBase file = files[i];
        //                string fname;
        //                if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
        //                {
        //                    string[] testfiles = file.FileName.Split(new char[] { '\\' });
        //                    fname = testfiles[testfiles.Length - 1];
        //                }
        //                else
        //                {
        //                    fname = file.FileName;
        //                    FileName = file.FileName;
        //                }
        //                fname = Path.Combine(Server.MapPath("~/Attachment/"), Convert.ToString(fname));
        //                file.SaveAs(fname);
        //            }
        //            return Json(Convert.ToString(FileName), JsonRequestBehavior.AllowGet);
        //        }
        //        //Saving Attachment fileUrl
        //        [HttpPost]
        //        public ActionResult SaveUrl(AttachmentEntity attachment)
        //        {
        //            AppDbContext db = new AppDbContext();
        //            var oldAtt = db.Attachments.Where(d => d.RegistrationID == attachment.RegistrationID).FirstOrDefault();
        //            bool check = false; string desc = "";
        //            try
        //            {
        //                if (oldAtt != null)
        //                {
        //                    oldAtt.FileUrl = attachment.FileUrl;
        //                }
        //                else
        //                {
        //                    db.Attachments.Add(attachment);
        //                }
        //                db.Attachments.Add(attachment);
        //                db.SaveChanges();
        //                check = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                check = false;
        //                desc = ex.Message;
        //            }
        //            return new JsonResult { Data = new { status = check, Desc = desc } };
        //        }

        //        //save the Staff Prefix
        //        [HttpPost]
        //        public JsonResult SavePrefix(string prefix)
        //        {
        //            bool check = false;
        //            try
        //            {
        //                var staffprefix = db.StaffPrefix.FirstOrDefault();
        //                if (staffprefix != null)
        //                {
        //                    staffprefix.Prefix = prefix;
        //                }
        //                else
        //                {
        //                    PrefixEntity p = new PrefixEntity();
        //                    p.Prefix = prefix;
        //                    db.StaffPrefix.Add(p);
        //                }
        //                db.SaveChanges();
        //                check = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                check = false;
        //            }
        //            return new JsonResult { Data = new { status = check } };
        //        }
        //        //load the prefix
        //        [HttpGet]
        //        public ActionResult GetPrefixNo()
        //        {
        //            var data = db.StaffPrefix.FirstOrDefault();
        //            return Json(data, JsonRequestBehavior.AllowGet);
        //        }

        //        class RegistrationPara
        //        {
        //            public string StaffNo { get; set; }
        //            public long RegistrationID { get; set; }
        //        }
        //        //Get the RegistrationNo
        //        [HttpGet]
        //        public ActionResult GetRegistrationNo()
        //        {
        //            RegistrationPara para = new RegistrationPara();
        //            try
        //            {

        //                string pref = EmployeeClass.GetStaffPrefixNo();
        //                long RegNo = DataClass.GetNextDocumentNo("Registration Number", 1000);
        //                string staffNo = pref + RegNo.ToString();
        //                para.RegistrationID = RegNo;
        //                para.StaffNo = staffNo;
        //            }
        //            catch (Exception ex)
        //            {

        //            }
        //            return Json(para, JsonRequestBehavior.AllowGet);
        //        }
        //        //save personal Information
        //        [HttpPost]
        //        public ActionResult SavePersonalInformation(PersonalInformationEntity personal)
        //        {
        //            bool check = false; string desc = "";
        //            try
        //            {
        //                EmployeeClass.SavePersonalInformation(personal);
        //                check = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                check = false;
        //                desc = ex.Message;
        //            }
        //            return new JsonResult { Data = new { status = check, Desc = desc } };
        //        }

        //        //saving contact information
        //        [HttpPost]
        //        public ActionResult SaveEmployeeContactInformation(EmpContactInfoEntity contact)
        //        {
        //            bool check = false; string desc = "";
        //            try
        //            {
        //                EmployeeClass.SaveContact(contact);

        //                check = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                check = false;
        //                desc = ex.Message;
        //            }
        //            return new JsonResult { Data = new { status = check, Desc = desc } };
        //        }

        //        //saving nextofkin and guarantor
        //        [HttpPost]
        //        public ActionResult SaveEmployeeNextofKinInformation(NextofKinEntity nextofKin)
        //        {
        //            bool check = false; string desc = "";
        //            try
        //            {
        //                EmployeeClass.SaveNoKin(nextofKin);
        //                check = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                check = false;
        //                desc = ex.Message;
        //            }
        //            return new JsonResult { Data = new { status = check, Desc = desc } };
        //        }
        //        //saving guarantor
        //        [HttpPost]
        //        public ActionResult SaveGuarantorInformation(GurrantorEntity guarantor)
        //        {
        //            bool check = false; string desc = "";
        //            try
        //            {
        //                EmployeeClass.SaveGuarantor(guarantor);
        //                check = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                check = false;
        //                desc = ex.Message;
        //            }
        //            return new JsonResult { Data = new { status = check, Desc = desc } };
        //        }
        //        //Saving MedicalHistory
        //        [HttpPost]
        //        public ActionResult SaveMedicalHistory(MedicalEntity history)
        //        {
        //            bool check = false; string desc = "";
        //            try
        //            {
        //                EmployeeClass.SaveMedicalHis(history);
        //                check = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                check = false;
        //                desc = ex.Message;
        //            }
        //            return new JsonResult { Data = new { status = check, Desc = desc } };
        //        }
        //        //saving Reference
        //        [HttpPost]
        //        public ActionResult SaveReferenceInformation(ReferenceEntity reference)
        //        {
        //            bool check = false; string desc = "";
        //            try
        //            {
        //                EmployeeClass.SaveReference(reference);
        //                check = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                check = false;
        //                desc = ex.Message;
        //            }
        //            return new JsonResult { Data = new { status = check, Desc = desc } };
        //        }
        //        // Saving employment information
        //        [HttpPost]
        //        public ActionResult SaveEmployeeEmploymentInfo(EmpEmploymentEntity employment)
        //        {
        //            bool check = false; string desc = "";
        //            try
        //            {
        //                EmployeeClass.SaveEmp(employment);
        //                check = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                check = false;
        //                desc = ex.Message;
        //            }
        //            return new JsonResult { Data = new { status = check, Desc = desc } };
        //        }
        //        //Saving Qualification
        //        [HttpPost]
        //        public ActionResult SaveEmployeeQualificaton(EmpQualificationEntity qualification)
        //        {
        //            bool check = false; string desc = "";
        //            try
        //            {
        //                EmployeeClass.SaveEmpQua(qualification);
        //                check = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                check = false;
        //                desc = ex.Message;
        //            }
        //            return new JsonResult { Data = new { status = check, Desc = desc } };
        //        }
        //        //Load Qualification information
        //        public ActionResult LoadQualificationInfo(int RegistID)
        //        {
        //            var Model = db.EmpQualifications.Where(d => d.IsDeleted == false && d.RegistrationID == RegistID).OrderBy(d => d.Institution).ToList();
        //            return PartialView("PartialQualificationList", Model);
        //        }

        //        [HttpGet]
        //        public ActionResult GetQuaData(int Id)
        //        {
        //            var experi = db.EmpExperiences.Where(d => d.ID == Id).FirstOrDefault();
        //            return Json(experi, JsonRequestBehavior.AllowGet);
        //        }

        //        [HttpPost]
        //        public ActionResult DeleteQualification(int Id)
        //        {
        //            bool isDeleted = false;
        //            try
        //            {
        //                EmployeeClass.deleteQuaification(Id);
        //                isDeleted = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                isDeleted = false;
        //            }
        //            return Json(isDeleted);
        //        }

        //        //Saving Experience
        //        [HttpPost]
        //        public ActionResult SaveEmployeeExperience(EmpExperienceEntity experience)
        //        {
        //            bool check = false; string desc = "";
        //            try
        //            {
        //                EmployeeClass.SaveEmpExp(experience);
        //                check = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                check = false;
        //                desc = ex.Message;
        //            }
        //            return new JsonResult { Data = new { status = check, Desc = desc } };
        //        }

        //        //Load experience information
        //        public ActionResult LoadExpInfo(int RegistID)
        //        {
        //            var Model = db.EmpExperiences.Where(d => d.IsDeleted == false && d.RegistrationID == RegistID).OrderBy(d => d.CompName).ToList();
        //            return PartialView("PartialExperienceList", Model);
        //        }

        //        [HttpGet]
        //        public ActionResult GetExperienceData(int Id)
        //        {
        //            var experi = db.EmpExperiences.Where(d => d.ID == Id).FirstOrDefault();
        //            return Json(experi, JsonRequestBehavior.AllowGet);
        //        }

        //        [HttpPost]
        //        public ActionResult DeleteExperience(int Id)
        //        {
        //            bool isDeleted = false;
        //            try
        //            {
        //                EmployeeClass.deleteExperience(Id);
        //                isDeleted = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                isDeleted = false;
        //            }
        //            return Json(isDeleted);
        //        }

        //        //load employee list
        //        [HttpPost]
        //        public ActionResult StaffList()
        //        {
        //            AppDbContext db = new AppDbContext();
        //            var model = (from p in db.PersonalInfo
        //                         join c in db.EmployeeContactInfo on p.RegistrationID equals c.RegistrationID into t
        //                         from rt in t.DefaultIfEmpty()
        //                         orderby
        //                         p.Surname, p.FirstName, p.MiddleName
        //                         select new
        //                         {
        //                             RegistrationID = p.RegistrationID,
        //                             Surname = p.Surname,
        //                             FirstName = p.FirstName,
        //                             MiddleName = p.MiddleName,
        //                             MobileNo = rt.MobileNo,
        //                             WorkNo = rt.WorkPhoneNo,
        //                             StaffNo = rt.StaffNo
        //                         }).ToList();
        //            List<EmployeeListRecord> Records = new List<EmployeeListRecord>();
        //            foreach (var d in model)
        //            {
        //                Records.Add(new EmployeeListRecord
        //                {
        //                    FirstName = d.FirstName,
        //                    MiddleName = d.MiddleName,
        //                    MobileNo = d.MobileNo,
        //                    RegistrationID = d.RegistrationID,
        //                    StaffNo = d.StaffNo,
        //                    Surname = d.Surname,
        //                    WorkNo = d.WorkNo
        //                });
        //            }
        //            return PartialView("PartialShowEmpRecord", Records);
        //        }

        //        [HttpPost]
        //        public ActionResult EmployeeListTa()
        //        {
        //            AppDbContext db = new AppDbContext();
        //            var model = (from p in db.PersonalInfo
        //                         join c in db.EmployeeContactInfo on p.RegistrationID equals c.RegistrationID into w
        //                         from jo in w
        //                         join e in db.EmpEmploymentInfo on p.RegistrationID equals e.RegistrationID into t
        //                         from rt in t.DefaultIfEmpty()
        //                         orderby p.Surname, p.FirstName, p.MiddleName
        //                         select new
        //                         {
        //                             RegistrationID = p.RegistrationID,
        //                             Surname = p.Surname,
        //                             FirstName = p.FirstName,
        //                             MiddleName = p.MiddleName,
        //                             Department = rt.Department,
        //                             MobileNo = jo.MobileNo,
        //                             WorkNo = jo.WorkPhoneNo,
        //                             StaffNo = jo.StaffNo
        //                         }).ToList();
        //            List<EmployList> Record = new List<EmployList>();
        //            foreach (var d in model)
        //            {
        //                Record.Add(new EmployList
        //                {
        //                    FirstName = d.FirstName,
        //                    MiddleName = d.MiddleName,
        //                    MobileNo = d.MobileNo,
        //                    Department = d.Department,
        //                    RegistrationID = d.RegistrationID,
        //                    StaffNo = d.StaffNo,
        //                    Surname = d.Surname,
        //                    WorkNo = d.WorkNo
        //                });
        //            }
        //            return PartialView("PartialEmployList", Record);
        //        }
    }
}