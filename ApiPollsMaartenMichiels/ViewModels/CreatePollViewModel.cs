using ApiPollsMaartenMichiels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPollsMaartenMichiels.ViewModels
{
    public class CreatePollViewModel
    {

        public ICollection<Gebruiker> AlleVrienden { get; set; }
        public ICollection<Gebruiker> GeselecteerdeVrienden { get; set; }
        public ICollection<Gebruiker> GebruikersOpZoekterm { get; set; }
    }
}
