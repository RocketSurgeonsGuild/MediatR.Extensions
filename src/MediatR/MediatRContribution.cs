using Microsoft.Extensions.DependencyInjection;
using Rocket.Surgery.Extensions.MediatR;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Extensions.DependencyInjection;

[assembly: Convention(typeof(MediatRConvention))]

namespace Rocket.Surgery.Extensions.MediatR
{
    /// <summary>
    /// Class MediatRConvention.
    /// Implements the <see cref="Rocket.Surgery.Extensions.DependencyInjection.IServiceConvention" />
    /// </summary>
    /// <seealso cref="Rocket.Surgery.Extensions.DependencyInjection.IServiceConvention" />
    public class MediatRConvention : IServiceConvention
    {
        /// <summary>
        /// Registers the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void Register(IServiceConventionContext context)
        {
            context.WithMediatR();
        }
    }
}
