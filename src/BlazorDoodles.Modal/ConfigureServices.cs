using Microsoft.Extensions.DependencyInjection;

namespace BlazorDoodles.Modal;

public static class ConfigureServices
{
    public static IServiceCollection AddModalServices(this IServiceCollection services)
    {
        return services.AddSingleton<IModalService, ModalService>();
    }
}
