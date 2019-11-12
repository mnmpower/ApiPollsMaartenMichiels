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
    public class PollGebruikerController : ControllerBase
    {
        private readonly GebruikerContex _context;

        public PollGebruikerController(GebruikerContex context)
        {
            _context = context;
        }

        // GET: api/PollGebruiker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PollGebruiker>>> GetPollGebruikers()
        {
            return await _context.PollGebruikers.ToListAsync();
        }

        // GET: api/PollGebruiker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PollGebruiker>> GetPollGebruiker(long id)
        {
            var pollGebruiker = await _context.PollGebruikers.FindAsync(id);

            if (pollGebruiker == null)
            {
                return NotFound();
            }

            return pollGebruiker;
        }

        // PUT: api/PollGebruiker/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPollGebruiker(long id, PollGebruiker pollGebruiker)
        {
            if (id != pollGebruiker.PollGebruikerID)
            {
                return BadRequest();
            }

            _context.Entry(pollGebruiker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PollGebruikerExists(id))
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

        // POST: api/PollGebruiker
        [HttpPost]
        public async Task<ActionResult<PollGebruiker>> PostPollGebruiker(PollGebruiker pollGebruiker)
        {
            _context.PollGebruikers.Add(pollGebruiker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPollGebruiker", new { id = pollGebruiker.PollGebruikerID }, pollGebruiker);
        }

        // POST: api/PollGebruiker
        [HttpPost("AddPollGebruikers/{id}")]
        public async Task<ActionResult<PollGebruiker>> AddPollGebruikers(long id, List<Gebruiker> Gebruikers)
        {
            PollGebruiker pgs = new PollGebruiker();
            foreach (var gebruiker in Gebruikers)
            {
                PollGebruiker pg = new PollGebruiker();
                pg.GebruikerID = gebruiker.GebruikerID;
                pg.PollID = id;
                _context.PollGebruikers.Add(pg);
                await _context.SaveChangesAsync();
            }




            return pgs;
        }

        // DELETE: api/PollGebruiker/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PollGebruiker>> DeletePollGebruiker(long id)
        {
            var pollGebruiker = await _context.PollGebruikers.FindAsync(id);
            if (pollGebruiker == null)
            {
                return NotFound();
            }

            _context.PollGebruikers.Remove(pollGebruiker);
            await _context.SaveChangesAsync();

            return pollGebruiker;
        }

        // DELETE: api/PollGebruiker/DeletePG/5
        [HttpDelete("DeletePG/{id}")]
        public async Task<ActionResult<PollGebruiker>> DeletePG(long id, long id2)
        {
            PollGebruiker pollGebruiker = new PollGebruiker();

            pollGebruiker = _context.PollGebruikers.Where(p => p.PollID == id).Where(p => p.GebruikerID == id2).FirstOrDefault();

            if (pollGebruiker == null)
            {
                return NotFound();
            }

            _context.PollGebruikers.Remove(pollGebruiker);
            await _context.SaveChangesAsync();

            return pollGebruiker;
        }

        private bool PollGebruikerExists(long id)
        {
            return _context.PollGebruikers.Any(e => e.PollGebruikerID == id);
        }
    }
}
