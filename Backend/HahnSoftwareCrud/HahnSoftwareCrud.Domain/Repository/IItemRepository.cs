using HahnSoftwareCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftwareCrud.Domain.Repository
{
    public interface IItemRepository
    {
        Task<List<Item>> ListItems(CancellationToken cancellationToken);
        Task<Item?> GetItemById(int id, CancellationToken cancellationToken);
        Task<int> CreateItem(Item item, CancellationToken cancellationToken);
        Task UpdateItem(Item item, CancellationToken cancellationToken);
        Task DeleteItem(int id, CancellationToken cancellationToken);
    }
}
