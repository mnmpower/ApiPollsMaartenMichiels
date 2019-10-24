using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPollsMaartenMichiels.Models;
using ApiPollsMaartenMichiels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPollsMaartenMichiels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollCreateController : Controller
    {
        private readonly GebruikerContex _context;

        public PollCreateController(GebruikerContex context)
        {
            _context = context;
        }

        // GET: api/PollCreate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CreatePollViewModel>> GetCreatePollViewModel(long id, string zoekterm)
        {
            CreatePollViewModel createPollVM = new CreatePollViewModel();
            var alleGebruikers = await _context.Gebruikers.Where(g => g.GebruikerID != id).ToListAsync();
            var VriendenVerzonden = from a in _context.Vrienden.Where(v => v.Bevestigd == true && v.VerzenderID == id) select a;
            var VriendenOntvangen = from a in _context.Vrienden.Where(v => v.Bevestigd == true && v.OntvangerID == id) select a;
            var enkelVriendGebruikers = new List<Gebruiker>();
            var gebruikersMetZoektermVoldaan = new List<Gebruiker>();
            var vriendGebruikerIDs = new List<long?>();

            foreach (var vriend in VriendenVerzonden)
            {
                vriendGebruikerIDs.Add(vriend.OntvangerID);
            }
            foreach (var vriend in VriendenOntvangen)
            {
                vriendGebruikerIDs.Add(vriend.VerzenderID);
            }

            if (zoekterm != "")
            {
                gebruikersMetZoektermVoldaan = alleGebruikers.Where(g => g.Gebruikersnaam.Contains(zoekterm)).ToList();
                foreach (var gebruiker in gebruikersMetZoektermVoldaan)
                {
                    if (vriendGebruikerIDs.Contains(gebruiker.GebruikerID))
                    {
                        enkelVriendGebruikers.Add(gebruiker);
                    }
                }
                createPollVM.GebruikersOpZoekterm = enkelVriendGebruikers;
            }

            createPollVM.AlleVrienden = alleGebruikers;

            return createPollVM;
        }
    }
}