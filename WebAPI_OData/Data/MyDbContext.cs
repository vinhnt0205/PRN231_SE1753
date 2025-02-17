using Microsoft.EntityFrameworkCore;

namespace WebAPI_OData.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Model.Product> Products { get; set; }

    }
}
