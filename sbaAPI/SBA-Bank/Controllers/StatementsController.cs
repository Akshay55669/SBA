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
    public class StatementsController : ControllerBase
    {
        private readonly SBAdbContext _context;

        public StatementsController(SBAdbContext context)
        {
            _context = context;
        }

        // GET: api/Statements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Statement>>> Getstatements()
        {
            return await _context.statements.ToListAsync();
        }

        // GET: api/Statements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Statement>> GetStatement(int id)
        {
            var statement = await _context.statements.FindAsync(id);

            if (statement == null)
            {
                return NotFound();
            }

            return statement;
        }

        // PUT: api/Statements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatement(int id, Statement statement)
        {
            if (id != statement.txnId)
            {
                return BadRequest();
            }

            _context.Entry(statement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatementExists(id))
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

        // POST: api/Statements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Statement>> PostStatement(Statement statement)
        {
            _context.statements.Add(statement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatement", new { id = statement.txnId }, statement);
        }

        // DELETE: api/Statements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatement(int id)
        {
            var statement = await _context.statements.FindAsync(id);
            if (statement == null)
            {
                return NotFound();
            }

            _context.statements.Remove(statement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatementExists(int id)
        {
            return _context.statements.Any(e => e.txnId == id);
        }
    }
}
