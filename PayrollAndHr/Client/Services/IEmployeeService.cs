using PayrollAndHr.Shared.Models;

namespace PayrollAndHr.Client.Services
{
    public interface IEmployeeService
    {
        Task SaveEmployee(PersonalInformationEntity personalInformationEntity);
    }
}
