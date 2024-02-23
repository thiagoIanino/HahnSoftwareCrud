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
        private readonly IItemRepository _itemRepository;
        public ItemController(IItemApplication itemApplication, IItemRepository itemRepository)
        {
            _itemApplication = itemApplication; 
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ListItems(CancellationToken cancellationToken)
        {
            var items = await _itemRepository.ListItems(cancellationToken);

            return Ok(items);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetItemById(int id, CancellationToken cancellationToken)
        {
            var item = await _itemApplication.GetItemById(id, cancellationToken);

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] Item item, CancellationToken cancellationToken)
        {
            var createdItem = await _itemApplication.CreateItem(item, cancellationToken);

            return Created($"{Constants.ResponseUri} + {createdItem.Id}", createdItem);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateItem(int id,[FromBody] Item item, CancellationToken cancellationToken)
        {
            var createdItem = await _itemApplication.UpdateItem(id, item, cancellationToken);

            return Ok(createdItem);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteItem(int id, CancellationToken cancellationToken)
        {
            await _itemApplication.DeleteItem(id, cancellationToken);

            return NoContent();
        }
    }
}
