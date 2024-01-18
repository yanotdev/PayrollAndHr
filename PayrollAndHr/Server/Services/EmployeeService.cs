using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using PayrollAndHr.Server.Data;
using PayrollAndHr.Server.Helpers;
using PayrollAndHr.Shared.Models;
using PayrollAndHr.Shared.ViewModel;

namespace PayrollAndHr.Server.Services
{
    
    public class EmployeeService: IEmployeeService
    {
        private readonly AppDbContext _appDbContext;
        private readonly AppDbContext _appDbContext2;
        private readonly IAuthService _authservice;
        public EmployeeService(AppDbContext appDbContext, AppDbContext appDbContext2, IAuthService authservice)
        {
            _appDbContext = appDbContext;
            _appDbContext2 = appDbContext2;
            _authservice = authservice;
        }

        


        public List<StateEntity> GetStates(string CountryName)
        {
            var model = _appDbContext.States.Where(d => d.CountryName == CountryName).ToList();
            return model;
        }
        //public int GetLastAssetNo()
        //{
        //    int lastNo = 0;
        //    SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=posltd_payrolldb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //    string sqlscript = "SELECT MAX(ID) as LastNo FROM tblUser";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(sqlscript, con);
        //    SqlDataReader sqlReader = cmd.ExecuteReader();
        //    while (sqlReader.Read())
        //    {
        //        string code = sqlReader.GetValue(0).ToString();
        //        if (code == "")
        //        {
        //            code = "0";
        //        }

        //        lastNo = int.Parse(code);
        //    }
        //    con.Close();
        //    return lastNo;
        //}
        public async Task<ServiceResponse<PersonalInformationEntity>> SavePersonalInformation(PersonalInformationEntity personal)
        {
            
            using (var transaction = _appDbContext.Database.BeginTransaction())
            {
                var oldper = _appDbContext.PersonalInfo.Where(d => d.RegistrationID == personal.RegistrationID).FirstOrDefault();
                var userInfo = _appDbContext2.Users.FirstOrDefault();
                if (oldper != null)
                {
                    oldper.DateofBirth = personal.DateofBirth;
                    oldper.Disability = personal.Disability;
                    oldper.DisabilityDescription = personal.DisabilityDescription;
                    oldper.FirstName = personal.FirstName;
                    oldper.Gender = personal.Gender;
                    oldper.ImageUrl = personal.ImageUrl;
                    oldper.MaritalStatus = personal.MaritalStatus;
                    oldper.MiddleName = personal.MiddleName;
                    oldper.Nationality = personal.Nationality;
                    oldper.Religion = personal.Religion;
                    oldper.SpouseName = personal.SpouseName;
                    oldper.State = personal.State;
                    oldper.Surname = personal.State;
                    oldper.TitleCode = personal.TitleCode;
                }
                else
                {
                    //_appDbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[tblPersonalInformation] ON;");
                    _appDbContext.PersonalInfo.Add(personal);
                    
                }

                userInfo.OtherID = personal.StaffNo;
                userInfo.FullName = personal.Surname + " " + personal.FirstName;
                userInfo.Password = _authservice.Encrypt(personal.Surname);
                userInfo.UserRole = personal.StaffStatus;
                userInfo.Username = personal.FirstName;
                userInfo.UserID = personal.ID;
                userInfo.ImageUrl = personal.ImageUrl;
                _appDbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[tblUser] ON;");
                _appDbContext2.Users.Add(userInfo);
                
                _appDbContext2.SaveChanges();
                _appDbContext.SaveChanges();
                //_appDbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[tblPersonalInformation] OFF;");
                //_appDbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[tblUser] OFF;");
                
                //transaction.Commit();
            }
            
            return new ServiceResponse<PersonalInformationEntity>()
            {
                Data = personal,
                Message = "Registration Successful",
                Success = true,                

            };
        }

        public List<EmployList> EmployeeListTa()
        {
            
            var model = (from p in _appDbContext.PersonalInfo
                         join c in _appDbContext.EmployeeContactInfo on p.RegistrationID equals c.RegistrationID into w
                         from jo in w
                         join e in _appDbContext.EmpEmploymentInfo on p.RegistrationID equals e.RegistrationID into t
                         from rt in t.DefaultIfEmpty()
                         orderby p.Surname, p.FirstName, p.MiddleName
                         select new
                         {
                             RegistrationID = p.RegistrationID,
                             Surname = p.Surname,
                             FirstName = p.FirstName,
                             MiddleName = p.MiddleName,
                             Department = rt.Department,
                             MobileNo = jo.MobileNo,
                             WorkNo = jo.WorkPhoneNo,
                             StaffNo = jo.StaffNo
                         }).ToList();
            List<EmployList> Record = new List<EmployList>();
            foreach (var d in model)
            {
                Record.Add(new EmployList
                {
                    FirstName = d.FirstName,
                    MiddleName = d.MiddleName,
                    MobileNo = d.MobileNo,
                    Department = d.Department,
                    RegistrationID = d.RegistrationID,
                    StaffNo = d.StaffNo,
                    Surname = d.Surname,
                    WorkNo = d.WorkNo
                });
            }
            return Record;
        }
        //Upload Image



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

        //            end resize
        //        }
        //    }
        //    return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        //}

    }
}
