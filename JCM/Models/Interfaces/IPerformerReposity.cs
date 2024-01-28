using Jcm.Models.Api;

namespace Jcm.BLL.Interfaces
{
    public interface IPerformerReposity
    {
        Task<PerformerDto> GetPerformerAsync(int id);
    }
}