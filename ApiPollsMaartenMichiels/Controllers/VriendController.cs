using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiPollsMaartenMichiels.Models;
using System.Collections;

namespace ApiPollsMaartenMichiels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VriendController : ControllerBase
    {
        private readonly GebruikerContex _context;

        public VriendController(GebruikerContex context)
        {
            _context = context;
        }

        // GET: api/Vriend
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vriend>>> GetVrienden()
        {
            return await _context.Vrienden.ToListAsync();
        }

        // GET: api/Vriend/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vriend>> GetVriend(long id)
        {
            var vriend = await _context.Vrienden.FindAsync(id);

            if (vriend == null)
            {
                return NotFound();
            }

            return vriend;
        }

        // PUT: api/Vriend/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVriend(long id, Vriend vriend)
        {
            if (id != vriend.VriendID)
            {
                return BadRequest();
            }

            _context.Entry(vriend).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VriendExists(id))
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

        // POST: api/Vriend
        [HttpPost]
        public async Task<ActionResult<Vriend>> PostVriend(Vriend vriend)
        {
            _context.Vrienden.Add(vriend);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVriend", new { id = vriend.VriendID }, vriend);
        }

        // DELETE: api/Vriend/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vriend>> DeleteVriend(long id)
        {
            var vriend = await _context.Vrienden.FindAsync(id);
            if (vriend == null)
            {
                return NotFound();
            }

            _context.Vrienden.Remove(vriend);
            await _context.SaveChangesAsync();

            return vriend;
        }

        // GET: api/Vriend/GetVriendschapsverzoekIn/5
        [HttpGet("GetVriendschapsverzoekIn/{id}")]
        public async Task<ActionResult<IEnumerable<Vriend>>> GetVriendschapsverzoekIn(long id)
        {
            var VriendschapsverzoekenIn = from v in _context.Vrienden.Where(v => v.Bevestigd == false && v.OntvangerID == id) select v;

            if (VriendschapsverzoekenIn == null)
            {
                return NotFound();
            }

            return await VriendschapsverzoekenIn.ToListAsync();
        }

        // GET: api/Vriend/GetVriendschapsverzoekUit/5
        [HttpGet("GetVriendschapsverzoekUit/{id}")]
        public async Task<ActionResult<IEnumerable<Vriend>>> GetVriendschapsverzoekUit(long id)
        {
            var VriendschapsverzoekenUit = from v in _context.Vrienden.Where(v => v.Bevestigd == false && v.VerzenderID == id) select v;

            if (VriendschapsverzoekenUit == null)
            {
                return NotFound();
            }

            return await VriendschapsverzoekenUit.ToListAsync();
        }


        private bool VriendExists(long id)
        {
            return _context.Vrienden.Any(e => e.VriendID == id);
        }
    }
}
