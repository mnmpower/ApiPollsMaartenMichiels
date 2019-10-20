using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPollsMaartenMichiels.Models
{
    public class GebruikerContex : DbContext
    {
        public GebruikerContex(DbContextOptions<GebruikerContex> options) : base(options) { }

        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Poll> polls { get; set; }
        public DbSet<PollGebruiker> PollGebruikers { get; set; }
        public DbSet<PollOptie> PollOpties { get; set; }
        public DbSet<Stem> Stemmen { get; set; }
        public DbSet<Vriend> Vrienden { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gebruiker>().ToTable("Gebruiker").HasMany(g => g.vriendenlijstOnvangen).WithOne(v => v.Ontvanger);
            modelBuilder.Entity<Gebruiker>().ToTable("Gebruiker").HasMany(g => g.vriendenlijstVerzonden).WithOne(v => v.Verzender);
            modelBuilder.Entity<Poll>().ToTable("Poll");
            modelBuilder.Entity<PollGebruiker>().ToTable("PollGebruiker");
            modelBuilder.Entity<PollOptie>().ToTable("PollOptie");
            modelBuilder.Entity<Stem>().ToTable("Stem");
            modelBuilder.Entity<Vriend>().ToTable("Vriend");
        }
    }
}
