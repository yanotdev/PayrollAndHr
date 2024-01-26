using PayrollAndHr.Shared.Models;

namespace PayrollAndHr.Client.Services
{
    public interface IPayrollService
    {
        Task<ServiceResponse<AllowanceEntity>> SaveAllowance(AllowanceEntity allowanceEntity);

        Task<ServiceResponse<List<AllowanceEntity>?>> GetAllowances();

        Task<ServiceResponse<AllowanceEntity>?> EditAllowance(AllowanceEntity allowanceEntity);

        Task<bool> DeleteAllowance(int Code);
        Task<ServiceResponse<PensionEntity>?> SavePension(PensionEntity pensionEntity);

        Task<ServiceResponse<List<PensionEntity>?>> GetPensions();

        Task<ServiceResponse<LoanEntity>?> SaveLoan(LoanEntity loanEntity);

        Task<ServiceResponse<List<LoanEntity>?>> GetLoans();

        Task<ServiceResponse<PenaltyEntity>?> SavePenalty(PenaltyEntity penaltyEntity);

        Task<ServiceResponse<List<PenaltyEntity>?>> GetPenalties();

        Task<ServiceResponse<OtherAllowancesEntity>?> SaveOtherAllowance(OtherAllowancesEntity otherAllowancesEntity);
        Task<ServiceResponse<List<OtherAllowancesEntity>?>> GetOtherAllowances();
    }
}