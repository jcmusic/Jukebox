using AutoMapper;
using Jcm.BLL.Interfaces;
using Jcm.Models.Api;
using Microsoft.EntityFrameworkCore;

namespace Jcm.DAL.Repositories
{
    public class PerformerRespository : IPerformerReposity
    {
        private readonly TalentContext _talentContext;
        private readonly IMapper _mapper;

        public PerformerRespository(TalentContext talentContext, IMapper mapper)
        {
            _talentContext = talentContext;
            _mapper = mapper;
        }

        public async Task<PerformerDto> GetPerformerAsync(int id)
        {
            var peformer = await _talentContext.Performers
                .FirstOrDefaultAsync(x => x.Id == id);

            var mappedPerformer =  _mapper.Map<PerformerDto>(peformer);

            return mappedPerformer;
        }
    }
}
