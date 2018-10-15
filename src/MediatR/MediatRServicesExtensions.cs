using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
#if NETSTANDARD1_3 || NET451
using Autofac;
#endif
using MediatR;
using Rocket.Surgery.Extensions.MediatR.Builders;
using Rocket.Surgery.Conventions.Reflection;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class MediatRServicesExtensions
    {
        public static MediatRServicesBuilder WithMediatR(this Rocket.Surgery.Extensions.DependencyInjection.IServiceConventionContext builder)
        {
            DefaultServices(builder.Services, builder.AssemblyCandidateFinder);
            return new MediatRServicesBuilder(builder);
        }

        private static void DefaultServices(IServiceCollection services, IAssemblyCandidateFinder assemblyCandidateFinder)
        {
            var assemblies = assemblyCandidateFinder
                .GetCandidateAssemblies(nameof(MediatR)).ToArray();

            services.AddMediatR(assemblies);
        }
    }
}
