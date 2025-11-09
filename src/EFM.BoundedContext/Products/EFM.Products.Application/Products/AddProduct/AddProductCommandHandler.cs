using EFM.Products.Application.Repositories;
using EFM.Products.Domain.Products;
using EFM.Common.Application.Commands;
using EFM.Common.Domain.Abstractions;

namespace EFM.Products.Application.Products.AddProduct;
public class AddProductCommandHandler : ICommandHandler<AddProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(AddProductCommand command, CancellationToken cancellationToken)
    {
        //Create domain entity via factory to enforce business rules
        Product product = Product.Create(command.Name, command.Price, DateTime.UtcNow);

        await _productRepository.AddProductAsync(product, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
