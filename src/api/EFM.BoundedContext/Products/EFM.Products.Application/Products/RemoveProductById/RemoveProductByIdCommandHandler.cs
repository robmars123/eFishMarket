using EFM.Common.Application.Commands;
using EFM.Products.Application.Abstractions.Repositories;
using EFM.Products.Application.Repositories;
using EFM.Products.Domain.Products;

namespace EFM.Products.Application.Products.RemoveProductById;

public class RemoveProductByIdCommandHandler : ICommandHandler<RemoveProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductUnitOfWork _unitOfWork;

    public RemoveProductByIdCommandHandler(IProductRepository productRepository, IProductUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(RemoveProductCommand command, CancellationToken cancellationToken)
    {
        Product? product = await _productRepository.GetByIdAsync(command.Id, cancellationToken);

        if (product is null)
        {
            throw new InvalidOperationException($"Product with Id '{command.Id}' not found.");
        }

        product.Remove();

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
