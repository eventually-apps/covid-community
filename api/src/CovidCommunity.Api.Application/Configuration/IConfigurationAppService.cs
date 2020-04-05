using System.Threading.Tasks;
using CovidCommunity.Api.Configuration.Dto;

namespace CovidCommunity.Api.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
