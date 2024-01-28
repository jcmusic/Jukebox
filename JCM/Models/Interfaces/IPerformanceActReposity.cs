using Jcm.Models.Api;

namespace Jcm.BLL.Interfaces
{
    public interface IPerformanceActReposity
    {
        Task<PerformanceActDto> GetPerformanceActAsync(
            int id, bool includePerformers = false);
        Task<List<PerformanceActDto>> GetPerformanceActsAsync(
            int pageNumber, int pageSize, bool includePerformers = false);
    }
}