using System;
using System.Collections.Generic;
using System.Text;
using CovidCommunity.Api.Location.Dto;

namespace CovidCommunity.Api.Location
{
    public interface  ILocationService
    {
        LocationDto GetLocation(int locationId);
    }
}
