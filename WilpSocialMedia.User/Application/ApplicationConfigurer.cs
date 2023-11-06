using WilpSocialMedia.User.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace WilpSocialMedia.User.Application
{
    public class ApplicationConfigurer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }
    }
}
