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
        Task<Item> GetItemById(int id);
        Task<Item> CreateItem(Item item);
        Task<Item> UpdateItem(int id, Item item);
        Task DeleteItem(int id);
    }
}
