using Microsoft.Extensions.DependencyInjection;
using Rocket.Surgery.Core.MediatR;
using Rocket.Surgery.Conventions;

[assembly: Convention(typeof(MediatRConvention))]

namespace Rocket.Surgery.Core.MediatR
{
#if NETSTANDARD1_3 || NET451
    public class MediatRConvention : Rocket.Surgery.Extensions.Autofac.IAutofacConvention
    {
        public void Register(Rocket.Surgery.Extensions.Autofac.IAutofacConventionContext context)
        {
            context.WithMediatR();
        }
    }
#else
    public class MediatRConvention : Rocket.Surgery.Extensions.DependencyInjection.IServiceConvention
    {
        public void Register(Rocket.Surgery.Extensions.DependencyInjection.IServiceConventionContext context)
        {
            context.WithMediatR();
        }
    }
#endif
}
