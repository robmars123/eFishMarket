using EFM.Common.Application.Commands;

namespace EFM.Products.Application.Products.RemoveProductById;

public class RemoveProductCommand : ICommand
{
    public Guid Id { get; set; }

    public RemoveProductCommand(Guid id)
    {
        Id = id;
    }
}
