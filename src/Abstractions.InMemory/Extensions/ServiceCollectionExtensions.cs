using NoteDotNet.Abstractions;
using NoteDotNet.Abstractions.InMemory;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInMemoryData(this IServiceCollection services)
        {
            services
                .AddSingleton<INoteService, InMemoryNoteService>()
            ;

            return services;
        }
    }
}
