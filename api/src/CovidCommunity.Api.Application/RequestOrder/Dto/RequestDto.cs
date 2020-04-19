using System;
using System.Collections.Generic;
using System.Text;

namespace CovidCommunity.Api.RequestOrder.Dto
{
    public class RequestDto
    { 
        public int RequestOrderId { get; set; }
        public int RequestedItemId { get; set; }
        public int RequestedAmount { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime? FulfilledDate { get; set; }
        public bool IsActive { get; set; }
    }
}
