using System.Threading;
using System.Threading.Tasks;
using Marten;
using MediatR;

namespace Rocket.Surgery.Core.MediatR.Pipeline
{
    public class MartenPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IDocumentSession _documentSession;

        public MartenPipelineBehavior(IDocumentSession documentSession = null)
        {
            _documentSession = documentSession;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();
            if (_documentSession != null)
                await _documentSession.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}