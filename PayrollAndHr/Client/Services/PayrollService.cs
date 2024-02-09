using PayrollAndHr.Shared.Models;
using System.Net.Http.Json;

namespace PayrollAndHr.Client.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly HttpClient _httpClient;

        public PayrollService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<AllowanceEntity>?> SaveAllowance(AllowanceEntity allowanceEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Payroll/SaveAllowance", allowanceEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<AllowanceEntity>>();

        }

        public async Task<AllowanceEntity> EditAllowance(int Code)
        {
            var result = await _httpClient.GetAsync("api/Payroll/EditAllowance/" + Code);
            return await result.Content.ReadFromJsonAsync<AllowanceEntity>();

        }

        public async Task<bool> DeleteAllowance(int Code)
        {
            var result = await _httpClient.DeleteAsync("api/Payroll/DeleteAllowance/"+ Code);
            return await result.Content.ReadFromJsonAsync<bool>();

        }
        public async Task<ServiceResponse<PensionEntity>?> SavePension(PensionEntity pensionEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Payroll/SavePension", pensionEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<PensionEntity>>();

        }
        public async Task<PensionEntity> EditPension(int Code)
        {
            var result = await _httpClient.GetFromJsonAsync<PensionEntity>("api/Payroll/EditPension/"+ Code);
            return result;

        }
        public async Task<bool> DeletePension(int Code)
        {
            var result = await _httpClient.DeleteAsync("api/Payroll/DeletePension/" + Code);
            return await result.Content.ReadFromJsonAsync<bool>();

        }
        public async Task<ServiceResponse<LoanEntity>?> SaveLoan(LoanEntity loanEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Payroll/SaveLoan", loanEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<LoanEntity>>();

        }
        public async Task<LoanEntity> EditLoan(int Code)
        {
            var result = await _httpClient.GetFromJsonAsync<LoanEntity>("api/Payroll/EditLoan/" + Code);
            return result;

        }
        public async Task<bool> DeleteLoan(int Code)
        {
            var result = await _httpClient.DeleteAsync("api/Payroll/DeleteLoan/" + Code);
            return await result.Content.ReadFromJsonAsync<bool>();

        }
        public async Task<ServiceResponse<PenaltyEntity>?> SavePenalty(PenaltyEntity penaltyEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Payroll/SavePenalty", penaltyEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<PenaltyEntity>>();

        }
        public async Task<PenaltyEntity> EditPenalty(int Code)
        {
            var result = await _httpClient.GetFromJsonAsync<PenaltyEntity>("api/Payroll/EditPenalty/" + Code);
            return result;

        }
        public async Task<bool> DeletePenalty(int Code)
        {
            var result = await _httpClient.DeleteAsync("api/Payroll/DeletePenalty/" + Code);
            return await result.Content.ReadFromJsonAsync<bool>();

        }
        public async Task<ServiceResponse<OtherAllowancesEntity>?> SaveOtherAllowance(OtherAllowancesEntity otherAllowancesEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Payroll/SaveOtherAllowance", otherAllowancesEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<OtherAllowancesEntity>>();

        }
        public async Task<OtherAllowancesEntity> EditOtherAllowances(int Code)
        {
            var result = await _httpClient.GetFromJsonAsync<OtherAllowancesEntity>("api/Payroll/EditOtherAllowances/" + Code);
            return result;

        }
        public async Task<bool> DeleteOtherAllowances(int Code)
        {
            var result = await _httpClient.DeleteAsync("api/Payroll/DeleteOtherAllowances/" + Code);
            return await result.Content.ReadFromJsonAsync<bool>();

        }
        public async Task<ServiceResponse<List<AllowanceEntity>?>> GetAllowances()
        {
            var result = await _httpClient.GetAsync("api/Payroll/GetAllowances");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<List<AllowanceEntity>?>>();

        }

        public async Task<ServiceResponse<List<PensionEntity>?>> GetPensions()
        {
            var result = await _httpClient.GetAsync("api/Payroll/GetPensions");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<List<PensionEntity>?>>();

        }
        public async Task<ServiceResponse<List<LoanEntity>?>> GetLoans()
        {
            var result = await _httpClient.GetAsync("api/Payroll/GetLoans");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<List<LoanEntity>?>>();

        }

        public async Task<ServiceResponse<List<PenaltyEntity>?>> GetPenalties()
        {
            var result = await _httpClient.GetAsync("api/Payroll/GetPenalty");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<List<PenaltyEntity>?>>();

        }
        public async Task<ServiceResponse<List<OtherAllowancesEntity>?>> GetOtherAllowances()
        {
            var result = await _httpClient.GetAsync("api/Payroll/GetOtherAllowances");
            return await result.Content.ReadFromJsonAsync<ServiceResponse<List<OtherAllowancesEntity>?>>();

        }

        public async Task<List<PersonalInformationEntity>?> GetallStaff()
        {
            var result = await _httpClient.GetAsync("api/Payroll/GetallStaff");
            return await result.Content.ReadFromJsonAsync<List<PersonalInformationEntity>?>();

        }
    }
}

