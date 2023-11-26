namespace BookStoreWebApi.Utilities;

public static class ServiceTool
{
    public static IServiceProvider ServiceProvider;

    public static IServiceCollection CreateService(this IServiceCollection services)
    {
        ServiceProvider = services.BuildServiceProvider();
        return services;
    }
}