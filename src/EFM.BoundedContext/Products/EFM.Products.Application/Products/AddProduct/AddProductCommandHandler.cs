using EFM.Products.Application.Repositories;
using EFM.Products.Domain.Products;
using EFM.Common.Application.Commands;
using EFM.Common.Domain.Abstractions;
using EFM.Common.Application.Clock;

namespace EFM.Products.Application.Products.AddProduct;
public class AddProductCommandHandler : ICommandHandler<AddProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AddProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }
    public async Task Handle(AddProductCommand command, CancellationToken cancellationToken)
    {
        //Create domain entity via factory to enforce business rules
        Product product = Product.Create(command.Name, command.Price, _dateTimeProvider.UtcNow);

        await _productRepository.AddProductAsync(product, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
