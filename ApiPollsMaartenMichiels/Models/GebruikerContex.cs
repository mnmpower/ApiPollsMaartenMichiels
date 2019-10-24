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
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollGebruiker> PollGebruikers { get; set; }
        public DbSet<PollOptie> PollOpties { get; set; }
        public DbSet<Stem> Stemmen { get; set; }
        public DbSet<Vriend> Vrienden { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gebruiker>().ToTable("Gebruiker");
            modelBuilder.Entity<Poll>().ToTable("Poll");
            modelBuilder.Entity<PollGebruiker>().ToTable("PollGebruiker");
            modelBuilder.Entity<PollOptie>().ToTable("PollOptie");
            modelBuilder.Entity<Stem>().ToTable("Stem");
            modelBuilder.Entity<Vriend>().ToTable("Vriend");

            modelBuilder.Entity<Vriend>()
                .HasOne(v => v.Ontvanger)
                .WithMany(g => g.OntvangenVrienden)
                .HasForeignKey(v => v.OntvangerID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vriend>()
                .HasOne(v => v.Verzender)
                .WithMany(g => g.VerzondenVrienden)
                .HasForeignKey(v => v.VerzenderID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
