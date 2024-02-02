using AutoMapper;
using Jukebox.BLL.Interfaces;
using Jukebox.DAL.Entities;
using Jukebox.Models.Api;
using Microsoft.EntityFrameworkCore;

namespace Jukebox.DAL.Repositories
{
    public class SongRepository : ISongRepository
    {
        #region Fields/Ctor

        private readonly JukeboxContext _jukeboxContext;
        private readonly IMapper _mapper;

        public SongRepository(JukeboxContext jukeboxContext, IMapper mapper)
        {
            _jukeboxContext = jukeboxContext;
            _mapper = mapper;
        }

        #endregion

        public async Task<SongDto> GetSongAsync(int id)
        {
            var song = await _jukeboxContext.Songs
                .FirstOrDefaultAsync(x => x.Id == id);

            var mappedSong = _mapper.Map<SongDto>(song);

            return mappedSong;
        }

        public async Task<List<SongDto>> GetSongsAsync(
            int pageNumber = 0, int pageSize = 15)
        {
            var songList = await _jukeboxContext.Songs
                .OrderBy(x => x.Name)
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var mappedSongList = _mapper.Map<List<SongDto>>(songList);

            return mappedSongList;
        }

        public async Task<SongDto> AddSong(SongForCreationDto song)
        {
            var entity = _mapper.Map<Song>(song);
            await _jukeboxContext.AddAsync<Song>(entity);
            await SaveChangesAsync();
            return _mapper.Map<SongDto>(entity);
        }

        public async Task<SongDto> UpdateSongAsync(SongForUpdateDto song)
        {
            var entity = _mapper.Map<Song>(song);
            _jukeboxContext.Songs.Update(entity);
            await SaveChangesAsync();
            return _mapper.Map<SongDto>(entity);
        }

        public async Task<bool> RemoveSong(int songId)
        {
            var entity = await _jukeboxContext.Songs
                .SingleAsync(s => s.Id == songId);

            if (entity == null) 
                return false;

            _jukeboxContext.Songs.Remove(entity);
            await SaveChangesAsync();
            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _jukeboxContext.SaveChangesAsync() >= 1);
        }

        public async Task<bool> SongExistsAsync(int id)
        {
            var entity = await _jukeboxContext.Songs
                .SingleOrDefaultAsync(s => s.Id == id);

            if (entity == null) return false;

            _jukeboxContext.Remove(entity);
            return await SaveChangesAsync();
        }

        public async Task<List<SongDto>> GetSongsByPerformerIdAsync(
            int id, int pageNumber = 0, int pageSize = 10)
        {
            var enitityList = await _jukeboxContext.Songs
                .Where(s => s.PerformerId == id)
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .OrderBy(s => s.Name)
                .ToListAsync();

            return _mapper.Map<List<SongDto>>(enitityList);
        }
    }
}
