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
    public class PollOptieController : ControllerBase
    {
        private readonly GebruikerContex _context;

        public PollOptieController(GebruikerContex context)
        {
            _context = context;
        }

        // GET: api/PollOptie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PollOptie>>> GetPollOpties()
        {
            return await _context.PollOpties.ToListAsync();
        }

        // GET: api/PollOptie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PollOptie>> GetPollOptie(long id)
        {
            var pollOptie = await _context.PollOpties.FindAsync(id);

            if (pollOptie == null)
            {
                return NotFound();
            }

            return pollOptie;
        }

        // PUT: api/PollOptie/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPollOptie(long id, PollOptie pollOptie)
        {
            if (id != pollOptie.PollOptieID)
            {
                return BadRequest();
            }

            _context.Entry(pollOptie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PollOptieExists(id))
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

        // POST: api/PollOptie
        [HttpPost]
        public async Task<ActionResult<PollOptie>> PostPollOptie(PollOptie pollOptie)
        {
            _context.PollOpties.Add(pollOptie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPollOptie", new { id = pollOptie.PollOptieID }, pollOptie);
        }

        // DELETE: api/PollOptie/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PollOptie>> DeletePollOptie(long id)
        {
            var pollOptie = await _context.PollOpties.FindAsync(id);
            if (pollOptie == null)
            {
                return NotFound();
            }

            _context.PollOpties.Remove(pollOptie);
            await _context.SaveChangesAsync();

            return pollOptie;
        }

        private bool PollOptieExists(long id)
        {
            return _context.PollOpties.Any(e => e.PollOptieID == id);
        }
    }
}
