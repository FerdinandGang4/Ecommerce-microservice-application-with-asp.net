using BuildingBlocks.CQRS;
using CatalogAPI.Model;
using MediatR;

namespace CatalogAPI.Feuture.CreateProduct
{
    public record CreateProductCommand(string Name, List<string>Category, string Description, string ImageFile, decimal Price)
        :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    public class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //create product entity
            var product = new Product
            {
               Name = command.Name,
               Category = command.Category,
               Description = command.Description,
               ImageFile = command.ImageFile,
               Price = command.Price
            };

            //save to database

            //return created results
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
