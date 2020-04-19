using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CovidCommunity.Api.RequestOrder.Dto;

namespace CovidCommunity.Api.Web.Host.Models.RequestOrder
{
    public class NewRequestOrderDto
    {
        [Required]
        public long OrderRequestedByUserId { get; set; }
        [Required]
        public int OrderForLocationId { get; set; }
        [Required]
        public List<NewRequestDto> Requests { get; set; }

        public RequestOrderDto ConvertToDto()
        {
            var newRequestDto = new List<RequestDto>();

            foreach (var item in Requests)
            {
                newRequestDto.Add(item.ConvertToDto());
            }

            return new RequestOrderDto
            {
                OrderForLocationId = OrderForLocationId,
                OrderRequestedByUserId = OrderRequestedByUserId,
                Requests = newRequestDto,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                IsActive = true
            };
        }
    }
}
