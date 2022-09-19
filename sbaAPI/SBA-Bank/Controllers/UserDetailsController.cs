using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_Bank.Controllers
{
    // Akshay -- 19/09/2022-- UserDetails Controller


    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager;
        public UserDetailsController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        //Get:/api/UserDetails
        public async Task<Object> GetUserDetails()
        {
            string UserId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(UserId);
            return new
            {
                user.Email,
                user.UserName

            };
        }
    }
}
