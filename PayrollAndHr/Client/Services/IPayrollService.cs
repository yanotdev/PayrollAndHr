using PayrollAndHr.Shared.Models;

namespace PayrollAndHr.Client.Services
{
    public interface IPayrollService
    {
        Task<ServiceResponse<AllowanceEntity>> SaveAllowance(AllowanceEntity allowanceEntity);

        Task<ServiceResponse<List<AllowanceEntity>?>> GetAllowances();

        Task<AllowanceEntity> EditAllowance(int Code);

        Task<bool> DeleteAllowance(int Code);
        Task<ServiceResponse<PensionEntity>?> SavePension(PensionEntity pensionEntity);

        Task<ServiceResponse<List<PensionEntity>?>> GetPensions();
        Task<PensionEntity> EditPension(int Code);
        Task<bool> DeletePension(int Code);

        Task<ServiceResponse<LoanEntity>?> SaveLoan(LoanEntity loanEntity);

        Task<ServiceResponse<List<LoanEntity>?>> GetLoans();
        Task<bool> DeleteLoan(int Code);
        Task<LoanEntity> EditLoan(int Code);

        Task<ServiceResponse<PenaltyEntity>?> SavePenalty(PenaltyEntity penaltyEntity);
        

        Task<ServiceResponse<List<PenaltyEntity>?>> GetPenalties();
        Task<bool> DeletePenalty(int Code);
        Task<PenaltyEntity> EditPenalty(int Code);

        Task<ServiceResponse<OtherAllowancesEntity>?> SaveOtherAllowance(OtherAllowancesEntity otherAllowancesEntity);
        Task<ServiceResponse<List<OtherAllowancesEntity>?>> GetOtherAllowances();
        Task<OtherAllowancesEntity> EditOtherAllowances(int Code);
        Task<bool> DeleteOtherAllowances(int Code);

        Task<List<PersonalInformationEntity>?> GetallStaff();
        Task<List<AllowanceEntity>> GetAllowanceType(string descript);
        Task<List<AllowanceEntity>> GetAllType(string type);
        Task<ServiceResponse<SalaryEntity>?> SaveSalary(SalaryEntity salaryEntity);
        Task<ServiceResponse<SalaryEntity>> GetSalary(string StaffID);
        Task<ServiceResponse<StaffLoanEntity>?> SaveStaffLoan(StaffLoanEntity staffLoanEntity);
        Task<List<StaffLoanEntity>?> GetStaffLoan(string StaffID);
        Task<StaffLoanEntity> EditStaffLoan(int ID);
        Task<bool> DeleteStaffLoan(int ID);

        Task<ServiceResponse<DeductionEntity>?> SaveDeductions(DeductionEntity deductionEntity);
        Task<List<DeductionEntity>?> GetDeductions(string StaffID);
        Task<DeductionEntity> EditStaffDeductions(int ID);
        Task<bool> DeleteStaffdeduct(int ID);
        Task<ServiceResponse<StaffOtherAllowancesEntity>?> SaveStaffOthers(StaffOtherAllowancesEntity staff);
        Task<List<StaffOtherAllowancesEntity>?> GetStaffOthers(string StaffID);
        Task<StaffOtherAllowancesEntity> EditStaffOthers(int ID);
        Task<bool> DeleteStaffothers(int ID);
        Task<ServiceResponse<StaffAVCEntity>?> SaveAVC(StaffAVCEntity staffavc);
        Task<List<StaffAVCEntity>?> GetStaffAVC(string StaffID);
        Task<StaffAVCEntity> EditStaffAVC(int ID);
        Task<bool> DeleteStaffAVC(int ID);
        Task<ServiceResponse<PAYEEntity>?> SavePAYE(PAYEEntity pAYE);
        Task<List<SalaryEntity>?> LoadAll(string StaffID);
        Task<List<SalaryEntity>?> LoadAllAnnual(string StaffID);

    }
}