using HahnSoftwareCrud.Application;
using HahnSoftwareCrud.Application.Models;
using HahnSoftwareCrud.Domain.Entities;
using HahnSoftwareCrud.Domain.Exceptions;
using HahnSoftwareCrud.Domain.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftwareCrud.Tests.Application
{
    public class ItemApplicationTest
    {
        private readonly ItemApplication _itemApplication;
        private readonly Mock<IItemRepository> _ItemRepository;
        private readonly CancellationToken _cancellationToken;
        public ItemApplicationTest()
        {
            _ItemRepository = new Mock<IItemRepository>();
            _itemApplication = new ItemApplication(_ItemRepository.Object);
            _cancellationToken = new CancellationToken();
        }


        [Fact]
        public async Task CreateItem_Ok_Test()
        {
            var item = new CreateItemModel { Name = "Item Nº1", Quantity = 20 };
            _ItemRepository.Setup(x => x.CreateItem(It.IsAny<Item>(), It.IsAny<CancellationToken>())).ReturnsAsync(1);
            var createdItem = await _itemApplication.CreateItem(item, _cancellationToken);

            Assert.Equal(1, createdItem.Id);
        }

        [Fact]
        public async Task CreateItem_BigQuantity_BadRequest_Test()
        {
            var item = new CreateItemModel { Name = "Item Nº1", Quantity = 300 };
            await Assert.ThrowsAsync<BadRequestException> ( async () => await _itemApplication.CreateItem(item, _cancellationToken));
        }

        [Fact]
        public async Task CreateItem_SmallName_BadRequest_Test()
        {
            var item = new CreateItemModel { Name = "AD", Quantity = 20 };
            await Assert.ThrowsAsync<BadRequestException>(async () => await _itemApplication.CreateItem(item, _cancellationToken));
        }

        [Fact]
        public async Task CreateItem_BigName_BadRequest_Test()
        {
            var item = new CreateItemModel { Name = "My product with a big name - Thisproduct is really nice", Quantity = 20 };
            await Assert.ThrowsAsync<BadRequestException>(async () => await _itemApplication.CreateItem(item, _cancellationToken));
        }

        [Fact]
        public async Task UpdateItem_Ok_Test()
        {
            var item = new Item { Id = 2, Name = "Item Nº1", Quantity = 20 };
            var updatedItem = await _itemApplication.UpdateItem(item.Id,item, _cancellationToken);

            Assert.Equal(2, updatedItem.Id);
        }

        [Fact]
        public async Task UpdateItem_BigQuantity_BadRequest_Test()
        {
            var item = new Item { Id = 2, Name = "Item Nº1", Quantity = 300 };
            await Assert.ThrowsAsync<BadRequestException>(async () => await _itemApplication.UpdateItem(item.Id, item, _cancellationToken));
        }

        [Fact]
        public async Task UpdateItem_SmallName_BadRequest_Test()
        {
            var item = new Item { Id = 2, Name = "My product with a big name - Thisproduct is really nice", Quantity = 20 };
            await Assert.ThrowsAsync<BadRequestException>(async () => await _itemApplication.UpdateItem(item.Id, item, _cancellationToken));
        }

        [Fact]
        public async Task UpdateItem_MissingId_BadRequest_Test()
        {
            var item = new Item { Id = null, Name = "My product", Quantity = 20 };
            await Assert.ThrowsAsync<BadRequestException>(async () => await _itemApplication.UpdateItem(item.Id, item, _cancellationToken));
        }

        [Fact]
        public async Task DeleteItem_Ok_Test()
        {
            var id = 2;
            await _itemApplication.DeleteItem(id, _cancellationToken);

            _ItemRepository.Verify(x => x.DeleteItem(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DelteItem_MissingId_BadRequest_Test()
        {
            await Assert.ThrowsAsync<BadRequestException>(async () => await _itemApplication.DeleteItem(null, _cancellationToken));
        }

        [Fact]
        public async Task GetItemById_Ok_Test()
        {
            var id = 2;
            _ItemRepository.Setup(x => x.GetItemById(It.IsAny<int?>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Item { Id = 3, Name = "Item num 3", Quantity = 80});
            var itemResult = await _itemApplication.GetItemById(id, _cancellationToken);

            Assert.Equal(3, itemResult.Id);
            Assert.Equal(80, itemResult.Quantity);
            Assert.Equal("Item num 3", itemResult.Name);
        }

        [Fact]
        public async Task GetItemById_MissingId_BadRequest_Test()
        {
            await Assert.ThrowsAsync<BadRequestException>(async () => await _itemApplication.GetItemById(null, _cancellationToken));
        }

        [Fact]
        public async Task GetItemById_NotFound_Test()
        {
            _ItemRepository.Setup(x => x.GetItemById(It.IsAny<int?>(), It.IsAny<CancellationToken>())).ReturnsAsync((Item?)default);
            await Assert.ThrowsAsync<NotFoundExeption>(async () => await _itemApplication.GetItemById(2, _cancellationToken));
        }

    }
}
