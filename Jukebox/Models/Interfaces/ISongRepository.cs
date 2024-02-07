using Jukebox.Models.Api;

namespace Jukebox.BLL.Interfaces
{
    public interface ISongRepository
    {
        Task<SongDto> AddSong(SongForCreationDto song);
        Task<SongDto> GetSongByIdAsync(int id);
        Task<(List<SongDto>, PaginationMetadata)> GetSongsAsync(string searchterm, int pageNumber, int pageSize);
        Task<List<SongDto>> GetSongsByPerformerIdAsync(int id, int pageNumber, int pageSize);
        Task<bool> RemoveSong(int songId);
        Task<bool> SaveChangesAsync();
        Task<bool> SongExistsAsync(int id);
        Task<bool> SongExistsAsync(SongForCreationDto songForCreationDto);
        Task<SongDto> UpdateSongAsync(SongForUpdateDto dto);
    }
}