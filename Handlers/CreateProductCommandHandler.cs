// Handlers/CreateProductCommandHandler.cs
using MyCqrsMongoApi.Commands;
using MyCqrsMongoApi.Models;
using MyCqrsMongoApi.Services;

namespace MyCqrsMongoApi.Handlers
{
    public class CreateProductCommandHandler
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Handle(CreateProductCommand command)
        {
            var product = new Product
            {
                Name = command.Name,
                Price = command.Price
            };
            
            await _productService.CreateAsync(product);
        }
    }
}