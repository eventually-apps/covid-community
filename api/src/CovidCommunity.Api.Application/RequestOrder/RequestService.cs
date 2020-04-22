using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.UI;
using CovidCommunity.Api.Domains;
using CovidCommunity.Api.RequestOrder;
using CovidCommunity.Api.RequestOrder.Dto;

namespace CovidCommunity.Api.requestOrder
{
    public class RequestService: IRequestService, ITransientDependency
    {
        private readonly IRepository<Domains.RequestOrder> _requestOrderRepository;
        private readonly IRepository<Request> _requestRepository;

        public RequestService(IRepository<Domains.RequestOrder> requestOrderRepository, IRepository<Request> requestRepository)
        {
            _requestOrderRepository = requestOrderRepository;
            _requestRepository = requestRepository;
        }

        public List<RequestOrderDto> GetRequestOrdersByLocation(int locationId)
        {
            var requestOrders = _requestOrderRepository.GetAll().Where(x => x.OrderForLocation.Id == locationId && x.IsActive).ToList();
            var requestOrdersDto = new List<RequestOrderDto>();

            foreach (var item in requestOrders)
            {
                var requestDto = new List<RequestDto>();

                foreach (var request in item.Requests)
                {
                    requestDto.Add(new RequestDto
                    {
                        FulfilledDate = request.FulfilledDate,
                        IsActive = request.IsActive,
                        RequestedAmount = request.RequestedAmount
                    });
                }

                requestOrdersDto.Add(new RequestOrderDto
                {
                    Id = item.Id,
                    Requests = requestDto,
                    CreatedDate = item.CreatedDate,
                    FulfillmentDate = item.FulfillmentDate,
                    IsActive = item.IsActive,
                    LastModifiedDate = item.LastModifiedDate,
                    OrderRequestedByUserId = item.OrderRequestedByUserId
                });
            }

            return requestOrdersDto;
        }

        public RequestOrderDto GetRequestOrdersByUser(long userId)
        {
            var requestOrder = _requestOrderRepository.GetAll()?.FirstOrDefault(x => x.OrderRequestedByUserId == userId && x.IsActive) ?? new Domains.RequestOrder();
            var requests = _requestRepository.GetAll().Where(x => x.RequestOrderId == requestOrder.Id && x.IsActive).ToList();
            var requestDtoList = new List<RequestDto>(); 

            foreach (var item in requests)
            {
                requestDtoList.Add(new RequestDto
                {
                    FulfilledDate = item.FulfilledDate,
                    IsActive = item.IsActive,
                    RequestOrderId = item.RequestOrderId,
                    RequestedAmount = item.RequestedAmount,
                    RequestedItemId = item.RequestedItemId,
                });
            }

            return new RequestOrderDto
            {
                Id = requestOrder.Id,
                OrderRequestedByUserId = requestOrder.OrderRequestedByUserId,
                Requests = requestDtoList,
                CreatedDate = requestOrder.CreatedDate,
                OrderForLocationId = requestOrder.OrderForLocationId
            };
        }

        public void CreateNewRequestOrder(RequestOrderDto requestOrder)
        {
            if (_requestOrderRepository.GetAll().FirstOrDefault(x => x.OrderRequestedByUserId == requestOrder.OrderRequestedByUserId)?.IsActive ?? true)
            {
                var requestList = new List<Request>();

                var orderId = _requestOrderRepository.InsertAndGetId(new Domains.RequestOrder
                {
                    IsActive = requestOrder.IsActive,
                    CreatedDate = requestOrder.CreatedDate,
                    LastModifiedDate = requestOrder.LastModifiedDate,
                    OrderForLocationId = requestOrder.OrderForLocationId,
                    OrderRequestedByUserId = requestOrder.OrderRequestedByUserId
                });

                foreach (var newRequest in requestOrder.Requests.Select(item => new Request
                {
                    RequestOrderId = orderId,
                    RequestedDate = item.RequestedDate,
                    IsActive = item.IsActive,
                    RequestedItemId = item.RequestedItemId,
                    RequestedAmount = item.RequestedAmount
                }))
                {
                    requestList.Add(newRequest);
                    _requestRepository.Insert(newRequest);
                }

                var newOrder = _requestOrderRepository.GetAll().First(x => x.Id == orderId);
                newOrder.Requests = requestList;
                _requestOrderRepository.Update(newOrder);
            }
            else
            {
                throw new UserFriendlyException("An active Request order already exists for this user. Cannot create a new one until the current one has been completed.");
            }
        }

        public void CreateRequest(int requestOrderId, RequestDto request)
        {
            _requestRepository.Insert(new Request
            {
                RequestOrderId = requestOrderId,
                RequestedDate = request.RequestedDate,
                RequestedAmount = request.RequestedAmount,
                RequestedItemId = request.RequestedItemId,
                IsActive = request.IsActive
            });
        }

        public void CancelRequest(int requestOrderId, int requestId)
        {
            var requestToCancel = _requestRepository.GetAll().First(x => x.RequestOrderId == requestOrderId && x.Id == requestId);

            requestToCancel.IsActive = false;
            _requestRepository.Update(requestToCancel);
        }

        public void FulfillRequest(int requestOrderId, int requestId)
        {
            var request = _requestRepository.GetAll().First(x => x.Id == requestId && x.RequestOrderId == requestOrderId);
            request.FulfilledDate = DateTime.Now;
            request.IsActive = false;
            _requestRepository.Update(request);
        }

        public void CompleteRequestOrder(int requestOrderId)
        {
            var requestOrder = _requestOrderRepository.FirstOrDefault(x => x.Id == requestOrderId && x.IsActive);
            requestOrder.FulfillmentDate = DateTime.Now;
            requestOrder.IsActive = false;

            _requestOrderRepository.Update(requestOrder);
        }
    }
}
