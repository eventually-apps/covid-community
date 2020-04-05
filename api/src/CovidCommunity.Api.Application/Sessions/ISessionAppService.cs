using System.Threading.Tasks;
using Abp.Application.Services;
using CovidCommunity.Api.Sessions.Dto;

namespace CovidCommunity.Api.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
