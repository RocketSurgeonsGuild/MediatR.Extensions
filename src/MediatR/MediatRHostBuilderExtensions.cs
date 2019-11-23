using System;
using JetBrains.Annotations;
using MediatR;
using Rocket.Surgery.Extensions.MediatR;

// ReSharper disable once CheckNamespace
namespace Rocket.Surgery.Conventions
{
    /// <summary>
    /// MediatRHostBuilderExtensions.
    /// </summary>
    [PublicAPI]
    public static class MediatRHostBuilderExtensions
    {
        /// <summary>
        /// Adds MediatR.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>IConventionHostBuilder.</returns>
        public static IConventionHostBuilder UseMediatR([NotNull] this IConventionHostBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Scanner.PrependConvention<MediatRConvention>();
            return builder;
        }

        /// <summary>
        /// Adds MediatR.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="serviceConfig">The MediatR service configuration.</param>
        /// <returns>IConventionHostBuilder.</returns>
        public static IConventionHostBuilder UseMediatR(
            this IConventionHostBuilder builder,
            MediatRServiceConfiguration serviceConfig
        )
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (serviceConfig is null)
            {
                throw new ArgumentNullException(nameof(serviceConfig));
            }

            builder.Set(serviceConfig);
            builder.Scanner.PrependConvention<MediatRConvention>();
            return builder;
        }
    }
}