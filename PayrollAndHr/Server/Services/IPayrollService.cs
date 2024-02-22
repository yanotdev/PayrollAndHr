using PayrollAndHr.Shared.Models;

namespace PayrollAndHr.Server.Services
{
    public interface IPayrollService
    {
        long GetNextDocumentNo(string description, long startNo);
        Task<ServiceResponse<AllowanceEntity>> SaveAllowance(AllowanceEntity allowance);

        Task<ServiceResponse<List<AllowanceEntity>>> LoadAllowances();

        Task<AllowanceEntity> EditAllowance(int Code);
        Task<bool> DeleteAllowance(int Code);
        Task<ServiceResponse<PensionEntity>> SavePension(PensionEntity pension);

        Task<ServiceResponse<List<PensionEntity>>> LoadPensions();
        Task<PensionEntity> EditPension(int code);
        Task<bool> DeletePension(int Code);
        Task<ServiceResponse<LoanEntity>> SaveLoan(LoanEntity loan);
        Task<bool> DeleteLoans(int Code);
        Task<LoanEntity> EditLoans(int code);
        Task<ServiceResponse<List<LoanEntity>>> LoadLoans();


        Task<ServiceResponse<PenaltyEntity>> SavePenalty(PenaltyEntity penalty);
        Task<ServiceResponse<List<PenaltyEntity>>> LoadPenalties();
        Task<bool> DeletePenalty(int Code);
        Task<PenaltyEntity> EditPenalty(int code);

        Task<ServiceResponse<OtherAllowancesEntity>> SaveOtherAllowance(OtherAllowancesEntity otherAllowances);
        Task<ServiceResponse<List<OtherAllowancesEntity>>> LoadOtherAllowances();
        Task<bool> DeleteOtherAllowances(int Code);
        Task<OtherAllowancesEntity> EditOtherAllowances(int code);
        Task<List<PersonalInformationEntity>> LoadAllStaff();
        Task<List<AllowanceEntity>> LoadAllowanceType(string descript);
        Task<List<AllowanceEntity>> LoadAllType(string type);

        Task<ServiceResponse<SalaryEntity>> SaveSalary(SalaryEntity salary);
        Task<ServiceResponse<SalaryEntity>> LoadStaffSalary(string staffID);
        Task<ServiceResponse<StaffLoanEntity>> SaveStaffLoan(StaffLoanEntity indiviLoan);
        Task<List<StaffLoanEntity>> LoadStaffLoan(string StaffID);
        Task<StaffLoanEntity> EditStaffLoan(int ID);
        Task<bool> DeleteStaffLoan(int ID);
        Task<ServiceResponse<DeductionEntity>> Savededuct(DeductionEntity staffDeduction);
        Task<List<DeductionEntity>> LoadStaffPenalty(string StaffID);
        Task<DeductionEntity> EditDeductions(int ID);
        Task<bool> DeletePen(int ID);

        Task<ServiceResponse<StaffOtherAllowancesEntity>> SaveStaffOtherAllowance(StaffOtherAllowancesEntity staff);
        Task<List<StaffOtherAllowancesEntity>> LoadStaffOtherAllowances(string StaffID);
        Task<StaffOtherAllowancesEntity> EditStaffOthers(int ID);
        Task<bool> DeleteStaffOthers(int ID);
        Task<ServiceResponse<StaffAVCEntity>> SaveAvc(string StaffID, string AVC);
        Task<List<StaffAVCEntity>> GetStaffAVC(string StaffID);
        Task<StaffAVCEntity> EditStaffAVC(int ID);
        Task<bool> DeleteStaffAVC(int ID);
        Task<ServiceResponse<PAYEEntity>> SaveStaffPayE(PAYEEntity paye);
        Task<List<SalaryEntity>> LoadALL(string sID);
        Task<List<SalaryEntity>> LoadALLAnnual(string sID);
    }
}