using AutoMapper;
using Jcm.BLL.Interfaces;
using Jcm.DAL.Entities;
using Jcm.Models.Api;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Jcm.DAL.Repositories
{
    public class PerformanceActRespository : IPerformanceActReposity
    {
        private readonly TalentContext _talentContext;
        private readonly IMapper _mapper;

        public PerformanceActRespository(TalentContext talentContext, IMapper mapper)
        {
            _talentContext = talentContext;
            _mapper = mapper;
        }

        public async Task<PerformanceActDto> GetPerformanceActAsync(
            int id, bool includePerformers = false)
        {
            var query = _talentContext.PerformanceActs as IQueryable<PerformanceAct>;

            // if you don't do this w/ "query = query.", the include will be lost.
            if (includePerformers)
                query = query.Include(a => a.Performers);
            
            var act = await query.FirstOrDefaultAsync(p => p.Id == id);

            var mappedAct = _mapper.Map<PerformanceActDto>(act);

            return mappedAct;
        }

        public async Task<List<PerformanceActDto>> GetPerformanceActsAsync(
            int pageNumber, int pageSize, bool includePerformers = false)
        {

            var query = _talentContext.PerformanceActs as IQueryable<PerformanceAct>;

            // if you don't do this w/ "query = query.", the include will be lost.
            if (includePerformers)
                query = query.Include(a => a.Performers);  

            var list = await query
                .Skip(pageNumber)
                .Take(pageSize)
                .ToListAsync();

            var mappedList =  _mapper.Map<List<PerformanceActDto>>(list);

            return mappedList;
        }
    }
}
