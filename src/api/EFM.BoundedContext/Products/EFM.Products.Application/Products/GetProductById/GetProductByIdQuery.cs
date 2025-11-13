using EFM.Common.Application.Queries;

namespace EFM.Products.Application.Products.GetProductById;
public class GetProductByIdQuery : IRequest<GetProductByIdResponse>
{
    public GetProductByIdQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; }
}
