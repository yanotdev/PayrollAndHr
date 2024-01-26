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

        public async Task<ServiceResponse<PrefixEntity>> SavePrefix(PrefixEntity prefixEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Employee/SavePrefix", prefixEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<PrefixEntity>>();

        }
        public async Task<RegistrationPara> GetRegistrationNo()
        {
            var result = await _httpClient.GetAsync("api/Employee/GetRegistrationNo");
            return await result.Content.ReadFromJsonAsync<RegistrationPara>();
        }
        public async Task<ServiceResponse<EmpContactInfoEntity>> SaveContact(EmpContactInfoEntity empContactInfoEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Employee/SaveContact", empContactInfoEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<EmpContactInfoEntity>>();
        }

        public async Task<ServiceResponse<NextofKinEntity>> SaveNextOfKin(NextofKinEntity nextofKinEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Employee/SaveNextOfKin", nextofKinEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<NextofKinEntity>>();
        }
        public async Task<ServiceResponse<GurrantorEntity>> SaveGuarantor(GurrantorEntity gurrantorEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Employee/SaveGuarantor", gurrantorEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<GurrantorEntity>>();
        }
        public async Task<ServiceResponse<ReferenceEntity>> SaveReference(ReferenceEntity referenceEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Employee/SaveReference", referenceEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<ReferenceEntity>>();
        }
        public async Task<ServiceResponse<MedicalEntity>> SaveMedicalHis(MedicalEntity medicalEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Employee/SaveMedicalHis", medicalEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<MedicalEntity>>();
        }
    }
    

}
