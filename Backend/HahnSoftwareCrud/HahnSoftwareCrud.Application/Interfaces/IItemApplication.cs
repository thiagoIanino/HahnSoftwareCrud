using HahnSoftwareCrud.Application.Models;
using HahnSoftwareCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftwareCrud.Application.Interfaces
{
    public interface IItemApplication
    {
        Task<Item> GetItemById(int? id, CancellationToken cancellationToken);
        Task<Item> CreateItem(CreateItemModel item, CancellationToken cancellationToken);
        Task<Item> UpdateItem(int? id, Item item, CancellationToken cancellationToken);
        Task DeleteItem(int? id, CancellationToken cancellationToken);
    }
}
