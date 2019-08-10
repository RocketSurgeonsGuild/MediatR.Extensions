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
        /// Adds fluent validation.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>IConventionHostBuilder.</returns>
        public static IConventionHostBuilder UseMediatR(this IConventionHostBuilder builder)
        {
            builder.Scanner.PrependConvention<MediatRConvention>();
            return builder;
        }
    }
}
