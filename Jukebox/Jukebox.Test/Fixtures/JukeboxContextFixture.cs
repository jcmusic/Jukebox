using AutoMapper;
using Jcm.DAL.AutoMapper;
using Jukebox.DAL;
using Jukebox.DAL.Entities;
using Jukebox.DAL.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Jukebox.Test.Fixtures
{
    [CollectionDefinition("JukeboxContextCollection")]
    public class JukeboxContextFixture
    {
        public JukeboxDbContext _dbContext;
        public PerformerRespository PerformerRespository { get; set; }
        public SongRepository SongRepository { get; set; }

        public JukeboxContextFixture(bool seed)
        {

            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var optionsBuilder = new DbContextOptionsBuilder<JukeboxDbContext>()
                .UseSqlite(connection);

            _dbContext = new JukeboxDbContext(optionsBuilder.Options);
            _dbContext.Database.Migrate();

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new AutomapperProfiles()));
            var mapper = new Mapper(configuration);

            PerformerRespository = new PerformerRespository(_dbContext, mapper);
            SongRepository = new SongRepository(_dbContext, mapper);

            if (seed)
            {
                // data initialization
                _dbContext.Performers
                    .AddRange(new List<Performer>()
                    {
                        new Performer()
                        {
                            Name = "The Muppets",
                        },
                        new Performer()
                        {
                            Name = "The Mullets",
                        }
                    }
                );

                _dbContext.Songs
                    .AddRange(new List<Song>()
                    {
                        new Song()
                        {
                            Name = "Strawberry Fields",
                            PerformerId = 3
                        },
                        new Song()
                        {
                            Name = "Yellow Submarine",
                            PerformerId = 3
                        },
                        new Song()
                        {
                            Name = "The Long and Winding Road",
                            PerformerId = 3
                        },
                        new Song()
                        {
                            Name = "All You Need Is Love",
                            PerformerId = 3
                        }, new Song()
                        {
                            Name = "Tumblin Dice",
                            PerformerId = 4
                        },
                        new Song()
                        {
                            Name = "Gimme Shelter",
                            PerformerId = 4
                        },
                        new Song()
                        {
                            Name = "Angie",
                            PerformerId = 4
                        },
                        new Song()
                        {
                            Name = "Wild Horses",
                            PerformerId = 4
                        },
                        new Song()
                        {
                            Name = "Can't You Hear Me Knocking",
                            PerformerId = 4
                        }
                    }
                );

                _dbContext.SaveChanges();
            }
        }
    }
}
