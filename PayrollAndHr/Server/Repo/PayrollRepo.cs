using Microsoft.EntityFrameworkCore;
using PayrollAndHr.Server.Data;
using PayrollAndHr.Shared.Models;

namespace PayrollAndHr.Server.Repo
{
    public class PayrollRepo
    {
        private readonly AppDbContext _context;

        public PayrollRepo(AppDbContext context)
        {
            _context = context;
        }

        //Save Allowance
        public void SaveAllowance(AllowanceEntity allowance)
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
            _context.SaveChanges();
        }
        //Save Pension
        public void SavePension(PensionEntity pension)
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
        }

        public void SaveStaffOtherAllowance(StaffOtherAllowancesEntity staff)
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
            _context.SaveChanges();
        }
        //Save Loan
        public void SaveLoan(LoanEntity loan)
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
        }
        //Save Penalty
        public void SavePenalty(PenaltyEntity penalty)
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
        }
        //Save Other Allowances
        public void SaveOtherAllowance(OtherAllowancesEntity otherAllowances)
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
        }
        //Save Salary
        public void SaveSalary(SalaryEntity salary)
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
            _context.SaveChanges();
        }

        //Save Staff loan
        public void SaveStaffLoan(StaffLoanEntity indiviLoan)
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

            _context.SaveChanges();
        }

        //SAVE THE STAFF AVC 
        public void SaveAvc(string StaffID, string AVC)
        {
            var oldavc = _context.staffAVC.Where(d => d.StaffID == StaffID).FirstOrDefault();
            if (oldavc != null)
            {
                oldavc.StaffID = StaffID;
                oldavc.AVC = AVC;
            }
            else
            {
                StaffAVCEntity staffAVC = new StaffAVCEntity();
                staffAVC.StaffID = StaffID;
                staffAVC.AVC = AVC;
                _context.staffAVC.Add(staffAVC);
            }
            _context.SaveChanges();
        }
        //Save Staff deduction
        public void Savededuct(DeductionEntity staffDeduction)
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
        }

        //Saving generated Staff PAYE
        public void SaveStaffPayE(PAYEEntity paye)
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

            _context.SaveChanges();

        }
        public decimal GetPension(string StaffID)
        {
            PAYEEntity pAYE = _context.PayE.Where(d => d.StaffID == StaffID).FirstOrDefault();
            decimal code = 0;
            if (pAYE != null)
            {
                code = pAYE.Pension;
            }
            return code;
        }
        public decimal GetOtherDeductions(string StaffID)
        {
            PAYEEntity pAYE = _context.PayE.Where(d => d.StaffID == StaffID).FirstOrDefault();
            decimal code = 0;
            if (pAYE != null)
            {
                code = pAYE.LoanDeduct + pAYE.PenaltyDeduct;
            }
            return code;
        }
        public decimal GetOtherAllowance(string StaffID)
        {
            var pAYE = _context.staffOtherAllowances.Where(d => d.StaffNo == StaffID).ToList();
            decimal amount = 0;
            if (pAYE.Count != 0)
            {
                foreach (var d in pAYE)
                {
                    amount += decimal.Parse(d.Amount);
                }

            }
            return amount;
        }
        public decimal GetNetPayment(string StaffID)
        {
            PAYEEntity pAYE = _context.PayE.Where(d => d.StaffID == StaffID).FirstOrDefault();
            decimal code = 0;
            if (pAYE != null)
            {
                code = pAYE.NetSalary;
            }
            return code;
        }
        public decimal GetPayeeTax(string StaffID)
        {
            PAYEEntity pAYE = _context.PayE.Where(d => d.StaffID == StaffID).FirstOrDefault();
            decimal code = 0;
            if (pAYE != null)
            {
                code = pAYE.CalPayE;
            }
            return code;
        }

        public string GetEmployeeDesignation(string StaffID)
        {
            string designation = "";
            EmployeeInfoEntity emp = _context.EmployeeInfo.Where(d => d.StaffNo == StaffID).FirstOrDefault();
            if (emp != null)
            {
                designation = emp.Designation;
            }
            return designation;
        }
        public string GetEmployeeDaprtment(string StaffID)
        {
            string deptCode = "";
            EmployeeInfoEntity emp = _context.EmployeeInfo.Where(d => d.StaffNo == StaffID).FirstOrDefault();
            if (emp != null)
            {
                deptCode = GetEmployeeDaprtmentWithCode(emp.DeptCode);
            }
            return deptCode;
        }
        public string GetEmployeeDaprtmentWithCode(int deptCode)
        {
            string department = "";
            DepartmentEntity emp = _context.Depts.Where(d => d.DeptCode == deptCode).FirstOrDefault();
            if (emp != null)
            {
                department = emp.Description;
            }
            return department;
        }
        public void GeneratePayroll(string month)
        {
            //_context.Database.ExecuteSqlInterpolated($"TRUNCATE TABLE tblPayroll"); 
            var salaries = _context.Salaries.Where(d => d.StaffNo == d.StaffNo).ToList().OrderBy(d => d.StaffNo);
            foreach (var salary in salaries)
            {
                decimal otherStaffAllow = GetOtherAllowance(salary.StaffNo);
                PayrollEntity payroll = new PayrollEntity();
                payroll.StaffID = salary.StaffNo;
                payroll.StaffName = salary.StaffName;
                payroll.Designation = GetEmployeeDesignation(salary.StaffNo);
                payroll.Department = GetEmployeeDaprtment(salary.StaffNo);
                payroll.GrossPayWithoutAllowance = salary.Amount;
                payroll.Basic = salary.BasicAmt;
                payroll.HousingAllowance = salary.HousingAmt;
                payroll.TransportAllowance = salary.TransportAmt;
                payroll.LunchAllowance = salary.LunchAmt;
                payroll.OtherAllowance = otherStaffAllow;
                payroll.GrossPay = salary.Amount;
                payroll.Pension = GetPension(salary.StaffNo);
                payroll.OtherDeductions = GetOtherDeductions(salary.StaffNo);
                payroll.Remarks = "";
                payroll.PayeeTax = GetPayeeTax(salary.StaffNo);
                decimal totalD = GetPension(salary.StaffNo) + GetOtherDeductions(salary.StaffNo) + GetPayeeTax(salary.StaffNo);
                payroll.TotalDeduction = totalD;
                decimal NetCal = salary.Amount - totalD + otherStaffAllow;
                payroll.Net = NetCal;
                payroll.Month = month + " " + DateTime.Now.Year;
                _context.Payroll.Add(payroll);
                _context.SaveChanges();
            }


        }

        public void SavePayrollHistory(string month)
        {
            string Month = month + " " + DateTime.Now.Year;
            var payrollData = _context.Payroll.Where(d => d.Month == Month).ToList();
            foreach (var data in payrollData)
            {
                PayrollHistoryEntity payrollHistory = new PayrollHistoryEntity();
                payrollHistory.StaffID = data.StaffID;
                payrollHistory.StaffName = data.StaffName;
                payrollHistory.Designation = data.Designation;
                payrollHistory.Department = data.Department;
                payrollHistory.GrossPayWithoutAllowance = data.GrossPayWithoutAllowance;
                payrollHistory.Basic = data.Basic;
                payrollHistory.HousingAllowance = data.HousingAllowance;
                payrollHistory.TransportAllowance = data.TransportAllowance;
                payrollHistory.LunchAllowance = data.LunchAllowance;
                payrollHistory.OtherAllowance = data.OtherAllowance;
                payrollHistory.GrossPay = data.GrossPay;
                payrollHistory.Pension = data.Pension;
                payrollHistory.OtherDeductions = data.OtherDeductions;
                payrollHistory.Remarks = "";
                payrollHistory.PayeeTax = data.PayeeTax;
                payrollHistory.TotalDeduction = data.TotalDeduction;
                payrollHistory.Net = data.Net;
                payrollHistory.Month = data.Month;
                _context.payrollHistories.Add(payrollHistory);
                _context.SaveChanges();
            }
        }
    }
}
