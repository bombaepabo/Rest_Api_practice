using System ;
namespace Catalog.DTO{
    public record ItemDTO
{
    public Guid Id {get; init ; }
    public string nameof {get; init;}
    public decimal Price {get ; init;}
    public DateTimeOffset CreatedDate {get;set ;}
        
}
}