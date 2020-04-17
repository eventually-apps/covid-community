using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CovidCommunity.Api.Authorization.Roles;
using CovidCommunity.Api.Authorization.Users;
using CovidCommunity.Api.Domains;
using CovidCommunity.Api.EntityFrameworkCore.Configurations;
using CovidCommunity.Api.MultiTenancy;

namespace CovidCommunity.Api.EntityFrameworkCore
{
    public class ApiDbContext : AbpZeroDbContext<Tenant, Role, User, ApiDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Item> Items { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<RequestOrder> RequestOrders { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<InventoryByLocation> InventoryByLocations { get; set; }
        
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>("");
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new RequestOrderConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryByLocationConfiguration());
        }
    }
}
