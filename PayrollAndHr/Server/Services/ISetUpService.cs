using PayrollAndHr.Shared.Models;

namespace PayrollAndHr.Server.Services
{
    public interface ISetUpService
    {
        List<BranchEntity> LoadBranchInfo();
        Task<ServiceResponse<BranchEntity>> SaveBranchInfo(BranchEntity Bra);
        Task<ServiceResponse<TitleEntity>> SaveTitles(TitleEntity title);
        Task<List<TitleEntity>> LoadAllTitles();
        Task<bool> DeleteTitle(int Code);
        Task<TitleEntity> EditTitle(int Code);
        Task<ServiceResponse<LevelEntity>> SaveLevels(LevelEntity level);
        Task<ServiceResponse<EmploymentTypeEntity>> SaveEmpType(EmploymentTypeEntity emp);
        Task<ServiceResponse<DepartmentEntity>> SaveDept(DepartmentEntity dept);
        Task<ServiceResponse<DesignationEntity>> SaveDesignation(DesignationEntity Desg);
        Task<ServiceResponse<DegreeEntity>> SaveDegrees(DegreeEntity Degree);
    }
}