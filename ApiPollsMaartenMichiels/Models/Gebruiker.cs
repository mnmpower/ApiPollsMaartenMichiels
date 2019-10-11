using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPollsMaartenMichiels.Models
{
    public class Gebruiker
    {
        public long GebruikerID { get; set; }
        public String Voornaam { get; set; }
        public String Naam { get; set; }
        public String Email { get; set; }
        public String Wachtwoord { get; set; }
        public String Gebruikersnaam { get; set; }
    }
}
