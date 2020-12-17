using AspNetCoreHero.Boilerplate.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories
{
    public interface IActivityLogRepository
    {
        Task<List<ActivityLogResponse>> GetListAsync(string userId);
        Task AddLogAsync(string action, string userId);
    }
}
