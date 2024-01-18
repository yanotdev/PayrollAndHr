using PayrollAndHr.Shared.Models;

namespace PayrollAndHr.Client.Services
{
    public interface IEmployeeService
    {
        Task<ServiceResponse<PersonalInformationEntity>> SaveEmployee(PersonalInformationEntity personalInformationEntity);
    }
}
