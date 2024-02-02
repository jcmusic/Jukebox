using Jukebox.Models.Api;

namespace Jukebox.BLL.Interfaces
{
    public interface ISongRepository
    {
        Task<SongDto> AddSong(SongForCreationDto song);
        Task<SongDto> GetSongAsync(int id);
        Task<List<SongDto>> GetSongsAsync(int pageNumber = 0, int pageSize = 15);
        Task<List<SongDto>> GetSongsByPerformerIdAsync(int id, int pageNumber, int pageSize);
        Task<bool> RemoveSong(int songId);
        Task<bool> SaveChangesAsync();
        Task<bool> SongExistsAsync(int id);
        Task<SongDto> UpdateSongAsync(SongForUpdateDto dto);
    }
}