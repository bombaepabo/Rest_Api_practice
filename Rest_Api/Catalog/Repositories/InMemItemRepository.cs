using System.Collections.Generic;
using System.Linq ; 
using Catalog.Entities;

namespace Catalog.Repositories 
{
    public class InMemItemRepository{
        private readonly List<Item> items = new(){
            new Item {Id = Guid.NewGuid(), nameof = "Potion",Price = 9 ,CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), nameof = "Iron Sword ",Price = 20 ,CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), nameof = "Bronze Shield",Price = 18 ,CreatedDate = DateTimeOffset.UtcNow},


        };
        public IEnumerable<Item> GetItems(){
            return items ;
        }
          public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id ).SingleOrDefault();
        }
    }
}