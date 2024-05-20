// Services/ProductService.cs
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyCqrsMongoApi.Models;
using MyCqrsMongoApi.Settings;

namespace MyCqrsMongoApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _products;

        public ProductService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _products = database.GetCollection<Product>("Products");
        }

        public async Task CreateAsync(Product product)
        {
            await _products.InsertOneAsync(product);
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }
    }
}
