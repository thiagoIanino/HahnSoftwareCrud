using HahnSoftwareCrud.Application.Interfaces;
using HahnSoftwareCrud.Application.Validators;
using HahnSoftwareCrud.Domain.Constants;
using HahnSoftwareCrud.Domain.Entities;
using HahnSoftwareCrud.Domain.Exceptions;
using HahnSoftwareCrud.Domain.Repository;

namespace HahnSoftwareCrud.Application
{
    public class ItemApplication : IItemApplication
    {
        private readonly ItemRepository _itemRepository;
        public ItemApplication(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> CreateItem(Item item)
        {
            ValidateItemInput(item);

            await _itemRepository.CreateItem(item);

            return item;
        }

        public async Task<Item> UpdateItem(int id, Item item)
        {
            ValidateItemInput(item);
            ValidateItemIdInput(id);

            await _itemRepository.UpdateItem(item);

            return item;
        }

        public async Task DeleteItem(int id)
        {
            ValidateItemIdInput(id);

            await _itemRepository.DeleteItem(id);
        }

        public async Task<Item> GetItemById(int id)
        {
            ValidateItemIdInput(id);

           return await _itemRepository.GetItemById(id);
        }

        private void ValidateItemInput(Item item)
        {
            var itemValidator = new ItemValidator();
            var validatorResult = itemValidator.Validate(item);

            if (!validatorResult.IsValid)
                throw new BadRequestException(validatorResult?.Errors?.FirstOrDefault()?.ErrorMessage);
        }

        private void ValidateItemIdInput(int? id)
        {
            if (id is null)
                throw new BadRequestException(Constants.RequiredIdMessageError);
        }
    }
}
