using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CovidCommunity.Api.Configuration.Dto;

namespace CovidCommunity.Api.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ApiAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
