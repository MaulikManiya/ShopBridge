using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.API.Infrastructure.Errors;
using ShopBridge.API.Infrastructure.Filters;
using ShopBridge.Data.IRepository;
using ShopBridge.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.API.Controllers
{
    [Route("api/item")]
    [ValidateModel]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        // GET: api/item
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _itemRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralErrorResultModel(ErrorCodes.GetAllItemError, ex.Message));
            }
        }

        // POST: api/item
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item item)
        {
            try
            {
                await _itemRepository.Add(item);
                return Ok("Record inserted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralErrorResultModel(ErrorCodes.CreatingItemError, ex.Message));
            }
        }

        // PUT: api/item/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Item item)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound(new GeneralErrorResultModel(ErrorCodes.UpdatingItemError, "Please enter valid Id."));
                }
                item.Id = id;
                await _itemRepository.Update(item);
                return Ok("Record updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralErrorResultModel(ErrorCodes.UpdatingItemError, ex.Message));
            }
        }

        // DELETE: api/item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                Item employee = await _itemRepository.GetById(id);
                if (employee == null)
                {
                    return NotFound(new GeneralErrorResultModel(ErrorCodes.DeletingItemError, "The Item record couldn't be found."));
                }
                await _itemRepository.Delete(employee);
                return Ok("Record deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralErrorResultModel(ErrorCodes.DeletingItemError, ex.Message));
            }
        }
    }
}
