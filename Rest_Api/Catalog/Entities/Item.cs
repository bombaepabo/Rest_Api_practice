using System; 
namespace Catalog.Entities
{
public class Item
{
    public Guid Id {get; init ; }
    public string nameof {get; init;}
    public decimal Price {get ; init;}
    public DateTimeOffset CreatedDate {get;init ;}
        
}
}