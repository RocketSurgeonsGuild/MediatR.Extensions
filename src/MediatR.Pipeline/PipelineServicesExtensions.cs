using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rocket.Surgery.Extensions.DependencyInjection;

namespace Rocket.Surgery.Core.MediatR.Pipeline
{
    /// <summary>
    /// Class Auth0ServicesExtensions.
    /// </summary>
    /// TODO Edit XML Comment Template for Auth0ServicesExtensions
    public static class PipelineServicesExtensions
    {
        /// <summary>
        /// Adds the auth0.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>AuthenticationServicesBuilder.</returns>
        /// TODO Edit XML Comment Template for AddAuth0
        public static PipelineServicesBuilder WithPipeline(this IServiceConventionContext builder)
        {
            return new PipelineServicesBuilder(builder);
        }

        public static PipelineServicesBuilder WithFluentValidationBehavior(this PipelineServicesBuilder builder)
        {
            builder.Parent.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationPipelineBehavior<,>));
            return builder;
        }
        public static PipelineServicesBuilder WithMartenBehavior(this PipelineServicesBuilder builder)
        {
            builder.Parent.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MartenPipelineBehavior<,>));
            return builder;
        }
    }
}
