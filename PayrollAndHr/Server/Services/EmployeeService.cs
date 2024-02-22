using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using PayrollAndHr.Server.Data;
using PayrollAndHr.Server.Helpers;
using PayrollAndHr.Shared.Models;
using PayrollAndHr.Shared.ViewModel;
using System.Data;

namespace PayrollAndHr.Server.Services
{
    
    public class EmployeeService: IEmployeeService
    {
        private readonly AppDbContext _appDbContext;
        private readonly AppDbContext _appDbContext2;
        private readonly IAuthService _authservice;
        private readonly IConfiguration _configuration;
  
       
        public EmployeeService(AppDbContext appDbContext, AppDbContext appDbContext2, IAuthService authservice, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _appDbContext2 = appDbContext2;
            _authservice = authservice;
            _configuration = configuration;
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
            
          
                var oldper = _appDbContext.PersonalInfo.Where(d => d.RegistrationID == personal.RegistrationID).FirstOrDefault();
               
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
                    _appDbContext.SaveChanges();
                }
            var userInfo = _appDbContext2.Users.Where(x => x.OtherID == personal.StaffNo).FirstOrDefault();
            if(userInfo != null)
            {
                userInfo.OtherID = personal.StaffNo;
                userInfo.FullName = personal.Surname + " " + personal.FirstName;
                userInfo.Password = _authservice.Encrypt(personal.Surname);
                userInfo.UserRole = personal.StaffStatus;
                userInfo.Username = personal.FirstName;
                userInfo.UserID = personal.ID;
                userInfo.ImageUrl = personal.ImageUrl;
                _appDbContext2.Users.Add(userInfo);
                _appDbContext2.SaveChanges();

            }
            else
            {
                UserEntity userEntity = new UserEntity();
                userEntity.OtherID = personal.StaffNo;
                userEntity.FullName = personal.Surname + " " + personal.FirstName;
                userEntity.Password = _authservice.Encrypt(personal.Surname);
                userEntity.UserRole = personal.StaffStatus;
                userEntity.Username = personal.FirstName;
                userEntity.UserID = personal.ID;
                userEntity.ImageUrl = personal.ImageUrl;
                _appDbContext2.Users.Add(userEntity);
                _appDbContext2.SaveChanges();

            }

            return new ServiceResponse<PersonalInformationEntity>()
            {
                Data = personal,
                Message = "Personal Info Save Successful",
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


        public async Task<ServiceResponse<PrefixEntity>> SavePrefix(PrefixEntity prefixEntity)
        {

            PrefixEntity p = new PrefixEntity();
            var staffprefix = _appDbContext.StaffPrefix.FirstOrDefault();
                if (staffprefix != null)
                {
                    staffprefix.Prefix = prefixEntity.Prefix;
                }
                else
                {
                    p.Prefix = prefixEntity.Prefix;
                    _appDbContext.StaffPrefix.Add(p);
                }
                await _appDbContext.SaveChangesAsync();
               
                return new ServiceResponse<PrefixEntity>()
                {
                    Data = p,
                    Message = "Save Successful",
                    Success = true,

                };
            }


        public string GetPrefixNo()
        {
            var data = _appDbContext.StaffPrefix.FirstOrDefault();
            return data.Prefix;
        }


        //saving Contact Info

        public async Task<ServiceResponse<EmpContactInfoEntity>> SaveContact(EmpContactInfoEntity contact)
        {
           
            var oldCont = _appDbContext.EmployeeContactInfo.Where(d => d.RegistrationID == contact.RegistrationID).FirstOrDefault();
            var conString = _configuration.GetConnectionString("DefaultConnection");

            if (oldCont != null)
            {
                oldCont.Address = contact.Address;
                oldCont.City = contact.City;
                oldCont.Country = contact.Country;
                oldCont.Email = contact.Email;
                oldCont.MobileNo = contact.MobileNo;
                oldCont.MobileNo2 = contact.MobileNo2;
                oldCont.State = contact.State;
                oldCont.WorkEmail = contact.WorkEmail;
                oldCont.WorkPhoneNo = contact.WorkPhoneNo;
                oldCont.LGA = contact.LGA;
                oldCont.Landmark = contact.Landmark;

            }
            else
            {
                _appDbContext.EmployeeContactInfo.Add(contact);
                
            }


            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string sql = "Update tblUser set Email='" + contact.Email + "',PhoneNo='" + contact.MobileNo + "' where OtherID='" + contact.StaffNo + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            _appDbContext.SaveChanges();
            return new ServiceResponse<EmpContactInfoEntity>()
            {
                Data = contact,
                Message = "Contact Save Successfully",
                Success = true,
            };

        }

        // saving next of kin and guarantor information
        public async Task<ServiceResponse<NextofKinEntity>> SaveNoKin(NextofKinEntity nextofKin)
        {
            
            var oldNoF = _appDbContext.EmpNextofKin.Where(d => d.RegistrationID == nextofKin.RegistrationID).FirstOrDefault();
            if (oldNoF != null)
            {
                oldNoF.FullName = nextofKin.FullName;
                oldNoF.PhoneNo = nextofKin.PhoneNo;
                oldNoF.Address = nextofKin.Address;
                oldNoF.Country = nextofKin.Country;
                oldNoF.State = nextofKin.State;
                oldNoF.Relationship = nextofKin.Relationship;
                oldNoF.Name = nextofKin.Name;
                oldNoF.Contact = nextofKin.Contact;

            }
            else
            {
                _appDbContext.EmpNextofKin.Add(nextofKin);
            }
            
            await _appDbContext.SaveChangesAsync();

            return new ServiceResponse<NextofKinEntity>()
            {
                Data = nextofKin,
                Message = "Next Of Kin Saved Successfully",
                Success = true,
            };
        }

        //Save guarantor
        public async Task<ServiceResponse<GurrantorEntity>> SaveGuarantor(GurrantorEntity guarantor)
        {
           
            var oldNoF = _appDbContext.EmpGurrantor.Where(d => d.RegistrationID == guarantor.RegistrationID).FirstOrDefault();
            if (oldNoF != null)
            {
                oldNoF.GFullName = guarantor.GFullName;
                oldNoF.GPhoneNo = guarantor.GPhoneNo;
                oldNoF.GAddress = guarantor.GAddress;
                oldNoF.GCountry = guarantor.GCountry;
                oldNoF.GState = guarantor.GState;
                oldNoF.GPayLevel = guarantor.GPayLevel;

            }
            else
            {
                _appDbContext.EmpGurrantor.Add(guarantor);
            }
            
            await _appDbContext.SaveChangesAsync();

            return new ServiceResponse<GurrantorEntity>()
            {
                Data = guarantor,
                Message = "Guarantor Saved Successfully",
                Success = true,
            };
        }

        public async Task<ServiceResponse<ReferenceEntity>> SaveReference(ReferenceEntity reference)
        {
           
            var oldNoF = _appDbContext.EmpReference.Where(d => d.RegistrationID == reference.RegistrationID).FirstOrDefault();
            if (oldNoF != null)
            {
                oldNoF.RFullName = reference.RFullName;
                oldNoF.RPhoneNo = reference.RPhoneNo;
                oldNoF.RAddress = reference.RAddress;
                oldNoF.RCountry = reference.RCountry;
                oldNoF.RState = reference.RState;
                oldNoF.RJobPosition = reference.RJobPosition;
            }
            else
            {
                _appDbContext.EmpReference.Add(reference);
            }
            
            await _appDbContext.SaveChangesAsync();

            return new ServiceResponse<ReferenceEntity>()
            {
                Data = reference,
                Message = "Reference Saved Successfully",
                Success = true,
            };
        }
        //Saving Medical History
        public async Task<ServiceResponse<MedicalEntity>> SaveMedicalHis(MedicalEntity history)
        {
           
            var oldMed = _appDbContext.MedicalHistory.Where(r => r.RegistrationID == history.RegistrationID).FirstOrDefault();
            if (oldMed != null)
            {
                oldMed.BGroup = history.BGroup;
                oldMed.Genotype = history.Genotype;
                oldMed.Weight = history.Weight;
                oldMed.Height = history.Height;
                oldMed.Smoke = history.Smoke;
                oldMed.Drink = history.Drink;
                oldMed.Allergies = history.Allergies;
                oldMed.MedHistory = history.MedHistory;
                oldMed.Comments = history.Comments;
            }
            else
            {
                _appDbContext.MedicalHistory.Add(history);
            }
            
            await _appDbContext.SaveChangesAsync();

            return new ServiceResponse<MedicalEntity>()
            {
                Data = history,
                Message = "Medical History Saved Successfully",
                Success = true,
            };
        }

        // Saving Employment Info
        public async Task<ServiceResponse<EmpEmploymentEntity>> SaveEmp(EmpEmploymentEntity employment)
        {
            
            var oldEmpE = _appDbContext.EmpEmploymentInfo.Where(d => d.RegistrationID == employment.RegistrationID).FirstOrDefault();
            var conString = _configuration.GetConnectionString("DefaultConnection");
            if (oldEmpE != null)
            {
                oldEmpE.StaffNo = employment.StaffNo;
                oldEmpE.Branch = employment.Branch;
                oldEmpE.DateJoined = employment.DateJoined;
                oldEmpE.EmpLevel = employment.EmpLevel;
                oldEmpE.DateStarted = employment.DateStarted;
                oldEmpE.Designation = employment.Designation;
                oldEmpE.EmploymentType = employment.EmploymentType;
                oldEmpE.Department = employment.Department;
                oldEmpE.JobDescription = employment.JobDescription;
            }
            else
            {
                _appDbContext.EmpEmploymentInfo.Add(employment);
            }
            
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string sql = "Update tblUser set Department='" + employment.Department + "' where OtherID='" + employment.StaffNo + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            _appDbContext.SaveChanges();

            return new ServiceResponse<EmpEmploymentEntity>()
            {
                Data = employment,
                Message = "Employment Info Saved Successfully",
                Success = true,
            };
        }

        //Saving Employee Experience
        public async Task<ServiceResponse<EmpExperienceEntity>> SaveEmpExp(EmpExperienceEntity experience)
        {
            
            var oldEmpExp = _appDbContext.EmpExperiences.Where(d => d.RegistrationID == experience.RegistrationID).FirstOrDefault();
            if (oldEmpExp != null)
            {
                oldEmpExp.CompName = experience.CompName;
                oldEmpExp.JobPosition = experience.JobPosition;
                oldEmpExp.DJoined = experience.DJoined;
                oldEmpExp.DLeft = experience.DLeft;
            }
            else
            {
                _appDbContext.EmpExperiences.Add(experience);
            }
            
            await _appDbContext.SaveChangesAsync();
            return new ServiceResponse<EmpExperienceEntity>()
            {
                Data = experience,
                Message = "Employment Experience Saved Successfully",
                Success = true,
            };
        }

        //Saving Employee Qualification
        public async Task<ServiceResponse<EmpQualificationEntity>> SaveEmpQua(EmpQualificationEntity qualification)
        {
            
            var oldEmpQua = _appDbContext.EmpQualifications.Where(d => d.RegistrationID == qualification.RegistrationID).FirstOrDefault();
            if (oldEmpQua != null)
            {
                oldEmpQua.Institution = qualification.Institution;
                oldEmpQua.EducationQua = qualification.EducationQua;
                oldEmpQua.Year = qualification.Year;
            }
            else
            {
                _appDbContext.EmpQualifications.Add(qualification);
            }
            
            await _appDbContext.SaveChangesAsync();

            return new ServiceResponse<EmpQualificationEntity>()
            {
                Data = qualification,
                Message = "Employment qualification Saved Successfully",
                Success = true,
            };
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
