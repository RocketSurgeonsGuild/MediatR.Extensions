using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MediatR;
using MediatR.Registration;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Conventions.Reflection;
using Rocket.Surgery.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    ///  MediatRServicesExtensions.
    /// </summary>
    public static class MediatRServicesExtensions
    {
        /// <summary>
        /// Uses MediatR.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>IServiceConventionContext.</returns>
        public static IServiceConventionContext UseMediatR(this IServiceConventionContext builder)
        {
            var serviceConfig = builder.Get<MediatRServiceConfiguration>() ?? new MediatRServiceConfiguration();
            builder.Set(serviceConfig);
            return UseMediatR(builder, serviceConfig);
        }

        /// <summary>
        /// Uses MediatR.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="serviceConfig">The MediatR service configuration.</param>
        /// <returns>IServiceConventionContext.</returns>
        public static IServiceConventionContext UseMediatR(this IServiceConventionContext builder, MediatRServiceConfiguration serviceConfig)
        {
            builder.Set(serviceConfig);
            var assemblies = builder.AssemblyCandidateFinder
                .GetCandidateAssemblies(nameof(MediatR)).ToArray();

            ServiceRegistrar.AddRequiredServices(builder.Services, serviceConfig);
            ServiceRegistrar.AddMediatRClasses(builder.Services, assemblies);
            return builder;
        }
    }
}
