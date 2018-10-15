using Rocket.Surgery.Builders;
using Rocket.Surgery.Extensions.DependencyInjection;

namespace Rocket.Surgery.Core.MediatR.Pipeline
{
    /// <summary>
    /// Class AuthenticationServicesBuilder.
    /// </summary>
    /// <seealso cref="Builder" />
    /// TODO Edit XML Comment Template for AuthenticationServicesBuilder
    public class PipelineServicesBuilder : Builder<IServiceConventionContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientServicesBuilder"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// TODO Edit XML Comment Template for #ctor
        public PipelineServicesBuilder(IServiceConventionContext parent) : base(parent, parent.Properties) { }
    }
}
