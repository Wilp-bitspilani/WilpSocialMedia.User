using WilpSocialMedia.User.Application;
using WilpSocialMedia.User.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace WilpSocialMedia.User
{
    public static class MainBootsraper
    {
        public static void InitAppBootsraper(this IServiceCollection services)
        {
            RepositoryConfigurer.RegisterServices(services);
            ApplicationConfigurer.RegisterServices(services);
        }
    }
}
