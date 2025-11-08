using EFM.Products.Application.Repositories;
using EFM.SharedKernel.Application.Queries;
using EFM.SharedKernel.Application.Results;

namespace EFM.Products.Application.Products.GetAllProducts;
public class GetPagedProductsQueryHandler : IRequestHandler<GetPagedProductsQuery, PagedResult<GetPagedProductsResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetPagedProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<PagedResult<GetPagedProductsResponse>> Handle(GetPagedProductsQuery query, CancellationToken cancellationToken)
    {
        PagedResult<GetPagedProductsResponse> pagedProducts = await _productRepository.GetProducts(query, cancellationToken);
        return pagedProducts;
    }
}
