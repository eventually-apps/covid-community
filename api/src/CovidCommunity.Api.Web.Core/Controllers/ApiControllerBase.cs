using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace CovidCommunity.Api.Controllers
{
    public abstract class ApiControllerBase: AbpController
    {
        protected ApiControllerBase()
        {
            LocalizationSourceName = ApiConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
