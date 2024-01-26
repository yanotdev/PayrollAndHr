using Blazored.SessionStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PayrollAndHr.Server.Data;
using PayrollAndHr.Shared.Dtos;
using PayrollAndHr.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PayrollAndHr.Server.Services
{
    public class AuthService: IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISessionStorageService _sessionStorageService;
        
        public AuthService(AppDbContext context,
           IConfiguration configuration,
           IHttpContextAccessor httpContextAccessor, ISessionStorageService sessionStorageService)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _sessionStorageService = sessionStorageService;


        }

        public int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public string GetUserEmail() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);

        public async Task<ServiceResponse<string>> Login(LoginDto loginDto)
        {
            var response = new ServiceResponse<string>();

            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email.ToLower().Equals(loginDto.Email.ToLower()));
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
                
            }
            else if (!(Dencrypt(user.Password) == (loginDto.Password)))
            {
                response.Success = false;
                response.Message = "Wrong password.";
            }
            else
        {
                response.UserRole = user.UserRole;
                response.UserName = user.Username;
                response.Department = user.Department;
                user.IsLogin = true;
                response.Data = CreateToken(user);
            }

            return response;
        }

        public async Task<ServiceResponse<long>> Register(UserEntity user, string password)
        {
            if (await UserExists(user.Email))
            {
                return new ServiceResponse<long>
                {
                    Success = false,
                    Message = "User already exists."
                };
            }

            user.Password = Encrypt(password);
           
          
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new ServiceResponse<long> { Data = user.ID, Message = "Registration successful!" };
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.Users.AnyAsync(user => user.Email.ToLower()
                 .Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }

        
            //========================Two way encryption=============================
            public string Encrypt(string datastring)
            {
                string encryptData = string.Empty;
                byte[] encode = new byte[datastring.Length];
                encode = Encoding.UTF8.GetBytes(datastring);
                encryptData = Convert.ToBase64String(encode);
                return encryptData;
            }

            public string Dencrypt(string encryptDatastring)
            {
                string DataDencrypt = string.Empty;
                UTF8Encoding encodepwd = new UTF8Encoding();
                Decoder decoder = encodepwd.GetDecoder();
                byte[] todec_byte = Convert.FromBase64String(encryptDatastring);
                int charcount = decoder.GetCharCount(todec_byte, 0, todec_byte.Length);
                char[] decoded_char = new char[charcount];
                decoder.GetChars(todec_byte, 0, todec_byte.Length, decoded_char, 0);
                DataDencrypt = new string(decoded_char);
                return DataDencrypt;
            }
            //============================================================================

            private string CreateToken(UserEntity user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.UserRole)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "User not found."
                };
            }
            user.Password = Encrypt(newPassword); ;
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true, Message = "Password has been changed." };
        }

        public async Task<UserEntity> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
            if (user == null)
                return null;
            return user;
        }
    }
}
  
