using EFM.Common.Application.Clock;
using EFM.Common.Application.Commands;
using EFM.Common.Domain.Abstractions;
using EFM.Inventory.PublicApi;
using EFM.Products.Application.Abstractions.Repositories;
using EFM.Products.Application.Repositories;
using EFM.Products.Domain.Products;
using Microsoft.Extensions.Logging;

namespace EFM.Products.Application.Products.AddProduct;
public class AddProductCommandHandler : ICommandHandler<AddProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IInventoryApi _inventoryApi;
    private readonly IProductUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly ILogger<AddProductCommandHandler> _logger;

    public AddProductCommandHandler(IProductRepository productRepository,
        IInventoryApi inventoryApi,
        IProductUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider,
        ILogger<AddProductCommandHandler> logger)
    {
        _productRepository = productRepository;
        _inventoryApi = inventoryApi;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
        _logger = logger;
    }
    public async Task Handle(AddProductCommand command, CancellationToken cancellationToken)
    {
        //Create domain entity via factory to enforce business rules
        Product product = Product.Create(command.Name, command.Price, _dateTimeProvider.UtcNow);

        await _productRepository.AddProductAsync(product, cancellationToken);
        //_logger.LogInformation("Product {ProductId} persisted to repository", product.Id);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        //_logger.LogInformation("UnitOfWork committed for Product {ProductId}", product.Id);

        await _inventoryApi.AddInventoryItem(product.Id, cancellationToken);
        //_logger.LogInformation("Inventory item created for Product {ProductId}", product.Id);
    }
}
