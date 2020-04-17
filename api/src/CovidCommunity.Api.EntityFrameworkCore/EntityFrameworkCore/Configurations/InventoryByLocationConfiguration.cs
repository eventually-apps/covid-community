using System;
using System.Collections.Generic;
using System.Text;
using CovidCommunity.Api.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CovidCommunity.Api.EntityFrameworkCore.Configurations
{
    public class InventoryByLocationConfiguration : IEntityTypeConfiguration<InventoryByLocation>
    {
        public void Configure(EntityTypeBuilder<InventoryByLocation> builder)
        {
            builder.HasOne(x => x.Item).WithMany(x => x.InventoryByLocations).HasForeignKey(x => x.ItemId);
            builder.HasOne(x => x.Location).WithMany(x => x.InventoryByLocations).HasForeignKey(x => x.LocationId);
        }
    }
}
