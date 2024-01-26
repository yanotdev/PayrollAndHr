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
    }
}
