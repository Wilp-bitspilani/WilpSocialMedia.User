using WilpSocialMedia.Common;
using WilpSocialMedia.User.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WilpSocialMedia.User.Infrastructure
{
    public class DataContextFactory : IDesignTimeDbContextFactory<Wilpsocialmedia_UserContext>
    {        
        public Wilpsocialmedia_UserContext CreateDbContext(string[] args)
        {
            // Used only for EF .NET Core CLI tools (update database/migrations etc.)
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var config = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<Wilpsocialmedia_UserContext>()
                .UseSqlServer(config.GetConnectionString(Global.DbConnection.UserConnection));

            return new Wilpsocialmedia_UserContext(optionsBuilder.Options);
        }
    }
}
