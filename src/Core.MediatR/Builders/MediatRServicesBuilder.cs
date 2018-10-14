using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Rocket.Surgery.Builders;

namespace Rocket.Surgery.Core.MediatR.Builders
{
    public class MediatRServicesBuilder : Builder<Rocket.Surgery.Extensions.DependencyInjection.IServiceConventionContext>
    {
        internal MediatRServicesBuilder(Rocket.Surgery.Extensions.DependencyInjection.IServiceConventionContext servicesBuilder) : base(servicesBuilder, servicesBuilder.Properties) { }
    }
}

