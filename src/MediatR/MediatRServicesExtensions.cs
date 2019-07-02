using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MediatR;
using Rocket.Surgery.Conventions.Reflection;
using Rocket.Surgery.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class MediatRServicesExtensions.
    /// </summary>
    public static class MediatRServicesExtensions
    {
        /// <summary>
        /// Withes the mediat r.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>IServiceConventionContext.</returns>
        public static IServiceConventionContext WithMediatR(this IServiceConventionContext builder)
        {
            DefaultServices(builder.Services, builder.AssemblyCandidateFinder);
            return builder;
        }

        private static void DefaultServices(IServiceCollection services, IAssemblyCandidateFinder assemblyCandidateFinder)
        {
            var assemblies = assemblyCandidateFinder
                .GetCandidateAssemblies(nameof(MediatR)).ToArray();

            services.AddMediatR(assemblies);
        }
    }
}
