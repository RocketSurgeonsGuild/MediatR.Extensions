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
    public static class MediatRServicesExtensions
    {
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
