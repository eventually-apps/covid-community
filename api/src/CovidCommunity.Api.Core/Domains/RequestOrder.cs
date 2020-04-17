using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;
using CovidCommunity.Api.Authorization.Users;

namespace CovidCommunity.Api.Domains
{
    public class RequestOrder: Entity
    {
        public List<Request> Requests { get; set; }
        public User OrderRequestedByUser { get; set; }
        public long OrderRequestedByUserId { get; set; }
        public Location OrderForLocation { get; set; }
        public int OrderForLocationId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FulfillmentDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
