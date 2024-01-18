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


        public async Task<ServiceResponse<PensionEntity>?> SavePension(PensionEntity pensionEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Payroll/SavePension", pensionEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<PensionEntity>>();

        }

        public async Task<ServiceResponse<LoanEntity>?> SaveLoan(LoanEntity loanEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Payroll/SaveLoan", loanEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<LoanEntity>>();

        }

        public async Task<ServiceResponse<PenaltyEntity>?> SavePenalty(PenaltyEntity penaltyEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Payroll/SavePenalty", penaltyEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<PenaltyEntity>>();

        }

        public async Task<ServiceResponse<OtherAllowancesEntity>?> SaveOtherAllowance(OtherAllowancesEntity otherAllowancesEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Payroll/SaveOtherAllowance", otherAllowancesEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<OtherAllowancesEntity>>();

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
    }
}
