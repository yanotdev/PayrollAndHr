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
            return await result.Content.ReadFromJsonAsync<ServiceResponse<AllowanceEntity>?>();

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

        public async Task<List<AllowanceEntity>> GetAllowanceType(string descript)
        {
            var result = await _httpClient.GetAsync("api/Payroll/GetallAllowanceType/"+ descript);
            return await result.Content.ReadFromJsonAsync<List<AllowanceEntity>>();

        }
        public async Task<List<AllowanceEntity>> GetAllType(string type)
        {
            var result = await _httpClient.GetAsync("api/Payroll/GetAllType/" + type);
            return await result.Content.ReadFromJsonAsync<List<AllowanceEntity>>();

        }
        public async Task<ServiceResponse<SalaryEntity>?> SaveSalary(SalaryEntity salaryEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Payroll/SaveSalary", salaryEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<SalaryEntity>>();

        }
        
        public async Task<ServiceResponse<SalaryEntity>> GetSalary(string StaffID)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<SalaryEntity>>("api/Payroll/GetSalary/" + StaffID.ToString());
            return result;

        }
        public async Task<ServiceResponse<StaffLoanEntity>?> SaveStaffLoan(StaffLoanEntity staffLoanEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Payroll/SaveStaffLoan", staffLoanEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<StaffLoanEntity>>();

        }
        public async Task<List<StaffLoanEntity>?> GetStaffLoan(string StaffID)
        {
            var result = await _httpClient.GetAsync("api/Payroll/GetStaffLoan/" + StaffID);
            return await result.Content.ReadFromJsonAsync<List<StaffLoanEntity>>();

        }
        public async Task<StaffLoanEntity> EditStaffLoan(int ID)
        {
            var result = await _httpClient.GetAsync("api/Payroll/EditStaffLoan/" + ID);
            return await result.Content.ReadFromJsonAsync<StaffLoanEntity>();

        }
        public async Task<bool> DeleteStaffLoan(int ID)
        {
            var result = await _httpClient.DeleteAsync("api/Payroll/DeleteStaffloan/" + ID);
            return await result.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<ServiceResponse<DeductionEntity>?> SaveDeductions(DeductionEntity deductionEntity)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Payroll/SaveDeductions", deductionEntity);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<DeductionEntity>>();

        }
        
        public async Task<List<DeductionEntity>?> GetDeductions(string StaffID)
        {
            var result = await _httpClient.GetAsync("api/Payroll/GetDeductions/" + StaffID);
            return await result.Content.ReadFromJsonAsync<List<DeductionEntity>>();

        }
        public async Task<DeductionEntity> EditStaffDeductions(int ID)
        {
            var result = await _httpClient.GetAsync("api/Payroll/EditStaffDeductions/" + ID);
            return await result.Content.ReadFromJsonAsync<DeductionEntity>();

        }
        public async Task<bool> DeleteStaffdeduct(int ID)
        {
            var result = await _httpClient.DeleteAsync("api/Payroll/DeleteStaffdeduct/" + ID);
            return await result.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<ServiceResponse<StaffOtherAllowancesEntity>?> SaveStaffOthers(StaffOtherAllowancesEntity staff)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Payroll/SaveStaffOthers", staff);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<StaffOtherAllowancesEntity>>();

        }
        public async Task<List<StaffOtherAllowancesEntity>?> GetStaffOthers(string StaffID)
        {
            var result = await _httpClient.GetAsync("api/Payroll/GetStaffOthers/" + StaffID);
            return await result.Content.ReadFromJsonAsync<List<StaffOtherAllowancesEntity>>();

        }
        public async Task<StaffOtherAllowancesEntity> EditStaffOthers(int ID)
        {
            var result = await _httpClient.GetAsync("api/Payroll/EditStaffOthers/" + ID);
            return await result.Content.ReadFromJsonAsync<StaffOtherAllowancesEntity>();

        }
        public async Task<bool> DeleteStaffothers(int ID)
        {
            var result = await _httpClient.DeleteAsync("api/Payroll/DeleteStaffOthers/" + ID);
            return await result.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<ServiceResponse<StaffAVCEntity>?> SaveAVC(StaffAVCEntity staffavc)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Payroll/SaveAVC", staffavc);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<StaffAVCEntity>>();

        }
        public async Task<List<StaffAVCEntity>?> GetStaffAVC(string StaffID)
        {
            var result = await _httpClient.GetAsync("api/Payroll/GetStaffAVC/" + StaffID);
            return await result.Content.ReadFromJsonAsync<List<StaffAVCEntity>>();

        }
        public async Task<StaffAVCEntity> EditStaffAVC(int ID)
        {
            var result = await _httpClient.GetAsync("api/Payroll/EditStaffAVC/" + ID);
            return await result.Content.ReadFromJsonAsync<StaffAVCEntity>();

        }
        public async Task<bool> DeleteStaffAVC(int ID)
        {
            var result = await _httpClient.DeleteAsync("api/Payroll/DeleteStaffAVC/" + ID);
            return await result.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<ServiceResponse<PAYEEntity>?> SavePAYE(PAYEEntity pAYE)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Payroll/SavePAYE", pAYE);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<PAYEEntity>>();

        }
        public async Task<List<SalaryEntity>?> LoadAll(string StaffID)
        {
            var result = await _httpClient.GetAsync("api/Payroll/LoadAll/" + StaffID);
            return await result.Content.ReadFromJsonAsync<List<SalaryEntity>>();

        }
        public async Task<List<SalaryEntity>?> LoadAllAnnual(string StaffID)
        {
            var result = await _httpClient.GetAsync("api/Payroll/LoadAllAnnual/" + StaffID);
            return await result.Content.ReadFromJsonAsync<List<SalaryEntity>>();

        }
    }
    



}



