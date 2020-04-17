using System;
using System.Collections.Generic;
using System.Text;
using CovidCommunity.Api.Authorization.Users;
using CovidCommunity.Api.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CovidCommunity.Api.EntityFrameworkCore.Configurations
{
    public class RequestOrderConfiguration: IEntityTypeConfiguration<RequestOrder>
    {
        public void Configure(EntityTypeBuilder<RequestOrder> builder)
        {
            builder.HasMany(x => x.Requests).WithOne(x => x.RequestOrder).HasForeignKey(x => x.RequestOrderId);
            builder.HasOne(x => x.OrderRequestedByUser).WithMany(x => x.RequestOrders).HasForeignKey(x => x.OrderRequestedByUserId);
        }
    }
}
