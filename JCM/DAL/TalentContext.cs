using Jcm.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jcm.DAL
{
    public class TalentContext : DbContext
    {
        public DbSet<PerformanceAct> Acts { get; set; } = null!;
        public DbSet<Performer> Performers { get; set; } = null!;

        public TalentContext(DbContextOptions<TalentContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PerformanceAct>()
                .HasData(
                    new PerformanceAct()
                    {
                        Id = 1,
                        Name = "The Beatles"
                    },
                    new PerformanceAct()
                    {
                        Id = 2,
                        Name = "The Rolling Stones"
                    }
                );

            modelBuilder.Entity<Performer>()
                .HasData(
                    new Performer()
                    {
                        Id = 1,
                        FirstName = "John",
                        PerformanceActId = 1
                    },
                    new Performer()
                    {
                        Id = 2,
                        FirstName = "Paul",
                        PerformanceActId = 1
                    },
                    new Performer()
                    {
                        Id = 3,
                        FirstName = "George",
                        PerformanceActId = 1
                    },
                    new Performer()
                    {
                        Id = 4,
                        FirstName = "Ringo",
                        PerformanceActId = 1
                    }, new Performer()
                    {
                        Id = 5,
                        FirstName = "Mick",
                        LastName = "Jagger",
                        PerformanceActId = 2
                    },
                    new Performer()
                    {
                        Id = 6,
                        FirstName = "Keith",
                        LastName = "Richards",
                        PerformanceActId = 2
                    },
                    new Performer()
                    {
                        Id = 7,
                        FirstName = "Ron",
                        LastName = "Wood",
                        PerformanceActId = 2
                    },
                    new Performer()
                    {
                        Id = 8,
                        FirstName = "Bill",
                        LastName = "Wyman",
                        PerformanceActId = 2
                    },
                    new Performer()
                    {
                        Id = 9,
                        FirstName = "Charlie",
                        LastName = "Watts",
                        PerformanceActId = 2
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
