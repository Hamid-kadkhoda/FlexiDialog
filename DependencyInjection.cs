
using Microsoft.Extensions.DependencyInjection;

namespace FlexiDialog;

public static class DependencyInjection
{
    public static void AddFlexiDialog(this IServiceCollection services)
    {
        services.AddScoped<IDialogService, DialogService>();
    }
}
