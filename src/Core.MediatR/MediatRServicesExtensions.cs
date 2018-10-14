using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
#if NETSTANDARD1_3 || NET451
using Autofac;
#endif
using MediatR;
using Rocket.Surgery.Core.MediatR.Builders;
using Rocket.Surgery.Conventions.Reflection;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class MediatRServicesExtensions
    {
#if NETSTANDARD1_3 || NET451
        public static MediatRServicesBuilder WithMediatR(this Rocket.Surgery.Extensions.Autofac.IAutofacConventionContext builder)
        {
            DefaultServices(builder);
            return new MediatRServicesBuilder(builder);
        }

        private static void DefaultServices(Rocket.Surgery.Extensions.Autofac.IAutofacConventionContext builder)
        {
            builder.ConfigureContainer(container => DefaultServices(container, builder.AssemblyCandidateFinder));
        }

        private static void DefaultServices(ContainerBuilder container, IAssemblyCandidateFinder assemblyCandidateFinder)
        {
            container
                .RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            var assemblies = assemblyCandidateFinder
                .GetCandidateAssemblies(nameof(MediatR)).ToArray();

            bool Predicate(Type v)
            {
                return v.IsClosedTypeOf(typeof(IRequestHandler<>)) ||
                       v.IsClosedTypeOf(typeof(IRequestHandler<,>)) ||
                       v.IsClosedTypeOf(typeof(INotificationHandler<>));
            }

            container
                .RegisterAssemblyTypes(assemblies)
                .Where(Predicate)
                .AsImplementedInterfaces();


            container
                .Register<SingleInstanceFactory>(c =>
                {
                    var ctx = c.Resolve<IComponentContext>();
                    return t => ctx.TryResolve(t, out var o) ? o : null;
                })
                .InstancePerLifetimeScope();

            container
                .Register<MultiInstanceFactory>(c =>
                {
                    var ctx = c.Resolve<IComponentContext>();
                    return t => (IEnumerable<object>)ctx.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
                })
                .InstancePerLifetimeScope();
        }
#else
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
#endif
    }
}
