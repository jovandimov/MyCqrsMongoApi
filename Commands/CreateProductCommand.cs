// Commands/CreateProductCommand.cs
namespace MyCqrsMongoApi.Commands
{
    public class CreateProductCommand
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
