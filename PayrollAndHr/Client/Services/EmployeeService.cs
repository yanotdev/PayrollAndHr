using PayrollAndHr.Shared.Dtos;
using PayrollAndHr.Shared.Models;
using System.Net.Http.Json;

namespace PayrollAndHr.Client.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SaveEmployee(PersonalInformationEntity personalInformationEntity)
        {
            await _httpClient.PostAsJsonAsync("api/Employee/SavePersonalInformation", personalInformationEntity);            
        }
    }

}