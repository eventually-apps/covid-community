using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidCommunity.Api.RequestOrder.Dto;

namespace CovidCommunity.Api.Web.Host.Models.RequestOrder
{
    public class NewRequestDto
    {
        public int RequestedItemId { get; set; }
        public int RequestedAmount { get; set; }

        public RequestDto ConvertToDto()
        {
            return new RequestDto
            {
                RequestedItemId = RequestedItemId,
                RequestedAmount = RequestedAmount,
                RequestedDate = DateTime.Now,
                IsActive = true
            };
        }
    }
}
