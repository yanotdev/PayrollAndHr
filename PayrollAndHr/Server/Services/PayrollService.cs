using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollAndHr.Server.Data;
using PayrollAndHr.Shared.Models;
using System;

namespace PayrollAndHr.Server.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly AppDbContext _context;

        public PayrollService(AppDbContext context)
        {
            _context = context;
        }

        public long GetNextDocumentNo(string description, long startNo)
        {
            long No = 0;
            
            var data = _context.StartDocumentNo.Where(d => d.Description == description).FirstOrDefault();
            if (data != null)
            {
                No = data.StartNo;
                No++;
                data.StartNo = No;
            }
            else
            {
                No = startNo;
                No++;
                StartDocumentNoEntity sdoc = new StartDocumentNoEntity();
                sdoc.Description = description;
                sdoc.StartNo = No;
                _context.StartDocumentNo.Add(sdoc);
            }
            _context.SaveChanges();
            return No;
        }
        //Save allowance
        public async Task<ServiceResponse<AllowanceEntity>> SaveAllowance(AllowanceEntity allowance)
        {
            var oldAll = _context.Allowances.Where(d => d.Code == allowance.Code).FirstOrDefault();
            if (oldAll != null)
            {
                oldAll.Description = allowance.Description;
                oldAll.AllType = allowance.AllType;
                oldAll.Percentage = allowance.Percentage;
                oldAll.Grade = allowance.Grade;
                oldAll.Period = allowance.Period;
            }
            else
            {
                _context.Allowances.Add(allowance);
            }
            await _context.SaveChangesAsync();

            return new ServiceResponse<AllowanceEntity>()
            {
                Data = allowance,
                Message = "Save Successful",
                Success = true,

            };
        }

        //Get all allowances
        public async Task<ServiceResponse<List<AllowanceEntity>>> LoadAllowances()
        {
            var data = _context.Allowances.OrderBy(d => d.Description).ToList();
            return new ServiceResponse<List<AllowanceEntity>>()
            {
                Data = data,
                Message = "Successful",
                Success = true,
            };
        }
        //edit Allowance
        public async Task<AllowanceEntity> EditAllowance(int Code)
        {
            var dept = _context.Allowances.Where(d => d.Code == Code).FirstOrDefault();
            return dept;              
        }

        
        public async Task<bool> DeleteAllowance(int Code)
        {
            
            var data = _context.Allowances.Where(d => d.Code == Code).FirstOrDefault();
            _context.Entry(data).State = EntityState.Deleted;
             await _context.SaveChangesAsync();

            return true;
             
        }
        public async Task<ServiceResponse<PensionEntity>> SavePension(PensionEntity pension)
        {
            
            var oldAll = _context.Pensions.Where(d => d.Code == pension.Code).FirstOrDefault();
            if (oldAll != null)
            {
                oldAll.Description = pension.Description;
                oldAll.EmployeePer = pension.EmployeePer;
                oldAll.EmployerPer = pension.EmployerPer;
            }
            else
            {
                _context.Pensions.Add(pension);
            }
            _context.SaveChanges();
            return new ServiceResponse<PensionEntity>()
            {
                Data = pension,
                Message = "Save Successful",
                Success = true,

            };
        }
        //get all pensions
        public async Task<ServiceResponse<List<PensionEntity>>> LoadPensions()
        {
            var data = _context.Pensions.OrderBy(d => d.Code).ToList();
            
            return new ServiceResponse<List<PensionEntity>>()
            {
                Data = data,
                Message = "Successful",
                Success = true,
            };
        }
        //Edit pension
        public async Task<PensionEntity> EditPension(int code)
        {
            var data = _context.Pensions.Where(d => d.Code == code).FirstOrDefault();
            return data;
        }
        //delete pension
        public async Task<bool> DeletePension(int Code)
        {

            var data = _context.Pensions.Where(d => d.Code == Code).FirstOrDefault();
            _context.Entry(data).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return true;

        }
        //Save loan
        public async Task<ServiceResponse<LoanEntity>> SaveLoan(LoanEntity loan)
        {
            
            var oldLoan = _context.Loans.Where(d => d.Code == loan.Code).FirstOrDefault();
            if (oldLoan != null)
            {
                oldLoan.Description = loan.Description;
                oldLoan.MinPay = loan.MinPay;
                oldLoan.MaxPay = loan.MaxPay;
            }
            else
            {
                _context.Loans.Add(loan);
            }
            _context.SaveChanges();

            return new ServiceResponse<LoanEntity>()
            {
                Data = loan,
                Message = "Save Successful",
                Success = true,

            };
        }

        //get loans        
        public async Task<ServiceResponse<List<LoanEntity>>> LoadLoans()
        {
            var data = _context.Loans.OrderBy(d => d.Code).ToList();
            return new ServiceResponse<List<LoanEntity>>()
            {
                Data = data,
                Message = "Successful",
                Success = true,
            };
        }
        //Edit loans
        public async Task<LoanEntity> EditLoans(int code)
        {
            var data = _context.Loans.Where(d => d.Code == code).FirstOrDefault();
            return data;
        }

        //delete loans
        public async Task<bool> DeleteLoans(int Code)
        {

            var data = _context.Loans.Where(d => d.Code == Code).FirstOrDefault();
            _context.Entry(data).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return true;

        }
        //save penalty
        public async Task<ServiceResponse<PenaltyEntity>> SavePenalty(PenaltyEntity penalty)
        {
            
            var oldPe = _context.Penalties.Where(d => d.Code == penalty.Code).FirstOrDefault();
            if (oldPe != null)
            {
                oldPe.Description = penalty.Description;
                oldPe.Percentage = penalty.Percentage;
                oldPe.DeductType = penalty.DeductType;
            }
            else
            {
                _context.Penalties.Add(penalty);
            }
            _context.SaveChanges();

            return new ServiceResponse<PenaltyEntity>()
            {
                Data = penalty,
                Message = "Save Successful",
                Success = true,

            };
        }

        //get penalties
        public async Task<ServiceResponse<List<PenaltyEntity>>> LoadPenalties()
        {
            var data = _context.Penalties.OrderBy(d => d.Code).ToList();
            return new ServiceResponse<List<PenaltyEntity>>()
            {
                Data = data,
                Message = "Successful",
                Success = true,
            };
        }

        //Edit penalty
        public async Task<PenaltyEntity> EditPenalty(int code)
        {
            var data = _context.Penalties.Where(d => d.Code == code).FirstOrDefault();
            return data;
        }

        //delete penalty
        public async Task<bool> DeletePenalty(int Code)
        {

            var data = _context.Penalties.Where(d => d.Code == Code).FirstOrDefault();
            _context.Entry(data).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return true;

        }
        //Save Other Allowance
        public async Task<ServiceResponse<OtherAllowancesEntity>> SaveOtherAllowance(OtherAllowancesEntity otherAllowances)
        {
           
            var oldAllowance = _context.otherAllowances.Where(d => d.Code == otherAllowances.Code).FirstOrDefault();
            if (oldAllowance != null)
            {
                oldAllowance.Description = otherAllowances.Description;


            }
            else
            {
                _context.otherAllowances.Add(otherAllowances);
            }
            _context.SaveChanges();

            return new ServiceResponse<OtherAllowancesEntity>()
            {
                Data = otherAllowances,
                Message = "Save Successful",
                Success = true,

            };
        }
        //get other allowances
        public async Task<ServiceResponse<List<OtherAllowancesEntity>>> LoadOtherAllowances()
        {
            var data = _context.otherAllowances.OrderBy(d => d.Code).ToList();
            return new ServiceResponse<List<OtherAllowancesEntity>>()
            {
                Data = data,
                Message = "Successful",
                Success = true,
            };
        }
        //Edit other allowances
        public async Task<OtherAllowancesEntity> EditOtherAllowances(int code)
        {
            var data = _context.otherAllowances.Where(d => d.Code == code).FirstOrDefault();
            return data;
        }

        //delete other allowances
        public async Task<bool> DeleteOtherAllowances(int Code)
        {

            var data = _context.otherAllowances.Where(d => d.Code == Code).FirstOrDefault();
            _context.Entry(data).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return true;

        }
        //load all staff
        public async Task<List<PersonalInformationEntity>> LoadAllStaff()
        {
            var result = _context.PersonalInfo.OrderBy(d => d.StaffNo).ToList();
            return result;
        }
        //load allowance type and percent value
        public async Task<List<AllowanceEntity>>LoadAllowanceType(string descript)
        {
            var model = _context.Allowances.Where(d => d.Description == descript).ToList();
            return model;
        }
        //Load all description
        public async Task<List<AllowanceEntity>> LoadAllType(string type)
        {
            var model = _context.Allowances.Where(d => d.AllType == type).OrderBy(d => d.Code).ToList();
            return model;
        }
        //save salary
        public async Task<ServiceResponse<SalaryEntity>> SaveSalary(SalaryEntity salary)
        {
            
            var save = _context.Salaries.Where(d => d.StaffNo == salary.StaffNo).FirstOrDefault();

            if (save != null)
            {

                save.StaffNo = salary.StaffNo;
                save.StaffName = salary.StaffName;
                save.Period = salary.Period;
                save.BasicDescription = salary.BasicDescription;
                save.HousingDescription = salary.HousingDescription;
                save.TransportDescription = salary.TransportDescription;
                save.UtilityDescription = salary.UtilityDescription;
                save.LunchDescription = salary.LunchDescription;
                save.OtherDescription = salary.OtherDescription;
                save.BasicType = salary.BasicType;
                save.HousingType = salary.HousingType;
                save.TransportType = salary.TransportType;
                save.UtilityType = salary.UtilityType;
                save.LunchType = salary.LunchType;
                save.OtherType = salary.OtherType;
                save.BasicPer = salary.BasicPer;
                save.HousingPer = salary.HousingPer;
                save.TransportPer = salary.TransportPer;
                save.UtilityPer = salary.UtilityPer;
                save.LunchPer = salary.LunchPer;
                save.OtherPer = salary.OtherPer;
                save.BasicAmt = salary.BasicAmt;
                save.HousingAmt = salary.HousingAmt;
                save.TransportAmt = salary.TransportAmt;
                save.UtilityAmt = salary.UtilityAmt;
                save.LunchAmt = salary.LunchAmt;
                save.OtherAmt = salary.OtherAmt;
                save.Amount = salary.Amount;

            }
            else
            {

                _context.Salaries.Add(salary);

            }
            await _context.SaveChangesAsync();
            return new ServiceResponse<SalaryEntity>()
            {
                Data = salary,
                Message = "Save Successful",
                Success = true,

            };            

        }
        //Loading Staff Salary Initial Setup     
        public async Task<ServiceResponse<SalaryEntity>> LoadStaffSalary(string staffID)
        {
           
            var model = _context.Salaries.Where(d => d.StaffNo == staffID).FirstOrDefault();
            return new ServiceResponse<SalaryEntity>()
            {
                Data = model,
                Message = "Save Successful",
                Success = true,

            };
        }
        //Save Staff loan
        public async Task<ServiceResponse<StaffLoanEntity>> SaveStaffLoan(StaffLoanEntity indiviLoan)
        {

           
            var loan = _context.StaffLoans.Where(d => d.LoanType == indiviLoan.LoanType && d.LoanAmount == indiviLoan.LoanAmount && d.Installment == indiviLoan.Installment).FirstOrDefault();
            if (loan != null)
            {
                loan.StaffNo = indiviLoan.StaffNo;
                loan.StaffName = indiviLoan.StaffName;
                loan.NetSalary = indiviLoan.NetSalary;
                loan.LoanType = indiviLoan.LoanType;
                loan.LoanAmount = indiviLoan.LoanAmount;
                loan.Interest = indiviLoan.Interest;
                loan.TotalLoanAmount = indiviLoan.TotalLoanAmount;
                loan.Installment = indiviLoan.Installment;
                loan.Repayment = indiviLoan.Repayment;
                loan.Date = DateTime.Now;

            }
            else
            {
                _context.StaffLoans.Add(indiviLoan);
            }

            await _context.SaveChangesAsync();
            return new ServiceResponse<StaffLoanEntity>()
            {
                Data = indiviLoan,
                Message = "Save Successful",
                Success = true,

            };
         
        }

        //save staff deductions
        public async Task<ServiceResponse<DeductionEntity>> Savededuct(DeductionEntity staffDeduction)
        {
            DeductionEntity newDeduct = new DeductionEntity();
            newDeduct.StaffNo = staffDeduction.StaffNo;
            newDeduct.StaffName = staffDeduction.StaffName;
            newDeduct.PenaltyType = staffDeduction.PenaltyType;
            newDeduct.DeductionType = staffDeduction.DeductionType;
            newDeduct.Amount = staffDeduction.Amount;
            newDeduct.Date = DateTime.Now;
            _context.StaffDeductions.Add(newDeduct);
            _context.SaveChanges();

            return new ServiceResponse<DeductionEntity>()
            {
                Data = newDeduct,
                Message = "Save Successful",
                Success = true,

            };

        }

        //load staff penalty
        public async Task<List<DeductionEntity>> LoadStaffPenalty(string StaffID)
        {
            var data = _context.StaffDeductions.Where(d => d.StaffNo == StaffID).ToList();
            return data;
        }
        //edit staff deductions
        public async Task<DeductionEntity> EditDeductions(int ID)
        {
            var ded = _context.StaffDeductions.Where(d => d.ID == ID).FirstOrDefault();
            return ded;
        }

        //delete staff deductions
        public async Task<bool> DeletePen(int ID)
        {
            bool check = false; 
            var emp = _context.StaffDeductions.Where(d => d.ID == ID).FirstOrDefault();
            _context.StaffDeductions.Remove(emp);
            check = true;
            
            await _context.SaveChangesAsync();
            return check;
        }
        //load staff loan

        public async Task<List<StaffLoanEntity>> LoadStaffLoan(string StaffID)
        {
            var data = _context.StaffLoans.Where(d => d.StaffNo == StaffID).ToList();
            return data;
        }

        //edit staff loan
        public async Task<StaffLoanEntity> EditStaffLoan(int ID)
        {
            int newCode = Convert.ToInt32(ID);
            var dept = _context.StaffLoans.Where(d => d.ID == newCode).FirstOrDefault();
            return dept;
        }
        //delete staff loan
        public async Task<bool> DeleteStaffLoan(int ID)
        {
            int newCode = Convert.ToInt32(ID);
            bool check = false; 
           
            var data = _context.StaffLoans.Where(d => d.ID == newCode).FirstOrDefault();
            _context.StaffLoans.Remove(data);
            _context.SaveChanges();
            check = true;


            return check;
        }
        //save staff other allowances
        public async Task<ServiceResponse<StaffOtherAllowancesEntity>> SaveStaffOtherAllowance(StaffOtherAllowancesEntity staff)
        {
            
            //var allCode = db.otherAllowances.Where(d=>d.Description == staff.AllowanceType).FirstOrDefault();
            var oldAll = _context.staffOtherAllowances.Where(d => d.AllowanceCode == staff.AllowanceCode && d.StaffNo == staff.StaffNo).FirstOrDefault();
            if (oldAll != null)
            {
                oldAll.StaffNo = staff.StaffNo;
                oldAll.AllowanceCode = staff.AllowanceCode;
                oldAll.Amount = staff.Amount;
                oldAll.Status = true;
                oldAll.AllowanceType = staff.AllowanceType;
            }
            else
            {

                _context.staffOtherAllowances.Add(staff);
            }
            await _context.SaveChangesAsync();

            return new ServiceResponse<StaffOtherAllowancesEntity>()
            {
                Data = staff,
                Message = "Save Successful",
                Success = true,
            };
        }
        //load staff other allowances
        public async Task<List<StaffOtherAllowancesEntity>> LoadStaffOtherAllowances(string StaffID)
        {
            var data = _context.staffOtherAllowances.Where(d => d.StaffNo == StaffID).ToList();
            return data;
        }
        //edit staff other allowances
        public async Task<StaffOtherAllowancesEntity> EditStaffOthers(int ID)
        {
            int newCode = Convert.ToInt32(ID);
            var dept = _context.staffOtherAllowances.Where(d => d.ID == newCode).FirstOrDefault();
            return dept;
        }

        //delete staff other allowances
        public async Task<bool> DeleteStaffOthers(int ID)
        {
            int newCode = Convert.ToInt32(ID);
            bool check = false;

            var data = _context.staffOtherAllowances.Where(d => d.ID == newCode).FirstOrDefault();
            _context.staffOtherAllowances.Remove(data);
            _context.SaveChanges();
            check = true;


            return check;
        }
        //SAVE STAFF AVC
        //SAVE THE STAFF AVC 
        public async Task<ServiceResponse<StaffAVCEntity>> SaveAvc(string StaffID, string AVC)
        {
            StaffAVCEntity staffAVC = new StaffAVCEntity();
            var oldavc = _context.staffAVC.Where(d => d.StaffID == StaffID).FirstOrDefault();
            if (oldavc != null)
            {
                oldavc.StaffID = StaffID;
                oldavc.AVC = AVC;

            }
            else
            {
                
                staffAVC.StaffID = StaffID;
                staffAVC.AVC = AVC;
                _context.staffAVC.Add(staffAVC);
            }
            await _context.SaveChangesAsync();
            return new ServiceResponse<StaffAVCEntity>()
            {
                Data = staffAVC,
                Message = "Save Successful",
                Success = true,

            };

        }
        public async Task<List<StaffAVCEntity>> GetStaffAVC(string StaffID)
        {
            var data = _context.staffAVC.Where(p => p.StaffID == StaffID).ToList();
            return data;
        }
        public async Task<StaffAVCEntity> EditStaffAVC(int ID)
        {
            int newCode = Convert.ToInt32(ID);
            var dept = _context.staffAVC.Where(d => d.ID == newCode).FirstOrDefault();
            return dept;
        }

        //delete staff other allowances
        public async Task<bool> DeleteStaffAVC(int ID)
        {
            int newCode = Convert.ToInt32(ID);
            bool check = false;

            var data = _context.staffAVC.Where(d => d.ID == newCode).FirstOrDefault();
            _context.staffAVC.Remove(data);
            _context.SaveChanges();
            check = true;


            return check;
        }

        public async Task<ServiceResponse<PAYEEntity>> SaveStaffPayE(PAYEEntity paye)
        {
            
            //var DedSta = db.StaffDeductions.Where(d => d.StaffNo == sID);
            var newPayE = _context.PayE.Where(d => d.StaffID == paye.StaffID).FirstOrDefault();
            if (newPayE != null)
            {

                newPayE.StaffID = paye.StaffID;
                newPayE.StaffName = paye.StaffName;
                newPayE.PayPeriod = paye.PayPeriod;
                newPayE.NetSalary = paye.NetSalary;
                newPayE.Basic = paye.Basic;
                newPayE.Housing = paye.Housing;
                newPayE.Transport = paye.Transport;
                newPayE.Lunch = paye.Lunch;
                newPayE.Utility = paye.Utility;
                newPayE.Others = paye.Others;
                newPayE.LoanDeduct = paye.LoanDeduct;
                newPayE.PenaltyDeduct = paye.PenaltyDeduct;
                newPayE.Pension = paye.Pension;
                newPayE.NationalHFC = paye.NationalHFC;
                newPayE.ConsolidatedR = paye.ConsolidatedR;
                newPayE.Date = DateTime.Now;
                newPayE.NetTIncome = paye.NetTIncome;
                newPayE.GrossSalary = paye.GrossSalary;
                newPayE.TDeduction = paye.TDeduction;
                newPayE.TNonTDeduction = paye.TNonTDeduction;
                newPayE.CalPayE = paye.CalPayE;

            }
            else
            {

                _context.PayE.Add(paye);
            }

            await _context.SaveChangesAsync();
            return new ServiceResponse<PAYEEntity>()
            {
                Data = paye,
                Message = "Save Successful",
                Success = true,
            };

        }
        //load from Salary table with ID
       
        public async Task<List<SalaryEntity>> LoadALL(string sID)
        {
            var data = _context.Salaries.Where(d => d.StaffNo == sID && d.Period == "Monthly").ToList();
            return data;
        }

        //load from Salary table with ID
        
        public async Task<List<SalaryEntity>> LoadALLAnnual(string sID)
        {
            var data = _context.Salaries.Where(d => d.StaffNo == sID && d.Period == "Annually").ToList();
            return data;
        }
    }
}
