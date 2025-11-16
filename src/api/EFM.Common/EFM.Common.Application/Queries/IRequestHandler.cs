namespace EFM.Common.Application.Queries;

/// <summary>
/// Defines a contract for handling requests of type <typeparamref name="TRequest"/> and producing a response of type
/// <typeparamref name="TResponse"/>.
/// </summary>
/// <remarks>This interface is typically implemented by classes that encapsulate the logic for processing specific
/// types of requests. It is commonly used in mediator patterns to decouple request senders from their
/// handlers.</remarks>
/// <typeparam name="TRequest">The type of the request to be handled. Must implement <see cref="IRequest{TResponse}"/>.</typeparam>
/// <typeparam name="TResponse">The type of the response produced by handling the request.</typeparam>
public interface IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}
