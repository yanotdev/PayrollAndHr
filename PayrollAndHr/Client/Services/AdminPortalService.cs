using PayrollAndHr.Shared.Dtos;
using PayrollAndHr.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace PayrollAndHr.Client.Services
{
    public class AdminPortalService : IAdminPortalService
    {
        private readonly HttpClient _httpClient;

        public AdminPortalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string GetEmpCount()
        {
            var result = _httpClient.GetStringAsync("api/AdminPortal/EmpCount");
            return result.Result;
        }
    }
}
