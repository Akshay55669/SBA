using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SBA_Bank.DbContext;
using SBA_Bank.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SBA_Bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signinManager;
        private readonly ApplicationSettings _appSettings;
        public UserProfileController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signinManager, IOptions<ApplicationSettings>appSettings)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("Register")]
        //Post:/api/UserProfile/Register
        public async Task<Object> PostUserProfile(UserProfileModel model)
        {
            var UserProfile = new UserProfile()
            {
                UserName = model.UserName,
                Email = model.Email,
               
                
            };
            try
            {
                var result = await _userManager.CreateAsync(UserProfile, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        //Post:/api/UserProfile/Login
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if(user!=null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new {message ="Username or Password is incorrect."});
        }

    }
}
