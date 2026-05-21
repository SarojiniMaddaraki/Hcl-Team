using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PatientPortalAPI.Data;
using PatientPortalAPI.DTOs;
using PatientPortalAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PatientPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(
            ApplicationDbContext context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            if (_context.Users.Any(x => x.Email == dto.Email))
            {
                return BadRequest("Email already exists");
            }

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash =
                    BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role
            };

            _context.Users.Add(user);

            _context.SaveChanges();

            return Ok("User Registered Successfully");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user =
                _context.Users.FirstOrDefault(
                    x => x.Email == dto.Email);

            if (user == null)
            {
                return Unauthorized("Invalid Email");
            }

            bool isPasswordValid =
                BCrypt.Net.BCrypt.Verify(
                    dto.Password,
                    user.PasswordHash);

            if (!isPasswordValid)
            {
                return Unauthorized("Invalid Password");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        _configuration["Jwt:Key"]));

            var creds =
                new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256);

            var token =
                new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: creds);

            var jwt =
                new JwtSecurityTokenHandler()
                    .WriteToken(token);

            return Ok(new
            {
                token = jwt,
                role = user.Role
            });
        }
    }
}