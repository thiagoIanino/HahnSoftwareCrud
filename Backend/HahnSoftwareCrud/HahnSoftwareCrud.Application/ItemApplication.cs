using HahnSoftwareCrud.Application.Interfaces;
using HahnSoftwareCrud.Application.Models;
using HahnSoftwareCrud.Application.Validators;
using HahnSoftwareCrud.Domain.Constants;
using HahnSoftwareCrud.Domain.Entities;
using HahnSoftwareCrud.Domain.Exceptions;
using HahnSoftwareCrud.Domain.Repository;

namespace HahnSoftwareCrud.Application
{
    public class ItemApplication : IItemApplication
    {
        private readonly IItemRepository _itemRepository;
        public ItemApplication(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> CreateItem(CreateItemModel itemInput, CancellationToken cancellationToken)
        {
            var item = new Item 
            { 
                Name = itemInput.Name,
                Quantity = itemInput.Quantity 
            };

            ValidateItemInput(item);

            await _itemRepository.CreateItem(item, cancellationToken);

            return item;
        }

        public async Task<Item> UpdateItem(int id, Item item, CancellationToken cancellationToken)
        {
            ValidateItemInput(item);
            ValidateItemIdInput(id);

            await _itemRepository.UpdateItem(item, cancellationToken);

            return item;
        }

        public async Task DeleteItem(int id, CancellationToken cancellationToken)
        {
            ValidateItemIdInput(id);

            await _itemRepository.DeleteItem(id, cancellationToken);
        }

        public async Task<Item> GetItemById(int id, CancellationToken cancellationToken)
        {
            ValidateItemIdInput(id);

           var item = await _itemRepository.GetItemById(id, cancellationToken);

            if (item == null)
                throw new NotFoundExeption(Constants.ItemNotFound);

            return item;
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
