using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rocket.Surgery.Extensions.MediatR;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Extensions.DependencyInjection;

[assembly: Convention(typeof(MediatRConvention))]

namespace Rocket.Surgery.Extensions.MediatR
{
    /// <summary>
    ///  MediatRConvention.
    /// Implements the <see cref="IServiceConvention" />
    /// </summary>
    /// <seealso cref="IServiceConvention" />
    public class MediatRConvention : IServiceConvention
    {
        /// <summary>
        /// Registers the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void Register(IServiceConventionContext context)
        {
            var serviceConfig = context.GetOrAdd(() => new MediatRServiceConfiguration());
            context.UseMediatR(serviceConfig);
        }
    }
}
