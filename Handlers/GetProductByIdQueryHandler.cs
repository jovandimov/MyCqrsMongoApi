// Handlers/GetProductByIdQueryHandler.cs
using MyCqrsMongoApi.Models;
using MyCqrsMongoApi.Queries;
using MyCqrsMongoApi.Services;

namespace MyCqrsMongoApi.Handlers
{
    public class GetProductByIdQueryHandler
    {
        private readonly IProductService _productService;

        public GetProductByIdQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Product> Handle(GetProductByIdQuery query)
        {
            return await _productService.GetByIdAsync(query.Id);
        }
    }
}
