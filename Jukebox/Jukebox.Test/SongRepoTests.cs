using Jukebox.Models.Api;
using Jukebox.Test.Fixtures;
using Microsoft.EntityFrameworkCore;

namespace Jukebox.Test
{
    /// <summary>
    /// These are integration tests that test the SongRepository and the Automapper Profile  
    /// (The repo accepts and returns dto models to prevent other layers from seeing entities)
    /// </summary>
    public class SongRepoTests
    {
        private JukeboxContextFixture _fixture = new JukeboxContextFixture(seed: false);

        [Fact]
        public async void SongRepo_AddSong()
        {
            // Arrange
            var maxId = await _fixture._dbContext.Performers.MaxAsync(x => x.Id);
            var songToCreate = new SongForCreationDto
            {
                Name = "Song name",
                Year = 2024,
                PerformerId = maxId
            };

            // Act
            var newSongDto = await _fixture.SongRepository.AddSong(songToCreate);

            // Assert
            Assert.NotNull(newSongDto);
            Assert.Equal(songToCreate.Name, newSongDto.Name);
            Assert.Equal(songToCreate.Year, newSongDto.Year);
            Assert.True(newSongDto.Id > 0);
        }

        [Fact]
        public async void SongRepo_RemoveSong()
        {
            // Arrange
            var maxSongId = await _fixture._dbContext.Songs.MaxAsync(x => x.Id);
            var preSongCount = await _fixture._dbContext.Songs.CountAsync();

            // Act
            var removed = await _fixture.SongRepository.RemoveSong(maxSongId);
            var postSongCount = await _fixture._dbContext.Songs.CountAsync();

            // Assert
            Assert.True(removed);
            Assert.True(preSongCount == postSongCount + 1);
        }

        [Fact]
        public async void SongRepo_GetSongById()
        {
            // Arrange
            var minSongId = await _fixture._dbContext.Songs.MinAsync(x => x.Id);

            // Act
            var songDto = await _fixture.SongRepository.GetSongByIdAsync(minSongId);

            // Assert
            Assert.NotNull(songDto);
            Assert.Equal(minSongId, songDto.Id);
        }

        [Fact]
        public async void SongRepo_SongExistsByIdAsync()
        {
            // Arrange
            var minSongId = await _fixture._dbContext.Songs.MinAsync(x => x.Id);

            // Act
            var songExists = await _fixture.SongRepository.SongExistsAsync(minSongId);

            // Assert
            Assert.True(songExists);
        }

        [Fact]
        public async void SongRepo_SongExistsByCreationDtoAsync()
        {
            // Arrange
            var songDto = await _fixture._dbContext.Songs.FirstOrDefaultAsync();
            var creationDto = new SongForCreationDto
            {
                Name = songDto.Name,
                PerformerId = songDto.PerformerId,
                Year = songDto.Year
            };

            // Act
            var songExists = await _fixture.SongRepository.SongExistsAsync(creationDto);

            // Assert
            Assert.True(songExists);
        }

        [Fact]
        public async void SongRepo_GetSongsAsync_Pagination()
        {
            // Arrange
            var songCount = await _fixture._dbContext.Songs.CountAsync();
            var pageNo = songCount > 0 ? 1 : 0;

            // Act
            var (songlist, paginationMetadata) = await _fixture.SongRepository.GetSongsAsync(null, pageNo, 1);

            // Assert
            Assert.Equal(songCount, paginationMetadata.TotalPageCount);
            Assert.Equal(songCount, paginationMetadata.TotalItemCount);
            Assert.Equal(pageNo, paginationMetadata.CurrentPage);
        }

        [Fact]
        public async void SongRepo_GetSongsAsync_List()
        {
            // Arrange
            var songCount = await _fixture._dbContext.Songs.CountAsync();
            var pageNo = songCount > 14 ? 15 : songCount;

            // Act
            var (songlist, paginationMetadata) = await _fixture.SongRepository.GetSongsAsync();

            // Assert
            Assert.Equal(songCount, songlist.Count);
            Assert.Equal(songCount, paginationMetadata.TotalItemCount);
            Assert.Equal(pageNo, paginationMetadata.CurrentPage);
        }

        [Fact]
        public async void SongRepo_GetSongsAsync_Search()
        {
            // Arrange
            var searchTerm = "you";

            // Act
            var (songlist, paginationMetadata) = await _fixture.SongRepository.GetSongsAsync(searchTerm);

            // Assert
            Assert.Equal(2, songlist.Count);
        }

        [Fact]
        public async void SongRepo_UpdateSongAsync()
        {
            // Arrange
            var songDto = await _fixture._dbContext.Songs.FirstOrDefaultAsync();
            if (songDto == null)
                throw new Exception("test data missing.");

            var oldName = songDto?.Name;
            var newName = "NewName";

            var updateDto = new SongForUpdateDto
            {
                Name = newName,
                Id = songDto.Id,
                Year = songDto.Year,
                PerformerId = songDto.PerformerId
            };

            // Act
            await _fixture.SongRepository.UpdateSongAsync(updateDto);

            // Assert
            Assert.Equal(newName, songDto.Name);
        }
    }
}


