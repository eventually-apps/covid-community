using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidCommunity.Api.Controllers;
using CovidCommunity.Api.RequestOrder;
using CovidCommunity.Api.RequestOrder.Dto;
using CovidCommunity.Api.Web.Host.Models.RequestOrder;
using Microsoft.AspNetCore.Mvc;

namespace CovidCommunity.Api.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestOrderController: ApiControllerBase
    {
        private readonly IRequestService _requestService;
        public RequestOrderController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost("createOrder")]
        public void CreateNewRequestOrder(NewRequestOrderDto requestOrder)
        {
            _requestService.CreateNewRequestOrder(requestOrder.ConvertToDto());
        }

        [HttpGet("getRequestOrder")]
        public RequestOrderDto GetRequestOrderByUser(long userId)
        {
            return _requestService.GetRequestOrdersByUser(userId);
        }

        [HttpPost("cancelRequest")]
        public void CancelRequest(int requestOrderId, int requestId)
        {
            _requestService.CancelRequest(requestOrderId, requestId);
        }
    }
}
