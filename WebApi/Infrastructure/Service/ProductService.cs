using Application.Service;
using Infrastructure.Service;

namespace DependencyInjection.Service;

public class ProductService : IProductService
{
    public ProductService()
    {
        
    }
    public void Save()
    {
        //Entity Framework ile save işlemi yapayım.
    }
}
