using Microsoft.AspNetCore.Components.Web.Extensions.Head;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollAndHr.Server.Data;
using PayrollAndHr.Shared.Models;

namespace PayrollAndHr.Server.Services
{
    public class SetUpService : ISetUpService
    {
        private readonly AppDbContext _appDbContext;

        public SetUpService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

       

        public List<BranchEntity> LoadBranchInfo()
        {
            var model = _appDbContext.Branches.Where(d => d.IsDeleted == false).OrderBy(d => d.BranchName).ToList();
            return model;
        }

        public async Task<ServiceResponse<BranchEntity>> SaveBranchInfo(BranchEntity Bra)
        {
            var oldBra = _appDbContext.Branches.Where(d => d.BranchCode == Bra.BranchCode).FirstOrDefault();
            BranchEntity newBra = new BranchEntity();
            if (oldBra != null)
            {
                oldBra.Address = Bra.Address;
                //oldBra.BranchCode = bra.BranchCode;
                oldBra.BranchName = Bra.BranchName;
                oldBra.Email = Bra.Email;
                oldBra.PhoneNo = Bra.PhoneNo;

            }
            else
            {
                
                newBra.Address = Bra.Address;
                newBra.BranchCode = Bra.BranchCode;
                newBra.BranchName = Bra.BranchName;
                newBra.Email = Bra.Email;
                newBra.PhoneNo = Bra.PhoneNo;
                _appDbContext.Branches.Add(newBra);
            }
            await _appDbContext.SaveChangesAsync();
            return new ServiceResponse<BranchEntity>()
            {
                Data = newBra,
                Message = "Save Successful",
                Success = true,
            };
        }
        //load branch info
        public async Task<List<BranchEntity>> LoadAllBranchInfo()
        {
            var data = _appDbContext.Branches.Where(d => d.IsDeleted == false).OrderBy(d => d.BranchName).ToList();
            return data;
        }
        //delete branch
        public async Task<bool> DeleteBranch(int Code)
        {
            bool check = false;
            try
            {
                var data = _appDbContext.Branches.Where(d => d.BranchCode == Code).FirstOrDefault();
                _appDbContext.Branches.Remove(data);
                await _appDbContext.SaveChangesAsync();
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
            }
            return check;
        }

        //edit branch
        public async Task<BranchEntity> EditBranchInfo(int BranchCode)
        {
            var branch = _appDbContext.Branches.Where(d => d.BranchCode == BranchCode).FirstOrDefault();
            return branch;
        }
        //Save Titles
        public async Task<ServiceResponse<TitleEntity>> SaveTitles(TitleEntity title)
        {
           
            var oldTitle = _appDbContext.Titles.Where(d => d.Code == title.Code).FirstOrDefault();
            if (oldTitle == null)
            {
                TitleEntity newTitle = new TitleEntity();
                newTitle.Code = title.Code;
                newTitle.Description = title.Description;
                _appDbContext.Titles.Add(newTitle);

            }
            else
            {
                // oldTitle.Code = title.Code;
                oldTitle.Description = title.Description;

            }
            _appDbContext.SaveChanges();
            return new ServiceResponse<TitleEntity>()
            {
                Data = title,
                Message = "Save Successful",
                Success = true,
            };
        }
        //load all Titles
       
        public async Task<List<TitleEntity>> LoadAllTitles()
        {
            var data = _appDbContext.Titles.OrderBy(d => d.Description).ToList();
            return data;
        }
        //delete all titles
        public async Task<bool> DeleteTitle(int Code)
        {
            bool check = false;
            try
            {
                var data = _appDbContext.Titles.Where(d => d.Code == Code).FirstOrDefault();
                _appDbContext.Titles.Remove(data);
                await _appDbContext.SaveChangesAsync();
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
            }
            return check;
        }

        //edit title
        public async Task<TitleEntity> EditTitle(int Code)
        {
            var title = _appDbContext.Titles.Where(d => d.Code == Code).FirstOrDefault();
            return title;
        }
        //Save Levels
        public async Task<ServiceResponse<LevelEntity>> SaveLevels(LevelEntity level)
        {
          
            var oldLevel = _appDbContext.Levels.Where(d => d.Code == level.Code).FirstOrDefault();
            if (oldLevel == null)
            {

                _appDbContext.Levels.Add(level);

            }
            else
            {
                oldLevel.Description = level.Description;
            }
            _appDbContext.SaveChanges();
            return new ServiceResponse<LevelEntity>()
            {
                Data = level,
                Message = "Save Successful",
                Success = true,
            };
        }
        //Load levels
        public async Task<List<LevelEntity>> LoadAllLevels()
        {
            var data = _appDbContext.Levels.OrderBy(d => d.Description).ToList();
            return data;
        }
        //delete all levels
        public async Task<bool> DeleteLevel(int Code)
        {
            bool check = false;
            try
            {
                var data = _appDbContext.Levels.Where(d => d.Code == Code).FirstOrDefault();
                _appDbContext.Levels.Remove(data);
                await _appDbContext.SaveChangesAsync();
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
            }
            return check;
        }

        //edit level
        public async Task<LevelEntity> EditLevel(int Code)
        {
            var level = _appDbContext.Levels.Where(d => d.Code == Code).FirstOrDefault();
            return level;
        }
        //Save Employee Type
        public async Task<ServiceResponse<EmploymentTypeEntity>> SaveEmpType(EmploymentTypeEntity emp)
        {
           
            var empType = _appDbContext.EmployementType.Where(d => d.Code == emp.Code).FirstOrDefault();
            if (empType == null)
            {
                _appDbContext.EmployementType.Add(emp);

            }
            else
            {
                empType.Description = emp.Description;
            }
            _appDbContext.SaveChanges();
            return new ServiceResponse<EmploymentTypeEntity>()
            {
                Data = emp,
                Message = "Save Successful",
                Success = true,
            };
        }
        //Load Emp Type
        public async Task<List<EmploymentTypeEntity>> LoadAllEmpType()
        {
            var data = _appDbContext.EmployementType.OrderBy(d => d.Description).ToList();
            return data;
        }
        //delete all emp type
        public async Task<bool> DeleteEmpType(int Code)
        {
            bool check = false;
            try
            {
                var data = _appDbContext.EmployementType.Where(d => d.Code == Code).FirstOrDefault();
                _appDbContext.EmployementType.Remove(data);
                await _appDbContext.SaveChangesAsync();
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
            }
            return check;
        }

        //edit emp type
        public async Task<EmploymentTypeEntity> EditEmpType(int Code)
        {
            var emptype = _appDbContext.EmployementType.Where(d => d.Code == Code).FirstOrDefault();
            return emptype;
        }
        //Save Staff Dept
        public async Task<ServiceResponse<DepartmentEntity>> SaveDept(DepartmentEntity dept)
        {
            
            var oldDept = _appDbContext.Depts.Where(d => d.DeptCode == dept.DeptCode).FirstOrDefault();
            if (oldDept == null)
            {
                _appDbContext.Depts.Add(dept);
            }
            else
            {
                oldDept.Description = dept.Description;
            }
            _appDbContext.SaveChanges();
            return new ServiceResponse<DepartmentEntity>()
            {
                Data = dept,
                Message = "Save Successful",
                Success = true,
            };
        }
        //Load Department
        public async Task<List<DepartmentEntity>> LoadAllDepartment()
        {
            var data = _appDbContext.Depts.OrderBy(d => d.Description).ToList();
            return data;
        }
        //delete all department
        public async Task<bool> DeleteDepartment(int Code)
        {
            bool check = false;
            try
            {
                var data = _appDbContext.Depts.Where(d => d.DeptCode == Code).FirstOrDefault();
                _appDbContext.Depts.Remove(data);
                await _appDbContext.SaveChangesAsync();
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
            }
            return check;
        }

        //edit Department
        public async Task<DepartmentEntity> EditDepartment(int Code)
        {
            var dept = _appDbContext.Depts.Where(d => d.DeptCode == Code).FirstOrDefault();
            return dept;
        }
        //Save Designation
        public async Task<ServiceResponse<DesignationEntity>> SaveDesignation(DesignationEntity Desg)
        {
           
            var oldDes = _appDbContext.Designations.Where(d => d.Code == Desg.Code).FirstOrDefault();
            if (oldDes != null)
            {
                oldDes.Description = Desg.Description;
            }
            else
            {
                _appDbContext.Designations.Add(Desg);
            }
            _appDbContext.SaveChanges();

            return new ServiceResponse<DesignationEntity>()
            {
                Data = Desg,
                Message = "Save Successful",
                Success = true,
            };
        }
        //Load Designation
        public async Task<List<DesignationEntity>> LoadAllDesignation()
        {
            var data = _appDbContext.Designations.OrderBy(d => d.Description).ToList();
            return data;
        }
        //delete all designations
        public async Task<bool> DeleteDesignation(int Code)
        {
            bool check = false;
            try
            {
                var data = _appDbContext.Designations.Where(d => d.Code == Code).FirstOrDefault();
                _appDbContext.Designations.Remove(data);
                await _appDbContext.SaveChangesAsync();
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
            }
            return check;
        }

        //edit Designations
        public async Task<DesignationEntity> EditDesignations(int Code)
        {
            var desig = _appDbContext.Designations.Where(d => d.Code == Code).FirstOrDefault();
            return desig;
        }
        //Save Academic Degree
        public async Task<ServiceResponse<DegreeEntity>> SaveDegrees(DegreeEntity Degree)
        {
            
            var OldDeg = _appDbContext.Degrees.Where(d => d.Code == Degree.Code).FirstOrDefault();
            if (OldDeg != null)
            {
                OldDeg.Description = Degree.Description;
            }
            else
            {
                _appDbContext.Degrees.Add(Degree);
            }
            _appDbContext.SaveChanges();
            return new ServiceResponse<DegreeEntity>()
            {
                Data = Degree,
                Message = "Save Successful",
                Success = true,
            };
        }
        //Load Academic degree
        public async Task<List<DegreeEntity>> LoadAllDegrees()
        {
            var data = _appDbContext.Degrees.OrderBy(d => d.Description).ToList();
            return data;
        }
        //delete all degrees
        public async Task<bool> DeleteDegree(int Code)
        {
            bool check = false;
            try
            {
                var data = _appDbContext.Degrees.Where(d => d.Code == Code).FirstOrDefault();
                _appDbContext.Degrees.Remove(data);
                await _appDbContext.SaveChangesAsync();
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
            }
            return check;
        }

        //edit Degrees
        public async Task<DegreeEntity> EditDegrees(int Code)
        {
            var degree = _appDbContext.Degrees.Where(d => d.Code == Code).FirstOrDefault();
            return degree;
        }
    }
}
