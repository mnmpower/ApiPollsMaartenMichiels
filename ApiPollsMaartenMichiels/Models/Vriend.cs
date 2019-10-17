using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPollsMaartenMichiels.Models
{
    public class Vriend
    {
        public long VriendID { get; set; }
        public long VerzenderID { get; set; }
        public long OntvangerID { get; set; }
        public Boolean Bevestigd { get; set; }
    }
}
