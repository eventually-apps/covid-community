using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;
using CovidCommunity.Api.Authorization.Users;

namespace CovidCommunity.Api.Domains
{
    public class Location: Entity
    {
        public string Name { get; set; }
        public string PrimaryAddress { get; set; }
        public string SecondaryAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public long LocationOwnerId { get; set; }
        public User LocationOwner { get; set; }
        public List<User> Users { get; set; }
        public List<InventoryByLocation> InventoryByLocations { get; set; }
    }
}
