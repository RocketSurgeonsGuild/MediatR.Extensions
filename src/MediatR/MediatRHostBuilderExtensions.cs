using MediatR;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Extensions.MediatR;

// ReSharper disable once CheckNamespace
namespace Rocket.Surgery.Conventions
{
    /// <summary>
    /// MediatRHostBuilderExtensions.
    /// </summary>
    public static class MediatRHostBuilderExtensions
    {
        /// <summary>
        /// Adds MediatR.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>IConventionHostBuilder.</returns>
        public static IConventionHostBuilder UseMediatR(this IConventionHostBuilder builder)
        {
            builder.Scanner.PrependConvention<MediatRConvention>();
            return builder;
        }

        /// <summary>
        /// Adds MediatR.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="serviceConfig">The MediatR service configuration.</param>
        /// <returns>IConventionHostBuilder.</returns>
        public static IConventionHostBuilder UseMediatR(this IConventionHostBuilder builder, MediatRServiceConfiguration serviceConfig)
        {
            builder.Set(serviceConfig);
            builder.Scanner.PrependConvention<MediatRConvention>();
            return builder;
        }
    }
}
