using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CovidCommunity.Api.Authorization.Users;
using CovidCommunity.Api.Domains;

namespace CovidCommunity.Api.RequestOrder.Dto
{
    public class RequestOrderDto: EntityDto<int>
    {
        public List<RequestDto> Requests { get; set; }
        public long OrderRequestedByUserId { get; set; }
        public int OrderForLocationId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? FulfillmentDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
