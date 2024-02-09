using PayrollAndHr.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace PayrollAndHr.Client.Services
{
    public class SetUpService : ISetUpService
    {
        private readonly HttpClient _httpClient;

        public SetUpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<BranchEntity>?> SaveBranchInfo(BranchEntity branchEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/SetUp/SaveBranch", branchEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<BranchEntity>>();

        }
        public async Task<ServiceResponse<TitleEntity>?> SaveTitle(TitleEntity title)
        {
            var result = await _httpClient.PostAsJsonAsync("api/SetUp/SaveTitle", title);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<TitleEntity>>();

        }
        public async Task<ServiceResponse<LevelEntity>?> SaveLevel(LevelEntity level)
        {
            var result = await _httpClient.PostAsJsonAsync("api/SetUp/Savelevel", level);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<LevelEntity>>();

        }
        public async Task<ServiceResponse<DepartmentEntity>?> SaveDept(DepartmentEntity dept)
        {
            var result = await _httpClient.PostAsJsonAsync("api/SetUp/SaveDept", dept);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<DepartmentEntity>>();

        }
        public async Task<ServiceResponse<DegreeEntity>?> SaveDegrees(DegreeEntity deg)
        {
            var result = await _httpClient.PostAsJsonAsync("api/SetUp/SaveDegrees", deg);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<DegreeEntity>>();

        }
        public async Task<ServiceResponse<DesignationEntity>?> SaveDesignation(DesignationEntity desig)
        {
            var result = await _httpClient.PostAsJsonAsync("api/SetUp/SaveDesignation", desig);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<DesignationEntity>>();

        }
        public async Task<ServiceResponse<EmploymentTypeEntity>?> SaveEmpType(EmploymentTypeEntity emptype)
        {
            var result = await _httpClient.PostAsJsonAsync("api/SetUp/SaveEmpType", emptype);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<EmploymentTypeEntity>>();

        }
           

    }
    
}
