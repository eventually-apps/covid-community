using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidCommunity.Api.Controllers;
using CovidCommunity.Api.Item;
using CovidCommunity.Api.Item.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CovidCommunity.Api.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController: ApiControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("getItemsByLocation")]
        public List<LocationItemDto> RequestItem(int locationId)
        {
           return _itemService.GetItemsByLocation(locationId);
        }
    }
}
