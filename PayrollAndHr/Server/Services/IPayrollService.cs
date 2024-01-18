using PayrollAndHr.Shared.Models;

namespace PayrollAndHr.Server.Services
{
    public interface IPayrollService
    {
        long GetNextDocumentNo(string description, long startNo);
        Task<ServiceResponse<AllowanceEntity>> SaveAllowance(AllowanceEntity allowance);

        Task<ServiceResponse<List<AllowanceEntity>>> LoadAllowances();
        Task<ServiceResponse<PensionEntity>> SavePension(PensionEntity pension);

        Task<ServiceResponse<List<PensionEntity>>> LoadPensions();
        Task<ServiceResponse<LoanEntity>> SaveLoan(LoanEntity loan);
        Task<ServiceResponse<List<LoanEntity>>> LoadLoans();


        Task<ServiceResponse<PenaltyEntity>> SavePenalty(PenaltyEntity penalty);
        Task<ServiceResponse<List<PenaltyEntity>>> LoadPenalties();

        Task<ServiceResponse<OtherAllowancesEntity>> SaveOtherAllowance(OtherAllowancesEntity otherAllowances);
        Task<ServiceResponse<List<OtherAllowancesEntity>>> LoadOtherAllowances();
    }
}