using System.Collections.Generic;
using Abp.Application.Services;
using CovidCommunity.Api.Domains;
using CovidCommunity.Api.Item.Dto;
using CovidCommunity.Api.RequestOrder.Dto;

namespace CovidCommunity.Api.RequestOrder
{
    public interface IRequestService 
    {
        List<RequestOrderDto> GetRequestOrdersByLocation(int locationId);
        RequestOrderDto GetRequestOrdersByUser(long userId);
        void CreateNewRequestOrder(RequestOrderDto requestOrder);
        void CreateRequest(int requestOrderId ,RequestDto request);
        void CancelRequest(int requestOrderId, int requestId);
        void FulfillRequest(int requestOrderId, int requestId);
    }
}
