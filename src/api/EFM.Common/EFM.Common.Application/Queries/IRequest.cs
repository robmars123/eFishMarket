namespace EFM.Common.Application.Queries;

/// <summary>
/// Represents a request that produces a response of type <typeparamref name="TResponse"/>.
/// </summary>
/// <remarks>This interface is typically used to define a request-response pattern, where the request encapsulates
/// the data or parameters required to produce a response of the specified type.</remarks>
/// <typeparam name="TResponse">The type of the response produced by the request.</typeparam>
public interface IRequest<TResponse>
{
}
