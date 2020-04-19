﻿using System;
using Abp.Domain.Entities;


namespace CovidCommunity.Api.Domains
{
    public class Request: Entity
    {
        public RequestOrder RequestOrder { get; set; }
        public int RequestOrderId { get; set; }
        public Item RequestedItem { get; set; }
        public int RequestedItemId { get; set; }
        public int RequestedAmount { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime? FulfilledDate { get; set; }
        public bool IsActive { get; set; }
    }
}