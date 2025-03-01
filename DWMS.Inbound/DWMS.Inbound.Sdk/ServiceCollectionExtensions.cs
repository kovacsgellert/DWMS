using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWMS.Inbound.Sdk;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInboundClient(this IServiceCollection services)
    {
        services.AddTransient<IInboundClient, InboundService>();
        return services;
    }
}
