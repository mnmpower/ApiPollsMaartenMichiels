using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPollsMaartenMichiels.Models
{
    public class Stem
    {
        long StemID { get; set; }
        long PollOptieID { get; set; }
        long GebruikerID { get; set; }
    }
}
