using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Dependency;
using Abp.Domain.Repositories;
using CovidCommunity.Api.Item.Dto;

namespace CovidCommunity.Api.Item
{
    public class ItemService: IItemService, ITransientDependency
    {
        private readonly IRepository<Domains.Item> _itemRepo;

        public ItemService(IRepository<Domains.Item> itemRepo)
        {
            _itemRepo = itemRepo;
        }

        public List<ItemDto> GetAllItems()
        {
            return null;
        }
    }
}
