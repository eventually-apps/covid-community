using Abp.AutoMapper;
using CovidCommunity.Api.Authentication.External;

namespace CovidCommunity.Api.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
