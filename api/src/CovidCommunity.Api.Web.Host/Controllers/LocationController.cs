using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidCommunity.Api.Controllers;
using CovidCommunity.Api.Location;
using CovidCommunity.Api.Location.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CovidCommunity.Api.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController: ApiControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("getLocation")]
        public LocationDto GetLocation(int locationId)
        {
            return _locationService.GetLocation(locationId);
        }
    }
}
