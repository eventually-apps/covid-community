using Abp.MultiTenancy;
using CovidCommunity.Api.Authorization.Users;

namespace CovidCommunity.Api.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
