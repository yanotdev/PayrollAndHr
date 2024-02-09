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

    }
}