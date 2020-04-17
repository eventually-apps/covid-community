using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace CovidCommunity.Api.Domains
{
    public class InventoryByLocation: Entity
    {
        public Item Item { get; set; }
        public int ItemId { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public int ItemByLocationQuantity { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
