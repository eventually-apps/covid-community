using System;
using System.Collections.Generic;
using System.Text;

namespace CovidCommunity.Api.Item.Dto
{
    public class LocationItemDto
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int LocationId { get; set; }
        public int ItemByLocationQuantity { get; set; }
    }
}
