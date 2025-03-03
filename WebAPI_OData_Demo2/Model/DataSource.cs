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

				ISBN = "978-0-321-87758-1",

				Title = "Essential C#5.0",

				Author = "Mark Michaelis",

				Price = 59.99m,

				Location = new Address
				{

					City = "HCM City",

					Street = "D2, Thu Duc District"
				},

				Press = new Press

				{

					Id = 1,

					Name = "Addison-Wesley",

					Category = Category.Book

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
