using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPollsMaartenMichiels.Models
{
    public class Vriend
    {
        public long VriendID { get; set; }
        public long Gebruiker1ID { get; set; }
        public long Gebruiker2ID { get; set; }
    }
}
