using Rocket.Surgery.Core.MediatR.Pipeline;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Extensions.DependencyInjection;

[assembly: Convention(typeof(PipelineConvention))]

namespace Rocket.Surgery.Core.MediatR.Pipeline
{
    /// <summary>
    /// Class AppConvention.
    /// </summary>
    /// <seealso cref="IServiceConvention" />
    /// TODO Edit XML Comment Template for AppConvention
    public class PipelineConvention : IServiceConvention
    {
        /// <summary>
        /// Registers the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// TODO Edit XML Comment Template for Register
        public void Register(IServiceConventionContext context)
        {
            context
                .WithPipeline()
                .WithFluentValidationBehavior()
                .WithMartenBehavior();
        }
    }
}
