using ApiOpenIARequests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ApiOpenIARequests.Extensions.Builder;

public static class ApiOpenIARequestsExtension
{
    public static void AddApiOpenIARequests(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddApiOpenIARequestsRepositories();
        services.AddApiOpenIARequestsServices();
    }

    public static void AddApiOpenIARequestsRepositories(this IServiceCollection services)
    {
        services.AddSingleton<HttpClientRepository>();
    } 
    
    public static void AddApiOpenIARequestsServices(this IServiceCollection services)
    {
        
    } 
}
