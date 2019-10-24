using ApiPollsMaartenMichiels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPollsMaartenMichiels.ViewModels
{
    public class DashboardViewModel
    {

        public ICollection<Poll> BeheerderPolls { get; set; }
        public ICollection<Poll> UitgenodigdePolls { get; set; }
        public ICollection<Stem> UitgebrachteStemmen { get; set; }
    }
}
