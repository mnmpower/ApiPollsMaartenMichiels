﻿using System;
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
    public class StemController : ControllerBase
    {
        private readonly GebruikerContex _context;

        public StemController(GebruikerContex context)
        {
            _context = context;
        }

        // GET: api/Stem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stem>>> GetStemmen()
        {
            return await _context.Stemmen.ToListAsync();
        }

        // GET: api/Stem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stem>> GetStem(long id)
        {
            var stem = await _context.Stemmen.FindAsync(id);

            if (stem == null)
            {
                return NotFound();
            }

            return stem;
        }

        // DELETE: api/Stem/DeleteGebruikers/5/5
        [HttpDelete("DeleteGebruikers/{GebruikerID}")]
        public async Task<ActionResult<Stem>> DeleteStemByGebruikerIDAndPollID(long GebruikerID, long pollOptieID)
        {
            var stem = await _context.Stemmen.Where(s => s.GebruikerID == GebruikerID && s.PollOptieID == pollOptieID).FirstOrDefaultAsync();

            if (stem == null)
            {
                return NotFound();
            }

            _context.Stemmen.Remove(stem);
            await _context.SaveChangesAsync();

            return stem;
        }

        // PUT: api/Stem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStem(long id, Stem stem)
        {
            if (id != stem.StemID)
            {
                return BadRequest();
            }

            _context.Entry(stem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StemExists(id))
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

        // POST: api/Stem
        [HttpPost]
        public async Task<ActionResult<Stem>> PostStem(Stem stem)
        {
            Boolean doorgaan = true;
            List<Stem> alleStemmen = new List<Stem>();
            alleStemmen = await _context.Stemmen.ToListAsync();
            foreach (var bestaandeStem in alleStemmen)
            {
                if (bestaandeStem.GebruikerID == stem.GebruikerID && bestaandeStem.PollOptieID == stem.PollOptieID)
                {
                    doorgaan = false;
                }
            }

            if (doorgaan)
            {
                _context.Stemmen.Add(stem);
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction("GetStem", new { id = stem.StemID }, stem);
        }

        // DELETE: api/Stem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stem>> DeleteStem(long id)
        {
            var stem = await _context.Stemmen.FindAsync(id);
            if (stem == null)
            {
                return NotFound();
            }

            _context.Stemmen.Remove(stem);
            await _context.SaveChangesAsync();

            return stem;
        }

        private bool StemExists(long id)
        {
            return _context.Stemmen.Any(e => e.StemID == id);
        }
    }
}
