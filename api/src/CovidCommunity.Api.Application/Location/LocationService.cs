using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Dependency;
using Abp.Domain.Repositories;
using CovidCommunity.Api.Location.Dto;

namespace CovidCommunity.Api.Location
{
    public class LocationService: ILocationService, ITransientDependency
    {
        private readonly IRepository<Domains.Location> _locationRepo;
        public LocationService(IRepository<Domains.Location> locationRepo)
        {
            _locationRepo = locationRepo;
        }
        public LocationDto GetLocation(int locationId)
        {
            var location = _locationRepo.GetAll().FirstOrDefault(x => x.Id == locationId) ?? new Domains.Location();

            return new LocationDto
            {
                LocationId = location.Id,
                LocationName = location.Name,
                PrimaryAddress = location.PrimaryAddress,
                SecondaryAddress = location.SecondaryAddress,
                City = location.City,
                State = location.State,
                Zip = location.Zip
            };
        }
    }
}
