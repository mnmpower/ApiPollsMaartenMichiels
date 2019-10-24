using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPollsMaartenMichiels.Models
{
    public class PollOptie
    {
        public long PollOptieID { get; set; }

        public long PollID { get; set; }
        public String Antwoord { get; set; }


        public virtual Poll Poll { get; set; }
        public virtual ICollection<Stem> Stemmen { get; set; }
    }
}
