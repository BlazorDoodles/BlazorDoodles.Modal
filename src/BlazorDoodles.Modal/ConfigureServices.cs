using Microsoft.Extensions.DependencyInjection;

namespace BlazorDoodles.Modal;

public static class ConfigureServices
{
    public static IServiceCollection AddModalDoodle(this IServiceCollection services)
    {
        return services.AddSingleton<IModalService, ModalService>();
    }
}
