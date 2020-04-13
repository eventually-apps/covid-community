using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.MultiTenancy;
using CovidCommunity.Api.Editions;
using CovidCommunity.Api.MultiTenancy;

namespace CovidCommunity.Api.EntityFrameworkCore.Seed.Item
{
    public class DefaultItemBuilder
    {
        private readonly ApiDbContext _context;

        public DefaultItemBuilder(ApiDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultItem(_context);
        }

        public void CreateDefaultItem(ApiDbContext context)
        {
            context.Items.Add(new Domains.Item { ItemName = "Toilet Paper"});
            context.Items.Add(new Domains.Item { ItemName = "Hand Sanitizer"});
            context.Items.Add(new Domains.Item { ItemName = "Canned Food"});
            context.Items.Add(new Domains.Item { ItemName = "Gloves"});
            context.Items.Add(new Domains.Item { ItemName = "Face Mask"});
        }
    }
}
