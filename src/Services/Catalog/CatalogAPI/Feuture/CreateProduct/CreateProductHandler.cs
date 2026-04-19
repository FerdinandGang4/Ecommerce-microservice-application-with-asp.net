namespace CatalogAPI.Feuture.CreateProduct
{
    public record CreateProductCommand(string Name, List<string>Category, string Description, string ImageFile, decimal Price)
        :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    public class CreateProductHandler (IDocumentSession session): ICommandHandler<CreateProductCommand, CreateProductResult>
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

            //save to database // this is using the Marten library which transforms the PostgreSQL database to document database
           // session.Store(product);
          //  session.SaveChangesAsync(cancellationToken);

            //return created results
            return new CreateProductResult(product.Id);
        }
    }
}
