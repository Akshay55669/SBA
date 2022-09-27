using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SBA_Bank.DbContext;
using SBA_Bank.Models;
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
        private UserManager<UserProfile> _userManager;
        private SBAdbContext _context;
        public UserDetailsController(UserManager<UserProfile> userManager, SBAdbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]

        //Get:/api/UserDetails
        public async Task<Object> GetUserDetails()
        {
            string UserId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(UserId);
            return new
            {
                user.Id,
                user.dob,
                user.Email,
                user.UserName,
                user.PhoneNumber,
                user.firstName,
                user.lastName,
               
               


            };
        }


    }
}
