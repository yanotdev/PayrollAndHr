using PayrollAndHr.Shared.Models;

namespace PayrollAndHr.Server.Services
{
    public interface ISetUpService
    {
        List<BranchEntity> LoadBranchInfo();
        Task<ServiceResponse<BranchEntity>> SaveBranchInfo(BranchEntity Bra);
    }
}