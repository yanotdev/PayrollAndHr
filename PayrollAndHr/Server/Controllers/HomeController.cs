using Microsoft.AspNetCore.Mvc;
using PayrollAndHr.Server.Services;
using PayrollAndHr.Server.Data;
using PayrollAndHr.Shared.Dtos;
using PayrollAndHr.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Payroll_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IAuthService _authService;
       
        public HomeController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login([FromBody]LoginDto loginDto)
        {
            var response = await _authService.Login(loginDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
            
        }
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<long>>> Register(UserRegister request)
        {
            var response = await _authService.Register(
                new UserEntity
                {
                    Email = request.Email,
                    Password = request.Password,
                    Username = request.Username,
                    UserID = request.UserID,
                    UserRole = request.UserRole,
                    Department = request.Department,
                    PhoneNo = request.PhoneNo,
                    OtherID = request.OtherID,
                    ImageUrl = request.ImageUrl,
                    FullName = request.FullName,
                    
                },
                request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}