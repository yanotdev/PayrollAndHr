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
    }
}