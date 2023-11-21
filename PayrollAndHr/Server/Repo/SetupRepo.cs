using Microsoft.EntityFrameworkCore;
using PayrollAndHr.Server.Data;
using PayrollAndHr.Shared.Models;

namespace PayrollAndHr.Server.Repo
{
    public class SetupRepo
    {
        private readonly AppDbContext _context;
        public SetupRepo(AppDbContext context)
        {
            _context = context;
        }

        //saving branch Information
        public static void SaveBranchInfo(BranchEntity bra)
        {
            var oldBra = _context.Branches.Where(d => d.BranchCode == bra.BranchCode).FirstOrDefault();
            if (oldBra != null)
            {
                oldBra.Address = bra.Address;
                //oldBra.BranchCode = bra.BranchCode;
                oldBra.BranchName = bra.BranchName;
                oldBra.Email = bra.Email;
                oldBra.PhoneNo = bra.PhoneNo;

            }
            else
            {
                BranchEntity newBra = new BranchEntity();
                newBra.Address = bra.Address;
                newBra.BranchCode = bra.BranchCode;
                newBra.BranchName = bra.BranchName;
                newBra.Email = bra.Email;
                newBra.PhoneNo = bra.PhoneNo;
                _context.Branches.Add(newBra);
            }
            _context.SaveChanges();

        }
        //delete branch Info
        public static void deleteBranch(int BranchCode)
        {
            bool check = false;
            var emp = _context.EmployeeInfo.Where(d => d.BranchCode == BranchCode).FirstOrDefault();
            if (emp != null)
            {
                check = true;
            }
            var bra = _context.Branches.Where(d => d.BranchCode == BranchCode).FirstOrDefault();
            if (bra != null)
            {
                if (check)
                {
                    bra.IsDeleted = true;
                }
                else
                {
                    _context.Branches.Remove(bra);
                }

            }
            _context.SaveChanges();
        }

        //saving titles
        public static void SaveTitles(TitleEntity title)
        {
            var oldTitle = _context.Titles.Where(d => d.Code == title.Code).FirstOrDefault();
            if (oldTitle == null)
            {
                TitleEntity newTitle = new TitleEntity();
                newTitle.Code = title.Code;
                newTitle.Description = title.Description;
                _context.Titles.Add(newTitle);

            }
            else
            {
                // oldTitle.Code = title.Code;
                oldTitle.Description = title.Description;

            }
            _context.SaveChanges();
        }

        //Save Levels
        public static void SaveLevels(LevelEntity level)
        {
            var oldLevel = _context.Levels.Where(d => d.Code == level.Code).FirstOrDefault();
            if (oldLevel == null)
            {

                _context.Levels.Add(level);

            }
            else
            {
                oldLevel.Description = level.Description;
            }
            _context.SaveChanges();
        }
        //Save Employee Type
        public static void SaveEmpType(EmploymentTypeEntity emp)
        {
            var empType = _context.EmployementType.Where(d => d.Code == emp.Code).FirstOrDefault();
            if (empType == null)
            {
                _context.EmployementType.Add(emp);

            }
            else
            {
                empType.Description = emp.Description;
            }
            _context.SaveChanges();
        }
        //Save Staff Dept
        public static void SaveDept(DepartmentEntity dept)
        {
            var oldDept = _context.Depts.Where(d => d.DeptCode == dept.DeptCode).FirstOrDefault();
            if (oldDept == null)
            {
                _context.Depts.Add(dept);
            }
            else
            {
                oldDept.Description = dept.Description;
            }
            _context.SaveChanges();
        }

        //Save Designation
        public static void SaveDesignation(DesignationEntity Desg)
        {
            var oldDes = _context.Designations.Where(d => d.Code == Desg.Code).FirstOrDefault();
            if (oldDes != null)
            {
                oldDes.Description = Desg.Description;
            }
            else
            {
                _context.Designations.Add(Desg);
            }
            _context.SaveChanges();
        }
        //Save Academic Degree
        public static void SaveDegrees(DegreeEntity Degree)
        {
            var OldDeg = _context.Degrees.Where(d => d.Code == Degree.Code).FirstOrDefault();
            if (OldDeg != null)
            {
                OldDeg.Description = Degree.Description;
            }
            else
            {
                _context.Degrees.Add(Degree);
            }
            _context.SaveChanges();
        }
    }
}
