using PayrollAndHr.Shared.Models;

namespace PayrollAndHr.Server.Services
{
    public interface ISetUpService
    {
        List<BranchEntity> LoadBranchInfo();
        Task<ServiceResponse<BranchEntity>> SaveBranchInfo(BranchEntity Bra);

        Task<List<BranchEntity>> LoadAllBranchInfo();
        Task<bool> DeleteBranch(int Code);
        Task<BranchEntity> EditBranchInfo(int BranchCode);
        Task<ServiceResponse<TitleEntity>> SaveTitles(TitleEntity title);
        Task<List<TitleEntity>> LoadAllTitles();
        Task<bool> DeleteTitle(int Code);
        Task<TitleEntity> EditTitle(int Code);
        Task<ServiceResponse<LevelEntity>> SaveLevels(LevelEntity level);
        Task<List<LevelEntity>> LoadAllLevels();
        Task<bool> DeleteLevel(int Code);
        Task<LevelEntity> EditLevel(int Code);
        Task<ServiceResponse<EmploymentTypeEntity>> SaveEmpType(EmploymentTypeEntity emp);
        Task<List<EmploymentTypeEntity>> LoadAllEmpType();
        Task<bool> DeleteEmpType(int Code);
        Task<EmploymentTypeEntity> EditEmpType(int Code);
        Task<ServiceResponse<DepartmentEntity>> SaveDept(DepartmentEntity dept);
        Task<List<DepartmentEntity>> LoadAllDepartment();
        Task<bool> DeleteDepartment(int Code);
        Task<DepartmentEntity> EditDepartment(int Code);
        Task<ServiceResponse<DesignationEntity>> SaveDesignation(DesignationEntity Desg);
        Task<List<DesignationEntity>> LoadAllDesignation();
        Task<bool> DeleteDesignation(int Code);
        Task<DesignationEntity> EditDesignations(int Code);
        Task<ServiceResponse<DegreeEntity>> SaveDegrees(DegreeEntity Degree);
        Task<List<DegreeEntity>> LoadAllDegrees();
        Task<bool> DeleteDegree(int Code);
        Task<DegreeEntity> EditDegrees(int Code);
    }
}