using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBA_Bank.DbContext;
using SBA_Bank.Models;


namespace SBA_Bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountInfoesController : ControllerBase
    {
        private readonly SBAdbContext _context;
        private UserManager<UserProfile> _userManager;
        private SignInManager<UserProfile> _signInManager;
        public AccountInfoesController(SBAdbContext context, UserManager<UserProfile> userManager, SignInManager<UserProfile> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<AccountInfo>>> GetaccountInfosAgain()
        //{
        //    return await _context.accountInfos.ToListAsync();
        //}
        // GET: api/AccountInfoes
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<AccountInfo>>> GetaccountInfos()
        //{
        //    return await _context.accountInfos.ToListAsync();
        //}
        public async Task<Object> GetaccountInfos()
        {
            //if (User.FindFirst(ClaimTypes.NameIdentifier).Value == null)
            //{
            //    return NotFound();
            //}
            
                string UserId = User.Claims.First(c => c.Type == "UserID").Value;
                var user =  _context.accountInfos.FirstOrDefault(u => u.UserId == UserId);

                return new
                {
                    user.UserId,
                    user.Balance,
                    user.AccountId,
                    user.Branch





                };
            
            
        }

        // GET: api/AccountInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountInfo>> GetAccountInfo(long id)
        {
            var accountInfo = await _context.accountInfos.FindAsync(id);

            if (accountInfo == null)
            {
                return NotFound();
            }

            return accountInfo;
        }

        // PUT: api/AccountInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountInfo(long id, AccountInfo accountInfo)
        {
            if (id != accountInfo.AccountId)
            {
                return BadRequest();
            }
            
            _context.Entry(accountInfo).Property(a=>a.Balance)
            .IsModified=true;
          
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AccountInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccountInfo>> PostAccountInfo(AccountInfo accountInfo)
        {
            _context.accountInfos.Add(accountInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountInfo", new { id = accountInfo.AccountId }, accountInfo);
        }

        // DELETE: api/AccountInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountInfo(long id)
        {
            var accountInfo = await _context.accountInfos.FindAsync(id);
            if (accountInfo == null)
            {
                return NotFound();
            }

            _context.accountInfos.Remove(accountInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountInfoExists(long id)
        {
            return _context.accountInfos.Any(e => e.AccountId == id);
        }
    }
}
