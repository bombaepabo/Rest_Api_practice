using Microsoft.AspNetCore.Mvc ;
using Catalog.Repositories ; 
using Catalog.Entities;
using Catalog.DTO;
using System.Linq ; 

namespace Catalog.Controllers
{

    [ApiController]
    [Route("items")]
    public class ItemsController: ControllerBase{
        private readonly IItemRepository repository ;
        public ItemsController(IItemRepository repository){
            this.repository = repository ;
            
        }
        [HttpGet]
        public IEnumerable<ItemDTO> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDTO());
            return items; 
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDTO> GetItem(Guid id){
            var item = repository.GetItem(id);
            if(item is null){
                return NotFound();
            }
            return item.AsDTO();
        }
        [HttpPost]
        public ActionResult<ItemDTO> CreatedItem(CreateItemDTO itemDTO)
        {
            Item item = new(){
                Id = Guid.NewGuid(),
                nameof = itemDTO.nameof,
                Price = itemDTO.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem),new {id = item.Id},item.AsDTO());
        }
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id,UpdateItemDTO itemDTO)
        {
            var existingItem = repository.GetItem(id);
            if(existingItem is null)
            {
                return NotFound();
            }
            Item  UpdateItem = existingItem with {
                nameof = itemDTO.nameof,
                Price = itemDTO.Price
            };
            repository.UpdateItem(UpdateItem);
            return NoContent();
        }
        [HttpDelete]
        public ActionResult DeleteItem(Guid id){
             var existingItem = repository.GetItem(id);
            if(existingItem is null)
            {
                return NotFound();
            }
            repository.DeleteItem(id);
            return NoContent();
        }

    }
}