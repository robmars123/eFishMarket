using EFM.Products.Application.Repositories;
using EFM.Common.Application.Queries;
using EFM.Common.Application.Results;

namespace EFM.Products.Application.Products.GetPagedProducts;
public class GetPagedProductsQueryHandler : IRequestHandler<GetPagedProductsQuery, PagedResponse<GetPagedProductsResponse>>
{
    private readonly IReadOnlyProductRepository _productRepository;

    public GetPagedProductsQueryHandler(IReadOnlyProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<PagedResponse<GetPagedProductsResponse>> Handle(GetPagedProductsQuery query, CancellationToken cancellationToken)
    {
        //todo: add logging & caching if needed
        PagedResponse<GetPagedProductsResponse> pagedProducts = await _productRepository.GetProducts(query, cancellationToken);
        return pagedProducts;
    }
}
