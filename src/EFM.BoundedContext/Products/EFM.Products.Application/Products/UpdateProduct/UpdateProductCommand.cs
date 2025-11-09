using EFM.SharedKernel.Application.Commands;

namespace EFM.Products.Application.Products.UpdateProduct;
public class UpdateProductCommand : ICommand
{
    public Guid Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public bool IsDeleted { get; }

    public UpdateProductCommand(Guid id, string name, decimal price, bool isDeleted)
    {
        Id = id;
        Name = name;
        Price = price;
        IsDeleted = isDeleted;
    }
}
