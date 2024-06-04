using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using System.Windows.Controls;
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

		public static void UpdateBook(StatusBook book, Assessment ass)
		{
            using (VivariumDContext db = new VivariumDContext())
            {
				var status = db.StatusBooks.FirstOrDefault(st => st.Id == book.Id);
				var asss = db.Assessments.FirstOrDefault(asss => asss.Id == ass.Id);
				
				status.StatusId = book.StatusId;
				asss.GradeId = ass.GradeId;
                db.SaveChanges();
            }
        }

		public static void AddBookToUser(StatusBook book, Assessment ass)
		{
			using (VivariumDContext db = new VivariumDContext())
			{
				db.Assessments.Add(ass);
				db.StatusBooks.Add(book);
				db.SaveChanges();
			}
		}
	}
}
