using EFM.Products.Application.Repositories;
using EFM.SharedKernel.Application.Queries;
using EFM.SharedKernel.Application.Results;

namespace EFM.Products.Application.Products.GetPagedProducts;
public class GetPagedProductsQueryHandler : IRequestHandler<GetPagedProductsQuery, PagedResult<GetPagedProductsResponse>>
{
    private readonly IReadOnlyProductRepository _productRepository;

    public GetPagedProductsQueryHandler(IReadOnlyProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<PagedResult<GetPagedProductsResponse>> Handle(GetPagedProductsQuery query, CancellationToken cancellationToken)
    {
        //todo: add logging & caching if needed
        PagedResult<GetPagedProductsResponse> pagedProducts = await _productRepository.GetProducts(query, cancellationToken);
        return pagedProducts;
    }
}
