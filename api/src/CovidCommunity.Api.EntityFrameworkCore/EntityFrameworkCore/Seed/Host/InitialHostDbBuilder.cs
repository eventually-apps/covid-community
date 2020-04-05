using CovidCommunity.Api.Configuration;

namespace CovidCommunity.Api.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly ApiDbContext _context;
        private readonly SeedSettings _seedSettings;

        public InitialHostDbBuilder(ApiDbContext context, SeedSettings seedSettings)
        {
            _context = context;
            _seedSettings = seedSettings;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context, _seedSettings).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
