using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPollsMaartenMichiels.Models
{
    public class Vriend
    {
        public long VriendID { get; set; }
        [ForeignKey("Gebruiker")]
        public long? VerzenderID { get; set; }
        [ForeignKey("Gebruiker")]
        public long? OntvangerID { get; set; }
        public Boolean Bevestigd { get; set; }


        public virtual Gebruiker Verzender { get; set; }
        public virtual Gebruiker Ontvanger { get; set; }
    }
}
