using Catalog.DTO;
using Catalog.Entities;
namespace Catalog{
    public static class Extensions{
        public static ItemDTO AsDTO(this Item item){
            return new ItemDTO {
                Id = item.Id,
                nameof = item.nameof,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
}