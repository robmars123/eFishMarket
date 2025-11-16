using EFM.Products.Application.Repositories;
using EFM.Products.Domain.Products;
using EFM.Common.Application.Commands;
using EFM.Common.Domain.Abstractions;
using EFM.Products.Application.Abstractions.Repositories;

namespace EFM.Products.Application.Products.UpdateProduct;
public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IProductRepository productRepository, IProductUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        Product? product =  await _productRepository.GetByIdAsync(command.Id, cancellationToken);

        if (product is null)
        {
            throw new InvalidOperationException($"Product with Id '{command.Id}' not found.");
        }

        product.UpdateProduct(command.Name, command.Price, command.IsDeleted);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
