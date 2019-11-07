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
    public class EditPollController : Controller
    {
        private readonly GebruikerContex _context;

        public EditPollController(GebruikerContex context)
        {
            _context = context;
        }

        // GET: api/EditPoll/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EditPollViewModel>> GetEditPollViewModel(long id, string zoekterm)
        {
            EditPollViewModel editPollVM = new EditPollViewModel();

            Poll poll = await _context.Polls.Where(p => p.PollID == id)
                .Include(p => p.PollGebruikers)
                .Include(p => p.PollOpties)
                .FirstOrDefaultAsync();

            editPollVM.EditPoll = poll;
            return editPollVM;
        }
    }
}