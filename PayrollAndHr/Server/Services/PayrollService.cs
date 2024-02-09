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
    }
}
