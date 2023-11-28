using PayrollAndHr.Shared.Dtos;
using PayrollAndHr.Shared.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace PayrollAndHr.Client.Services
{
    public class AuthService: IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<string>> Login(LoginDto loginDto)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Home/login", loginDto);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }
    }
}
