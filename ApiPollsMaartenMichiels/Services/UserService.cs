using ApiPollsMaartenMichiels.Helpers;
using ApiPollsMaartenMichiels.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiPollsMaartenMichiels.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly GebruikerContex _gebruikerContex;
        public UserService(IOptions<AppSettings> appSettings, GebruikerContex gebruikerContex)
        {
            _appSettings = appSettings.Value;
            _gebruikerContex = gebruikerContex;
        }

        public Gebruiker Authenticate(string Email, string password)
        {
            var Gebruiker = _gebruikerContex.Gebruikers.SingleOrDefault(x => x.Email == Email && x.Wachtwoord == password);

            // return null if Gebruiker not found
            if
            (Gebruiker == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[] {
                        new Claim("GebruikerID", Gebruiker.GebruikerID.ToString()),
                        new Claim("Email", Gebruiker.Email),
                        new Claim("Gebruikersnaam", Gebruiker.Gebruikersnaam)
                    }),

                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            Gebruiker.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            Gebruiker.Wachtwoord = null;
            return Gebruiker;
        }
    }
}
