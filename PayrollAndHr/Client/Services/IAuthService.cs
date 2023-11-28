using PayrollAndHr.Shared.Dtos;
using PayrollAndHr.Shared.Models;

namespace PayrollAndHr.Client.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Login(LoginDto loginDto);
    }
}
