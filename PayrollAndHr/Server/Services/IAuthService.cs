using PayrollAndHr.Shared.Dtos;
using PayrollAndHr.Shared.Models;

namespace PayrollAndHr.Server.Services
{
    public interface IAuthService
    {
        int GetUserId();
        string GetUserEmail();

        Task<ServiceResponse<string>> Login(LoginDto loginDto);

        Task<ServiceResponse<long>> Register(UserEntity user, string password);
        Task<bool> UserExists(string email);

        Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword);
        Task<UserEntity> GetUserByEmail(string email);
    }
}
