using PayrollAndHr.Shared.Models;

namespace PayrollAndHr.Client.Services
{
    public interface ISetUpService
    {
        Task<ServiceResponse<BranchEntity>?> SaveBranchInfo(BranchEntity branchEntity);
        Task<ServiceResponse<TitleEntity>?> SaveTitle(TitleEntity title);
        Task<ServiceResponse<LevelEntity>?> SaveLevel(LevelEntity level);
        Task<ServiceResponse<DepartmentEntity>?> SaveDept(DepartmentEntity dept);
        Task<ServiceResponse<DegreeEntity>?> SaveDegrees(DegreeEntity deg);
        Task<ServiceResponse<DesignationEntity>?> SaveDesignation(DesignationEntity desig);
        Task<ServiceResponse<EmploymentTypeEntity>?> SaveEmpType(EmploymentTypeEntity emptype);
    }
}