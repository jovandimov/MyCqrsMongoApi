// Controllers/ProductController.cs
using Microsoft.AspNetCore.Mvc;
using MyCqrsMongoApi.Commands;
using MyCqrsMongoApi.Handlers;
using MyCqrsMongoApi.Queries;

namespace MyCqrsMongoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;

        public ProductController(
            CreateProductCommandHandler createProductCommandHandler,
            GetProductByIdQueryHandler getProductByIdQueryHandler)
        {
            _createProductCommandHandler = createProductCommandHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            await _createProductCommandHandler.Handle(command);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var product = await _getProductByIdQueryHandler.Handle(new GetProductByIdQuery { Id = id });
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
