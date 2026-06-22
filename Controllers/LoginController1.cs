using HospitalManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(Login model)
        {
            if (model.Username != "admin" ||
                model.Password != "123")
            {
                return Unauthorized();
            }

            return Ok("Login Successful");
        }
    }
}