using AutoMapper;
using Jcm.DAL.Entities;
using Jcm.Models.Api;

namespace Jcm.DAL.AutoMapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            // PerformanceAct
            CreateMap<PerformanceAct, PerformanceActDto>();
            CreateMap<PerformanceActDto, PerformanceAct>();

            // Performer
            CreateMap<Performer, PerformerDto>();
            CreateMap<PerformerDto, Performer>();
        }
    }
}
