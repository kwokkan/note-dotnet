using NoteDotNet.Data.Abstractions;
using NoteDotNet.Data.InMemory;

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
