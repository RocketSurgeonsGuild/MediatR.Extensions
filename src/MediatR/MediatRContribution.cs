using Microsoft.Extensions.DependencyInjection;
using Rocket.Surgery.Extensions.MediatR;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Extensions.DependencyInjection;

[assembly: Convention(typeof(MediatRConvention))]

namespace Rocket.Surgery.Extensions.MediatR
{
    public class MediatRConvention : IServiceConvention
    {
        public void Register(IServiceConventionContext context)
        {
            context.WithMediatR();
        }
    }
}
