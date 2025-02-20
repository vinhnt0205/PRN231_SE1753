namespace WebAPI_OData_Demo2.Model
{
	public static class DataSource
	{
		private static IList<Book> books { get; set; }
		public static IList<Book> GetBooks()
		{
			if(books != null)
			{
				return books;
			}
			books = new List<Book>();
			books.Add(new Book
			{
				Id = 1,
				ISBN = "978-1-321-87758-1",
				Title = "Lap trinh c# 13",
				Author = "FPTU",
				Price = 139000m,
				Location = new Address
				{
					City = "Hanoi City",
					Street = "Hoa Lac"
				},
				Press = new Press
				{
					Id = 1,
					Name = "Tran van A",
					Email = "Tranvana@fpt.edu.vn",
					Category = Category.Book,

				}
			});
			books.Add(new Book
			{
				Id = 2,
				ISBN = "789-2-321-87758-2",
				Title = "Lap trinh Python 13",
				Author = "FPT University",
				Price = 139000m,
				Location = new Address
				{
					City = "HCM City",
					Street = "Quan 1 District"
				},
				Press = new Press
				{
					Id = 2,
					Name = "Tran van B",
					Email = "Tranvanb@fpt.edu.vn",
					Category = Category.Book,

				}
			});
			return books;

		}
	}
}
