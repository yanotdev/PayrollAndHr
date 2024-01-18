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

        public async Task<ServiceResponse<PersonalInformationEntity>> SaveEmployee(PersonalInformationEntity personalInformationEntity)
        {
           var result = await _httpClient.PostAsJsonAsync("api/Employee/SavePersonalInformation", personalInformationEntity);                      
           return await result.Content.ReadFromJsonAsync<ServiceResponse<PersonalInformationEntity>>();
            
        }
    }

}