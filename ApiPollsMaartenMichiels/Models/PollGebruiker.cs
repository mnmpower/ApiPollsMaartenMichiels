using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPollsMaartenMichiels.Models
{
    public class PollGebruiker
    {
        public long PollGebruikerID { get; set; }

        public long PollID { get; set; }
        public long GebruikerID { get; set; }

        public bool Beheerder { get; set; }

        public Gebruiker Gebruiker { get; set; }
        public Poll Poll { get; set; }





    }
}
