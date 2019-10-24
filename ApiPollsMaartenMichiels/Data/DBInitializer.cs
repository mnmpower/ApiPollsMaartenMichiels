using ApiPollsMaartenMichiels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPollsMaartenMichiels.Data
{
    public class DBInitializer
    {

        public static void Initialize(GebruikerContex context)
        {
            context.Database.EnsureCreated();
            // Look for any Gebruikers.
            if (context.Gebruikers.Any())
            {
                return;
                // DB has been seeded
            }

            context.Gebruikers.AddRange(
                new Gebruiker { Voornaam = "Maarten", Naam = "Michiels",
                    Email = "r0695495@student.thomasmore.be",
                    Gebruikersnaam = "mnmpower", Wachtwoord = "R1234-56"},

                new Gebruiker { Voornaam="Sacha", Naam="Rypens",
                            Email ="r0655332@student.thomasmore.be",
                            Gebruikersnaam ="sacha", Wachtwoord="R1234-56"},

                new Gebruiker { Voornaam="Spons", Naam="De Brerker",
                            Email ="r0555555@student.thomasmore.be",
                            Gebruikersnaam ="spons", Wachtwoord="R1234-56"},
                new Gebruiker { Voornaam="Benji", Naam="Bruyns",
                            Email ="r0666666@student.thomasmore.be",
                            Gebruikersnaam ="benji", Wachtwoord="R1234-56"}
                );

            context.Polls.AddRange(
                new Poll { naam = "Favoriete eten" },
                new Poll { naam = "Favoriete drinken" }
                );

            context.PollOpties.AddRange(
                new PollOptie { PollID = 1, Antwoord = "Vol-au-vent" },
                new PollOptie { PollID = 1, Antwoord = "Hamburgers" },
                new PollOptie { PollID = 1, Antwoord = "Ovenschotel" },
                new PollOptie { PollID = 2, Antwoord = "Fanta" },
                new PollOptie { PollID = 2, Antwoord = "Duvel" }
                );

            context.PollGebruikers.AddRange(
                new PollGebruiker { PollID = 1, GebruikerID = 1, Beheerder = true },
                new PollGebruiker { PollID = 1, GebruikerID = 2, Beheerder = false },
                new PollGebruiker { PollID = 1, GebruikerID = 3, Beheerder = true },
                new PollGebruiker { PollID = 2, GebruikerID = 1, Beheerder = false },
                new PollGebruiker { PollID = 2, GebruikerID = 3, Beheerder = false },
                new PollGebruiker { PollID = 2, GebruikerID = 4, Beheerder = true }
                );

            //context.Stemmen.AddRange(
            //    new Stem { GebruikerID = 1, PollOptieID = 2 },
            //    new Stem { GebruikerID = 1, PollOptieID = 4 },
            //    new Stem { GebruikerID = 2, PollOptieID = 2 },
            //    new Stem { GebruikerID = 3, PollOptieID = 1 },
            //    new Stem { GebruikerID = 3, PollOptieID = 5 },
            //    new Stem { GebruikerID = 4, PollOptieID = 5 }
            //    );

            context.Vrienden.AddRange(
                new Vriend { VerzenderID=1, OntvangerID = 4, Bevestigd = true },
                new Vriend { VerzenderID = 1, OntvangerID = 2, Bevestigd = true },
                new Vriend { VerzenderID = 1, OntvangerID = 3, Bevestigd = true },
                new Vriend { VerzenderID = 2, OntvangerID = 3, Bevestigd = true },
                new Vriend { VerzenderID = 2, OntvangerID = 4, Bevestigd = true }
                );

            context.SaveChanges();
        }
    }
}
