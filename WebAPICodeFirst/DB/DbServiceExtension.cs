using Microsoft.EntityFrameworkCore;

namespace WebAPICodeFirst.DB
{
    public static class DbServiceExtension
    {
        public static void AddDatabaseService(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<WebAPICodeFirstContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
