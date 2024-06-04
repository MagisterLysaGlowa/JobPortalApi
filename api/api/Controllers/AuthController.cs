using api.Dtos;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IJwtService jwtService;
        private readonly IWebHostEnvironment hostEnvironment;
        public AuthController(IUserRepository userRepository, IJwtService jwtService, IWebHostEnvironment hostEnvironment)
        {
            this.userRepository = userRepository;
            this.jwtService = jwtService;
            this.hostEnvironment = hostEnvironment;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDto dto)
        {
            string uploadedFileName;
            if (dto.ImageFile.FileName == "empty.png")
            {
                uploadedFileName = "user_avatar";
            }
            else
            {
                uploadedFileName = await Upload(dto.ImageFile, "Avatar");
            }

            var User = new User()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                BirthDate = dto.BirthDate,
                Access = "user",
                Domicile = dto.Domicile,
                AvatarSource = uploadedFileName,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            return Created("success", userRepository.Create(User));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = userRepository.GetByEmail(dto.Email);
            if (user == null) return BadRequest(new { message = "Invalid Credentials" });

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            var jwt = jwtService.Generate(user.UserId);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                message = "success"
            });
        }

        [HttpGet("user")]
        public IActionResult GetUserByJwt()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = userRepository.GetById(userId);

                return Ok(user);
            }
            catch (Exception)
            {
                return Ok(null);
            }
        }

        [HttpGet("emailIsFree/{email}")]
        public IActionResult CheckIfEmailIsFree(string email)
        {
            try
            {
                return Ok(userRepository.EmailFree(email));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpGet("numberIsFree/{number}")]
        public IActionResult CheckIfNumberIsFree(string number)
        {
            try
            {
                return Ok(userRepository.NumberFree(number));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "success"
            });
        }
        [NonAction]
        public async Task<string> Upload(IFormFile file,string directory)
        {
            if (file == null || file.Length == 0)
                return "";
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), $"Uploads/{directory}");

            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);

            string fileName = $"avatar_{GenerateRandomString(15)}{Path.GetExtension(file.FileName)}";

            var filePath = Path.Combine(uploads, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        [NonAction]
        public string GenerateRandomString(int length)
        {
            const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = characters[random.Next(characters.Length)];
            }

            return new string(result);
        }
    }
}
