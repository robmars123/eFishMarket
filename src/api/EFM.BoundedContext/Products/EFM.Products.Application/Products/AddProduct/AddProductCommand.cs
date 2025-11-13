using EFM.Common.Application.Commands;

namespace EFM.Products.Application.Products.AddProduct;
public class AddProductCommand : ICommand
{
    public string Name { get; }
    public decimal Price { get; }

    public AddProductCommand(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}
