using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace CovidCommunity.Api.Domains
{
    public class Item: Entity
    {
        public string ItemName { get; set; }
        public List<InventoryByLocation> InventoryByLocations { get; set; }
    }
}
