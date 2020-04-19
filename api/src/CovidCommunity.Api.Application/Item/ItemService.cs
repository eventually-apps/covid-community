using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Abp.Dependency;
using Abp.Domain.Repositories;
using CovidCommunity.Api.Item.Dto;
using CovidCommunity.Api.Domains;

namespace CovidCommunity.Api.Item
{
    public class ItemService: IItemService, ITransientDependency
    {
        private readonly IRepository<Domains.Item> _itemRepo;
        private readonly IRepository<InventoryByLocation> _inventoryByLocationRepo;

        public ItemService(IRepository<Domains.Item> itemRepo, IRepository<InventoryByLocation> inventoryByLocationRepo)
        {
            _itemRepo = itemRepo;
            _inventoryByLocationRepo = inventoryByLocationRepo;
        }

        public List<InventoryByLocation> GetItemsByLocation(int locationId)
        {
            return null;
        }
    }
}
