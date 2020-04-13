using System;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Abp.MultiTenancy;
using CovidCommunity.Api.EntityFrameworkCore.Seed.Host;
using CovidCommunity.Api.EntityFrameworkCore.Seed.Tenants;
using Microsoft.Extensions.Configuration;
using CovidCommunity.Api.Configuration;
using CovidCommunity.Api.EntityFrameworkCore.Seed.Item;

namespace CovidCommunity.Api.EntityFrameworkCore.Seed
{
    public static class SeedHelper
    {
        private static SeedSettings _seedSettings;

        public static void SeedHostDb(IIocResolver iocResolver)
        {
            _seedSettings = iocResolver.Resolve<IConfiguration>().GetSection("SeedSettings").Get<SeedSettings>();
            WithDbContext<ApiDbContext>(iocResolver, SeedHostDb);
        }

        public static void SeedHostDb(ApiDbContext context)
        {
            context.SuppressAutoSetTenantId = true;

            // Host seed
            new InitialHostDbBuilder(context, _seedSettings).Create();

            // Default tenant seed (in host database).
            new DefaultTenantBuilder(context).Create();
            new TenantRoleAndUserBuilder(context, 1, _seedSettings).Create();
            new DefaultItemBuilder(context).Create();
        }

        private static void WithDbContext<TDbContext>(IIocResolver iocResolver, Action<TDbContext> contextAction)
            where TDbContext : DbContext
        {
            using (var uowManager = iocResolver.ResolveAsDisposable<IUnitOfWorkManager>())
            {
                using (var uow = uowManager.Object.Begin(TransactionScopeOption.Suppress))
                {
                    var context = uowManager.Object.Current.GetDbContext<TDbContext>(MultiTenancySides.Host);

                    contextAction(context);

                    uow.Complete();
                }
            }
        }
    }
}
