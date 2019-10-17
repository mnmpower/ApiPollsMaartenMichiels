using ApiPollsMaartenMichiels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPollsMaartenMichiels.Services
{
    public interface IUserService
    {
        Gebruiker Authenticate(string username, string password);
    }
}
