using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPollsMaartenMichiels.Models
{
    public class Poll
    {
        public long PollID { get; set; }

        public String naam { get; set; }

        public virtual ICollection<PollGebruiker> PollGebruikers { get; set; }
        public virtual ICollection<PollOptie> PollOpties { get; set; }
    }
}
