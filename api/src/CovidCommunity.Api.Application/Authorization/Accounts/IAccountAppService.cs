using System.Threading.Tasks;
using Abp.Application.Services;
using CovidCommunity.Api.Authorization.Accounts.Dto;

namespace CovidCommunity.Api.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
