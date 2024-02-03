using Jukebox.Models.Api;

namespace Jukebox.Models.Repositories
{
    public interface IPerformerRespository
    {
        Task<PerformerDto> AddPerformerAsync(PerformerForCreationDto dto);
        Task<PerformerDto> GetPerformerAsync(int id);
        Task<(List<PerformerDto>, PaginationMetadata)> GetPerformersAsync(string sesarchTerm, int pageNumber, int pageSize);
        Task<bool> PerformerExistsAsync(PerformerForCreationDto dto);
        Task<bool> PerformerExistsAsync(int performerId);
        Task<bool> RemovePerformerAsync(PerformerDto dto);
        Task<bool> SaveChangesAsync();
        Task<PerformerDto> UpdatePerformerAsync(PerformerForUpdateDto dto);
    }
}