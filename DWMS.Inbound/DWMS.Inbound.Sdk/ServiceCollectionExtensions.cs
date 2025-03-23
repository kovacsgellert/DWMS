using DWMS.Inbound.Sdk.Client;
using Microsoft.Extensions.DependencyInjection;

namespace DWMS.Inbound.Sdk;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInboundClient(this IServiceCollection services)
    {
        services.AddTransient<IInboundClient, InboundClient>();
        return services;
    }
}
