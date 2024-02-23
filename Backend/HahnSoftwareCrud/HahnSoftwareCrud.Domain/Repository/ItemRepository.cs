using HahnSoftwareCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftwareCrud.Domain.Repository
{
    public interface ItemRepository
    {
        Task<List<Item>> ListItems();
        Task<Item> GetItemById(int id);
        Task<Item> CreateItem(Item item);
        Task<Item> UpdateItem(Item item);
        Task<Item> DeleteItem(int id);
    }
}
