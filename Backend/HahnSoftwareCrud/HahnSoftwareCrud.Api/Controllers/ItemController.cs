using HahnSoftwareCrud.Application.Interfaces;
using HahnSoftwareCrud.Domain.Constants;
using HahnSoftwareCrud.Domain.Entities;
using HahnSoftwareCrud.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HahnSoftwareCrud.Api.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemApplication _itemApplication;
        private readonly ItemRepository _itemRepository;
        public ItemController(IItemApplication itemApplication, ItemRepository itemRepository)
        {
            _itemApplication = itemApplication; 
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ListItems()
        {
            var items = await _itemRepository.ListItems();

            return Ok(items);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var item = await _itemApplication.GetItemById(id);

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] Item item)
        {
            var createdItem = await _itemApplication.CreateItem(item);

            return Created($"{Constants.ResponseUri} + {createdItem.Id}", createdItem);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateItem(int id,[FromBody] Item item)
        {
            var createdItem = await _itemApplication.UpdateItem(id,item);

            return Ok(createdItem);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _itemApplication.DeleteItem(id);

            return NoContent();
        }
    }
}
