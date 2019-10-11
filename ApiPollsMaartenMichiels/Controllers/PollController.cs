using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiPollsMaartenMichiels.Models;

namespace ApiPollsMaartenMichiels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private readonly GebruikerContex _context;

        public PollController(GebruikerContex context)
        {
            _context = context;
        }

        // GET: api/Poll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poll>>> Getpolls()
        {
            return await _context.polls.ToListAsync();
        }

        // GET: api/Poll/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Poll>> GetPoll(long id)
        {
            var poll = await _context.polls.FindAsync(id);

            if (poll == null)
            {
                return NotFound();
            }

            return poll;
        }

        // PUT: api/Poll/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoll(long id, Poll poll)
        {
            if (id != poll.PollID)
            {
                return BadRequest();
            }

            _context.Entry(poll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PollExists(id))
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

        // POST: api/Poll
        [HttpPost]
        public async Task<ActionResult<Poll>> PostPoll(Poll poll)
        {
            _context.polls.Add(poll);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoll", new { id = poll.PollID }, poll);
        }

        // DELETE: api/Poll/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Poll>> DeletePoll(long id)
        {
            var poll = await _context.polls.FindAsync(id);
            if (poll == null)
            {
                return NotFound();
            }

            _context.polls.Remove(poll);
            await _context.SaveChangesAsync();

            return poll;
        }

        private bool PollExists(long id)
        {
            return _context.polls.Any(e => e.PollID == id);
        }
    }
}
