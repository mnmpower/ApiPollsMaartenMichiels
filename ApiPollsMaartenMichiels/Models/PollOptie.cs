using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPollsMaartenMichiels.Models
{
    public class PollOptie
    {
        public long PollOptieID { get; set; }
        public String Antwoord { get; set; }
        public long PollID { get; set; }

    }
}
