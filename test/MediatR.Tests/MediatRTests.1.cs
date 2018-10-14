using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using FakeItEasy;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Core.MediatR;
using Rocket.Surgery.Core.MediatR.Builders;
using Rocket.Surgery.Conventions.Reflection;
using Rocket.Surgery.Conventions.Scanners;
using Rocket.Surgery.Extensions.DependencyInjection;
using Rocket.Surgery.Extensions.Testing;
using Xunit;
using Xunit.Abstractions;

namespace Rocket.Surgery.MediatR.Tests
{
    public class MediatRTests : AutoTestBase
    {
        public MediatRTests(ITestOutputHelper outputHelper) : base(outputHelper) { }

        class TestAssemblyProvider : IAssemblyProvider
        {
            public IEnumerable<Assembly> GetAssemblies()
            {
                return new[]
                {
                    typeof(TestAssemblyProvider).GetTypeInfo().Assembly,
                    typeof(MediatRServicesExtensions).GetTypeInfo().Assembly,
                };
            }
        }

        class TestAssemblyCandidateFinder : IAssemblyCandidateFinder
        {
            public IEnumerable<Assembly> GetCandidateAssemblies(IEnumerable<string> candidates)
            {
                return new[]
                {
                    typeof(TestAssemblyProvider).GetTypeInfo().Assembly,
                    typeof(MediatRServicesExtensions).GetTypeInfo().Assembly,
                };
            }
        }

        [Fact]
        public async Task Test1()
        {
            AutoFake.Provide<IAssemblyProvider>(new TestAssemblyProvider());
            AutoFake.Provide<IAssemblyCandidateFinder>(new TestAssemblyCandidateFinder());
            AutoFake.Provide<IServiceCollection>(new ServiceCollection());
            AutoFake.Provide<IConventionScanner>(new BasicConventionScanner(new MediatRConvention()));
            var builder = AutoFake.Resolve<ServicesBuilder>();
            builder.WithMediatR();

            var sub = A.Fake<IPipelineBehavior<Request, Unit>>();

            builder.Services.AddSingleton(sub);

            var r = builder.Build();

            var mediator = r.GetRequiredService<IMediator>();

            await mediator.Send(new Request());

            A.CallTo(() => sub.Handle(A<Request>._, A<CancellationToken>._, A<RequestHandlerDelegate<Unit>>._)).MustHaveHappened(Repeated.Exactly.Once);
        }

        public class Request : IRequest { }

        class TestHandler : IRequestHandler<Request>
        {
            public Task<Unit> Handle(Request message, CancellationToken token)
            {
                return Task.FromResult(global::MediatR.Unit.Value);
            }
        }
    }
}
