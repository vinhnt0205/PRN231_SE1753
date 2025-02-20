using Microsoft.EntityFrameworkCore;

namespace WebAPI_OData_Demo2.Model
{
	public class BookStoreContext : DbContext
	{
		public BookStoreContext(DbContextOptions opt) : base(opt)
		{

		}
		public DbSet<Book> Books { get; set; }
		public DbSet<Press> Presses { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Book>().OwnsOne(b => b.Location);
		}

	}
}
