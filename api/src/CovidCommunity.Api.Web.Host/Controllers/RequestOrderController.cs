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

        [HttpPost("createRequest")]
        public void CreateNewRequest(int requestOrderId, NewRequestDto newRequest)
        {
            _requestService.CreateRequest(requestOrderId, newRequest.ConvertToDto());
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

        [HttpPost("fulfillRequest")]
        public void FulfillRequest(int requestOrderId, int requestId)
        {
            _requestService.FulfillRequest(requestOrderId, requestId);
        }
    }
}
