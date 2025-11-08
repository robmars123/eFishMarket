using EFM.Products.Application.Repositories;
using EFM.SharedKernel.Application.Queries;
using EFM.SharedKernel.Application.Results;

namespace EFM.Products.Application.Products.GetAllProducts;
public class GetPagedProductsQueryHandler : IRequestHandler<GetPagedProductsQuery, PagedResult<GetAllProductsResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetPagedProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<PagedResult<GetAllProductsResponse>> Handle(GetPagedProductsQuery query, CancellationToken cancellationToken)
    {
        PagedResult<GetAllProductsResponse> pagedProducts = await _productRepository.GetProducts(query, cancellationToken);
        return pagedProducts;
    }
}
