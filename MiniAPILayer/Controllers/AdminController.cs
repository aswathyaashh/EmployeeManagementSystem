using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ModelLayer;
using RepositoryLayer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiniAPILayer.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly EmployeeDbContext _dataContext;
        private readonly IConfiguration _config;
        public AdminController(EmployeeDbContext dContext, IConfiguration config)
        {
            _dataContext = dContext;
            _config = config;
        }


        public static AdminVerify user = new AdminVerify();
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(Login request)
        {
            if (_dataContext.AdminDetails.Any(u => u.UserName == request.UserName))
            {
                return BadRequest("User already exist");
            }

            CreatePasswordHash(request.Password
                , out byte[] passwordHash
                , out byte[] passwordSalt);

            var verify = new AdminVerify
            {
                UserName = request.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                
            };

            _dataContext.AdminDetails.Add(verify);
            await _dataContext.SaveChangesAsync();

            return Ok("User succesfully created");

        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(Login request1)
        {

            var user = await _dataContext.AdminDetails.FirstOrDefaultAsync(u => u.UserName == request1.UserName);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            if (!VerifyPasswordHash(request1.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Password is Incorrect");
            }

            string token = CreateToken(user);


            return Ok(token);


        }



        private string CreateToken(AdminVerify user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.
                    ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }



        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.
                    ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);

            }
        }

    }
}
