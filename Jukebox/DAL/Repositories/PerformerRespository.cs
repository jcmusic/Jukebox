using AutoMapper;
using Jukebox.DAL.Entities;
using Jukebox.Models.Api;
using Jukebox.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jukebox.DAL.Repositories
{
    public class PerformerRespository : IPerformerRespository
    {
        #region Fields/Ctor

        private readonly JukeboxContext _jukeboxContext;
        private readonly IMapper _mapper;

        public PerformerRespository(
            JukeboxContext jukeboxContext, IMapper mapper)
        {
            _jukeboxContext = jukeboxContext;
            _mapper = mapper;
        }

        #endregion

        public async Task<PerformerDto> AddPerformerAsync(
            PerformerForCreationDto dto)
        {
            var entity = _mapper.Map<Performer>(dto);
            await _jukeboxContext.Performers.AddAsync(entity);

            await SaveChangesAsync();

            return _mapper.Map<PerformerDto>(entity);
        }

        public async Task<PerformerDto> GetPerformerAsync(int id)
        {
            var entity = await _jukeboxContext.Performers
                .SingleOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<PerformerDto>(entity);
        }

        public async Task<List<PerformerDto>> GetPerformerAsync(
            int pageNumber, int pageSize)
        {
            var entityList = await _jukeboxContext.Performers
                .Skip(pageNumber)
                .Take(pageSize)
                .ToListAsync();

            var mappedList = _mapper.Map<List<PerformerDto>>(entityList);

            return mappedList;
        }

        //public async Task<List<PerformerDto>> GetPerformerAsync(
        //    int pageNumber, int pageSize, bool includeSongs = false)
        //{
        //    //There is a gotcha w/ using IQuerable to build the Linq statement
        //    var query = _jukeboxContext.Performers as IQueryable<Performer>;

        //    // if you don't do it like this: w/ "query = query.", the include will be lost.
        //    if (includeSongs)
        //        query = query.Include(a => a.Songs);

        //    var list = await query
        //        .Skip(pageNumber)
        //        .Take(pageSize)
        //        .ToListAsync();

        //    var mappedList = _mapper.Map<List<PerformerDto>>(list);

        //    return mappedList;
        //}

        public async Task<bool> PerformerExistsAsync(int performerId)
        {
            return await _jukeboxContext.Performers.AnyAsync(p => p.Id == performerId);
        }

        public Task<bool> PerformerExistsAsync(PerformerForCreationDto dto)
        {
            return _jukeboxContext.Performers.AnyAsync(p => p.Name == dto.Name);
        }

        public async Task<bool> RemovePerformerAsync(PerformerDto dto)
        {
            var entity = await _jukeboxContext.Performers
                .SingleOrDefaultAsync(p => p.Id == dto.Id);

            if (entity == null)
                throw new ArgumentException($"Performer '{dto.Name}' not found.");

            _jukeboxContext.Performers.Remove(entity);
            await _jukeboxContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _jukeboxContext.SaveChangesAsync() >= 0);
        }

        public async Task<PerformerDto> UpdatePerformerAsync(PerformerForUpdateDto dto)
        {
            var entity = await _jukeboxContext.Performers.SingleOrDefaultAsync(p => p.Id == dto.Id);

            if (entity == null) throw new ArgumentException("Performer not found");

            entity.Name = dto.Name;

            _jukeboxContext.Update<Performer>(entity);

            await _jukeboxContext.SaveChangesAsync();

            return _mapper.Map<PerformerDto>(entity);
        }
    }
}
