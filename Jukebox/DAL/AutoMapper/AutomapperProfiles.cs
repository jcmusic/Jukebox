using AutoMapper;
using Jukebox.DAL.Entities;
using Jukebox.Models.Api;

namespace Jcm.DAL.AutoMapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            // PerformanceAct
            CreateMap<Performer, PerformerDto>();
            CreateMap<PerformerDto, Performer>();
            CreateMap<PerformerForCreationDto, Performer>();
            CreateMap<PerformerForUpdateDto, Performer>();

            // Performer
            CreateMap<Song, SongDto>();
            CreateMap<SongDto, Song>();
            CreateMap<SongForCreationDto, Song>();
            CreateMap<SongForUpdateDto, Song>();
        }
    }
}
