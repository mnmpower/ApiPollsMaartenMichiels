using ApiPollsMaartenMichiels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPollsMaartenMichiels.ViewModels
{
    public class EditPollViewModel
    {
        public Poll EditPoll { get; set; }
        public ICollection<PollGebruiker> PollGebruikers { get; set; }
        public ICollection<PollGebruiker> Beheerders { get; set; }
        public ICollection<PollOptie> PollOpties { get; set; }
    }
}
