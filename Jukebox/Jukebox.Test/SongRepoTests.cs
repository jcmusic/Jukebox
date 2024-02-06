namespace Jukebox.Test
{
    /// <summary>
    /// These are integration tests that test the SongRepository and the Automapper Profile  
    /// (The repo accepts and returns dto models to prevent other layers from seeing entities)
    /// </summary>
    public class SongRepoTests
    {
        //private JukeboxContextFixture _repos = new JukeboxContextFixture(seed : false);

        //[Fact]
        //public async void PerformerRepo_GetPerformers()
        //{
        //    // Arrange
        //    // based on seed data

        //    // Act
        //    var (performersList, paginationMetadata) = await _repos.PerformerRespository.GetPerformersAsync();

        //    // Assert
        //    Assert.True(performersList.Count >= 1);
        //}

        //[Fact]
        //public async void PerformerRepo_GetPerformerById()
        //{
        //    // Arrange
        //        // based on seed data

        //    // Act
        //    var performer = await _repos.PerformerRespository.GetPerformerAsync(2);

        //    // Assert
        //    Assert.Equal("The Rolling Stones", performer.Name);
        //}

        //[Fact]
        //public async void PerformerRepo_PerformerExistsById()
        //{
        //    // Arrange
        //        // based on seed data
        //    var maxId = await _repos._dbContext.Performers.MaxAsync(x => x.Id);

        //    // Act
        //    var shouldExist = await _repos.PerformerRespository.PerformerExistsAsync(1);
        //    var shouldNotexist = await _repos.PerformerRespository.PerformerExistsAsync(maxId + 1);

        //    // Assert
        //    Assert.True(shouldExist, "PerformerId 1 should exist.");
        //    Assert.False(shouldNotexist, $"PerformerId {maxId + 1} should not exist.");
        //}

        //[Fact]
        //public async void PerformerRepo_AddPerformerAsync()
        //{
        //    // Arrange
        //    var performerForCreationDto = new PerformerForCreationDto 
        //    { 
        //        Name = "testPerformer" 
        //    };

        //    // Act
        //    var performerDto = await _repos.PerformerRespository.AddPerformerAsync(performerForCreationDto);

        //    // Assert
        //    Assert.Equal("testPerformer", performerDto.Name);
        //    Assert.True(performerDto.Id > 0);
        //}

        //[Fact]
        //public async void PerformerRepo_RemovePerformerAsync()
        //{
        //    // Arrange
        //    // based on seed data
        //    var maxId = await _repos._dbContext.Performers.MaxAsync(x => x.Id);
        //    var performerDto = await _repos.PerformerRespository.GetPerformerAsync(maxId);

        //    // Act
        //    var removed = await _repos.PerformerRespository.RemovePerformerAsync(performerDto);
        //    var nullPerformerDto = await _repos.PerformerRespository.GetPerformerAsync(maxId);

        //    // Assert
        //    Assert.True(removed);
        //    Assert.Null(nullPerformerDto);
        //}

        ////Task<bool> PerformerExistsAsync(PerformerForCreationDto dto);
        //[Fact]
        //public async void PerformerRepo_PerformerExistsAsync_Dto()
        //{
        //    // Arrange
        //    var maxId = await _repos._dbContext.Performers.MaxAsync(x => x.Id);
        //    var performerDto = await _repos.PerformerRespository.GetPerformerAsync(maxId);
        //    var existinCreationDto = new PerformerForCreationDto
        //    {
        //        Name = performerDto.Name
        //    };
        //    var newCreationDto = new PerformerForCreationDto
        //    {
        //        Name = "SantaClaus"
        //    };

        //    // Act
        //    var shouldExist = await _repos.PerformerRespository.PerformerExistsAsync(existinCreationDto);
        //    var shouldNotexist = await _repos.PerformerRespository.PerformerExistsAsync(newCreationDto);

        //    // Assert
        //    Assert.True(shouldExist);
        //    Assert.False(shouldNotexist);
        //}

        ////Task<(List<PerformerDto>, PaginationMetadata)> GetPerformersAsync(string sesarchTerm, int pageNumber, int pageSize);
        ////[Fact]
        ////public async void PerformerRepo_()
        ////{
        ////    // Arrange

        ////    // Act


        ////    // Assert

        ////}
    }


}


