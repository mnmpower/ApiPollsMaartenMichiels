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
    public class DashboardController : Controller
    {
        private readonly GebruikerContex _context;

        public DashboardController(GebruikerContex context)
        {
            _context = context;
        }

        // GET: api/Dashboard/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DashboardViewModel>> GetDashboardViewModel(long id)
        {
            DashboardViewModel dashboardVM = new DashboardViewModel();
            List<Poll> beheerderPolls = new List<Poll>();
            List<Poll> uitgenodigdePolls = new List<Poll>();
            List<Stem> alleUitgebrachteStemmen = new List<Stem>();
            List<Stem> UitgebrachteStemmenGebruiker = new List<Stem>();
            List<Poll> allepolls = await _context.Polls
                .Include(p => p.PollGebruikers)
                .Include(p => p.PollOpties)
                .ToListAsync();

            foreach (var poll in allepolls)
            {
                foreach (var pg in poll.PollGebruikers)
                {
                    if (pg.PollID == pg.PollID && pg.GebruikerID ==id)
                    {
                        uitgenodigdePolls.Add(poll);
                    }
                    if (pg.GebruikerID == id && pg.Beheerder == true)
                    {
                        beheerderPolls.Add(poll);
                    }
                }
            }

            alleUitgebrachteStemmen = await _context.Stemmen
                .Include(s => s.Gebruiker)
                .ToListAsync();

            foreach (var stem in alleUitgebrachteStemmen)
            {
                if (stem.GebruikerID == id)
                {
                    UitgebrachteStemmenGebruiker.Add(stem);
                }
            }


            dashboardVM.BeheerderPolls = beheerderPolls;
            dashboardVM.UitgenodigdePolls = uitgenodigdePolls;
            dashboardVM.UitgebrachteStemmen = UitgebrachteStemmenGebruiker;

            return dashboardVM;
        }
    }
}