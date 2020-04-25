using Abp.Application.Services.Dto;

namespace CovidCommunity.Api.Location.Dto
{
    public class LocationDto: EntityDto<int>
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string PrimaryAddress { get; set; }
        public string SecondaryAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public bool IsActive { get; set; }
    }
}
