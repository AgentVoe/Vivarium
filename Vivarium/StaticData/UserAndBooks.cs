using Vivarium.Context;

namespace Vivarium.StaticData
{
	public static class UserAndBooks
	{
		public static List<User> userAndBooks;

		public static List<Book> GetBooks()
		{
			List<Book> books = new List<Book>();
		    foreach (var statusBook in userAndBooks[0].StatusBooks)
				books.Add(statusBook.Book);
			return books;
		}

		public static Status GetStatus(int bookId)
		{
			return userAndBooks[0].StatusBooks.Where(sb => sb.Book.Id == bookId).FirstOrDefault().Status;
        }
	}
}
