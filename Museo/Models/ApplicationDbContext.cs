using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Models
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ResidentVisit>().HasKey(t => new { t.ResidentId, t.VisitId});
            modelBuilder.Entity<PersonalityInEvent>().HasKey(t => new { t.EventId, t.EventPersonalityId});
            modelBuilder.Entity<EO>().HasKey(t => new { t.EventId, t.EventOrganizerId });

            modelBuilder.Entity<EO>()
             .HasOne(pd => pd.Event)
             .WithMany(r => r.EOs)
             .HasForeignKey(pd => pd.EventId)
             .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<EO>()
                .HasOne(pd => pd.EventOrganizer)
                .WithMany(r => r.EOs)
                .HasForeignKey(pd => pd.EventOrganizerId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<PersonalityInEvent>()
               .HasOne(pd => pd.Event)
               .WithMany(r => r.PersonalityInEvents)
               .HasForeignKey(pd => pd.EventId)
               .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<PersonalityInEvent>()
                .HasOne(pd => pd.EventPersonality)
                .WithMany(r => r.PersonalityInEvents)
                .HasForeignKey(pd => pd.EventPersonalityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ResidentVisit>()
                .HasOne(pd => pd.Visit)
                .WithMany(r => r.ResidentVisits)
                .HasForeignKey(pd => pd.VisitId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ResidentVisit>()
                .HasOne(pd => pd.Resident)
                .WithMany(r => r.ResidentVisits)
                .HasForeignKey(pd => pd.ResidentId)
                .OnDelete(DeleteBehavior.Restrict);                   
        }


        public DbSet<Activity> Activities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<ResidentVisit> ResidentVisits { get; set; }
        public DbSet<TypeAct> TypeActs{ get; set; }
        public DbSet<Visit> Visits{ get; set; }

        public DbSet<AnualPlan> AnualPlans { get; set; }

        public DbSet<Block> Blocks { get; set; }

        public DbSet<DocumentCategory> DocumentCategories { get; set; }

        public DbSet<Document> Documents{ get; set; }

        public DbSet<EO>  EOs{ get; set; }

        public DbSet<Event> Events{ get; set; }

        public DbSet<EventOrganizer> EventOrganizers { get; set; }

        public DbSet<EventPersonality>EventPersonalities { get; set; }

        public DbSet<EventThematic>  EventThematics{ get; set; }

        public DbSet<EventType> EventTypes { get; set; }

        public DbSet<Incidence> Incidences { get; set; }

        public DbSet<IncidenceType> IncidenceTypes { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<PersonalityInEvent> PersonalityInEvents { get; set; }




    }
}