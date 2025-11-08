using EFM.Products.Application.Repositories;
using EFM.SharedKernel.Application.Queries;

namespace EFM.Products.Application.Products.GetProductById;
public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdResponse>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public Task<GetProductByIdResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        //todo: add logging & caching if needed
        Task<GetProductByIdResponse> response = _productRepository.GetProductByIdAsync(request.Id, cancellationToken);
        return response;
    }
}
