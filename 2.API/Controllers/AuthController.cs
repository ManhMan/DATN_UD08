using _1.DATA.IRepositories;
using _1.DATA.Model;
using _1_API.ViewModel.Login;
using _1_API.ViewModel.NhanVien;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signinManager;
        private IAllRepositories<User> _repo;
        public AuthController(UserManager<User> userManager, SignInManager<User> signinManager, IAllRepositories<User> repo)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _repo = repo;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _signinManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            var authClaims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsTheSecureKey1234567890"));

            var token = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "UserBeeNeaker",
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
            );

            return Ok( new JwtSecurityTokenHandler().WriteToken(token));
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(CreateUserModel model)
        {
            var getAllUser = await _repo.GetAllAsync();
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Ten = model.Ten,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.Sdt,
                DiaChi = model.DiaChi,
                AnhNhanVien = model.AnhNhanVien,
                GioiTinh = model.GioiTinh,
                MaNV = "NV" + (getAllUser.Count() + 1),
                TrangThai = model.TrangThai,
                NgaySinh = model.NgaySinh,
                PasswordHash = model.MatKhau
            };

            var result = await _userManager.CreateAsync(user, model.MatKhau);
            if(!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok(user);
        }
    }
}
