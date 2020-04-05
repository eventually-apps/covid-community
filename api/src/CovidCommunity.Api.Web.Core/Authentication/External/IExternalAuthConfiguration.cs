using System.Collections.Generic;

namespace CovidCommunity.Api.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
