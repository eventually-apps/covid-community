using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Application.Services;
using CovidCommunity.Api.Domains;
using CovidCommunity.Api.Item.Dto;
using Microsoft.AspNetCore.Authentication;

namespace CovidCommunity.Api.Item
{
    public interface IItemService
    {
        List<LocationItemDto> GetItemsByLocation(int locationId);
    }
}
