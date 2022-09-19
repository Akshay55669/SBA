using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBA_Bank.DbContext;
using SBA_Bank.Models;

namespace SBA_Bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountDetailsController : ControllerBase
    {
        private readonly SBAdbContext _context;

        public AccountDetailsController(SBAdbContext context)
        {
            _context = context;
        }

        // GET: api/AccountDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDetails>>> GetaccountDetails()
        {
            return await _context.accountDetails.ToListAsync();
        }

        // GET: api/AccountDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDetails>> GetAccountDetails(long id)
        {
            var accountDetails = await _context.accountDetails.FindAsync(id);

            if (accountDetails == null)
            {
                return NotFound();
            }

            return accountDetails;
        }

        // PUT: api/AccountDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountDetails(long id, AccountDetails accountDetails)
        {
            if (id != accountDetails.AccountNo)
            {
                return BadRequest();
            }

            _context.Entry(accountDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountDetailsExists(id))
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

        // POST: api/AccountDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccountDetails>> PostAccountDetails(AccountDetails accountDetails)
        {
            
            _context.accountDetails.Add(accountDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountDetails", new { id = accountDetails.AccountNo }, accountDetails);
        }

        // DELETE: api/AccountDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountDetails(long id)
        {
            var accountDetails = await _context.accountDetails.FindAsync(id);
            if (accountDetails == null)
            {
                return NotFound();
            }

            _context.accountDetails.Remove(accountDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountDetailsExists(long id)
        {
            return _context.accountDetails.Any(e => e.AccountNo == id);
        }
    }
}
