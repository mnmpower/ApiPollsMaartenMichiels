using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPollsMaartenMichiels.Models
{
    public class Stem
    {
        public long StemID { get; set; }
        public long PollOptieID { get; set; }
        public long GebruikerID { get; set; }
    }
}
