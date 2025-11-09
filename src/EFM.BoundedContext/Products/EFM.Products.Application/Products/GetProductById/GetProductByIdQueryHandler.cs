using EFM.Products.Application.Repositories;
using EFM.Common.Application.Queries;

namespace EFM.Products.Application.Products.GetProductById;
public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdResponse>
{
    private readonly IReadOnlyProductRepository _productRepository;

    public GetProductByIdQueryHandler(IReadOnlyProductRepository productRepository)
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
