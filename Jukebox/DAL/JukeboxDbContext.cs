using Jukebox.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Jukebox.DAL
{
    public interface IJukeboxDbContext
    {
        DbSet<Performer> Performers { get; set; }
        DbSet<Song> Songs { get; set; }

        public abstract EntityEntry<TEntity> Update<TEntity>(TEntity entity)
            where TEntity : class;

        public abstract Task<int> SaveChangesAsync();
    }

    public class JukeboxDbContext : DbContext, IJukeboxDbContext
    {
        public DbSet<Performer> Performers { get; set; } = null!;
        public DbSet<Song> Songs { get; set; } = null!;

        public JukeboxDbContext(DbContextOptions<JukeboxDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Performer>()
                .HasData(
                    new Performer()
                    {
                        Id = 1,
                        Name = "The Beatles",
                    },
                    new Performer()
                    {
                        Id = 2,
                        Name = "The Rolling Stones",
                    }
                );

            modelBuilder.Entity<Song>()
                .HasData(
                    new Song()
                    {
                        Id = 1,
                        Name = "Strawberry Fields",
                        PerformerId = 1
                    },
                    new Song()
                    {
                        Id = 2,
                        Name = "Yellow Submarine",
                        PerformerId = 1
                    },
                    new Song()
                    {
                        Id = 3,
                        Name = "The Long and Winding Road",
                        PerformerId = 1
                    },
                    new Song()
                    {
                        Id = 4,
                        Name = "All You Need Is Love",
                        PerformerId = 1
                    }, new Song()
                    {
                        Id = 5,
                        Name = "Tumblin Dice",
                        PerformerId = 2
                    },
                    new Song()
                    {
                        Id = 6,
                        Name = "Gimme Shelter",
                        PerformerId = 2
                    },
                    new Song()
                    {
                        Id = 7,
                        Name = "Angie",
                        PerformerId = 2
                    },
                    new Song()
                    {
                        Id = 8,
                        Name = "Wild Horses",
                        PerformerId = 2
                    },
                    new Song()
                    {
                        Id = 9,
                        Name = "Can't You Hear Me Knocking",
                        PerformerId = 2
                    }
                );

            base.OnModelCreating(modelBuilder);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
