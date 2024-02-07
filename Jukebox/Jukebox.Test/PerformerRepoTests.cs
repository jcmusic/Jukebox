using Jukebox.Models.Api;
using Jukebox.Test.Fixtures;
using Microsoft.EntityFrameworkCore;

namespace Jukebox.Test
{
    /// <summary>
    /// These are integration tests that test the PerformerRepository and the Automapper Profile  
    /// (The repo accepts and returns dto models to prevent other layers from seeing entities)
    /// </summary>
    public class PerformerRepoTests
    {
        private JukeboxContextFixture _fixture = new JukeboxContextFixture(seed : false);

        [Fact]
        public async void PerformerRepo_GetPerformers_List()
        {
            // Arrange
            var performerCount = await _fixture._dbContext.Performers.CountAsync();

            // Act
            var (performersList, paginationMetadata) = await _fixture.PerformerRespository.GetPerformersAsync();

            // Assert
            Assert.Equal(performerCount, performersList.Count);
        }

        //[Fact]
        //public async void PerformerRepo_GetPerformers_Search()
        //{
        //    // Arrange
        //    var performerCount = await _fixture._dbContext.Performers.CountAsync();

        //    // Act
        //    var (performersList, paginationMetadata) = await _fixture.PerformerRespository.GetPerformersAsync();

        //    // Assert
        //    Assert.Equal(performerCount, performersList.Count);
        //}

        [Fact]
        public async void PerformerRepo_GetPerformers_Pagination()
        {
            // Arrange
            var performerCount = await _fixture._dbContext.Performers.CountAsync();
            var pageNo = performerCount > 0 ? 1 : 0;

            // Act
            var (performersList, paginationMetadata) = await _fixture.PerformerRespository.GetPerformersAsync(null, pageNo, 1);

            // Assert
            Assert.Equal(performerCount, paginationMetadata.TotalPageCount);
            Assert.Equal(performerCount, paginationMetadata.TotalItemCount);
            Assert.Equal(pageNo, paginationMetadata.CurrentPage);
        }

        [Fact]
        public async void PerformerRepo_GetPerformerById()
        {
            // Arrange
                // based on seed data

            // Act
            var performer = await _fixture.PerformerRespository.GetPerformerAsync(2);

            // Assert
            Assert.Equal("The Rolling Stones", performer.Name);
        }

        [Fact]
        public async void PerformerRepo_PerformerExistsById()
        {
            // Arrange
                // based on seed data
            var maxId = await _fixture._dbContext.Performers.MaxAsync(x => x.Id);

            // Act
            var shouldExist = await _fixture.PerformerRespository.PerformerExistsAsync(1);
            var shouldNotexist = await _fixture.PerformerRespository.PerformerExistsAsync(maxId + 1);

            // Assert
            Assert.True(shouldExist, "PerformerId 1 should exist.");
            Assert.False(shouldNotexist, $"PerformerId {maxId + 1} should not exist.");
        }

        [Fact]
        public async void PerformerRepo_AddPerformerAsync()
        {
            // Arrange
            var performerForCreationDto = new PerformerForCreationDto 
            { 
                Name = "testPerformer" 
            };

            // Act
            var performerDto = await _fixture.PerformerRespository.AddPerformerAsync(performerForCreationDto);

            // Assert
            Assert.Equal("testPerformer", performerDto.Name);
            Assert.True(performerDto.Id > 0);
        }

        [Fact]
        public async void PerformerRepo_RemovePerformerAsync()
        {
            // Arrange
            // based on seed data
            var maxId = await _fixture._dbContext.Performers.MaxAsync(x => x.Id);
            var performerDto = await _fixture.PerformerRespository.GetPerformerAsync(maxId);

            // Act
            var removed = await _fixture.PerformerRespository.RemovePerformerAsync(performerDto);  // removal
            var nullPerformerDto = await _fixture.PerformerRespository.GetPerformerAsync(maxId);  // check it's removed
            // Note: add ->    //check the cascase delete

            // Assert
            Assert.True(removed);
            Assert.Null(nullPerformerDto);
        }

        [Fact]
        public async void PerformerRepo_PerformerExistsAsync_Dto()
        {
            // Arrange
            var maxId = await _fixture._dbContext.Performers.MaxAsync(x => x.Id);
            var performerDto = await _fixture.PerformerRespository.GetPerformerAsync(maxId);
            var existinCreationDto = new PerformerForCreationDto
            {
                Name = performerDto.Name
            };
            var newCreationDto = new PerformerForCreationDto
            {
                Name = "SantaClaus"
            };

            // Act
            var shouldExist = await _fixture.PerformerRespository.PerformerExistsAsync(existinCreationDto);
            var shouldNotexist = await _fixture.PerformerRespository.PerformerExistsAsync(newCreationDto);

            // Assert
            Assert.True(shouldExist);
            Assert.False(shouldNotexist);
        }
    }
}


