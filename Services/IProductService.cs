// Services/IProductService.cs
using MyCqrsMongoApi.Models;
using System.Threading.Tasks;

namespace MyCqrsMongoApi.Services
{
    public interface IProductService
    {
        Task CreateAsync(Product product);
        Task<Product> GetByIdAsync(string id);
    }
}
