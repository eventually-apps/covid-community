using System;
using System.Collections.Generic;
using System.Text;
using CovidCommunity.Api.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CovidCommunity.Api.EntityFrameworkCore.Configurations
{
    public class LocationConfiguration: IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasMany(x => x.Users).WithOne(x => x.UserLocation).HasForeignKey(x => x.UserLocationId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.LocationOwner).WithMany(x => x.Locations).HasForeignKey(x => x.LocationOwnerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
