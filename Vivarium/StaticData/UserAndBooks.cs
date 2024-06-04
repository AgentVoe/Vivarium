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
<<<<<<< HEAD
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
        public static Dictionary<string, int> GetYearValue()
        {
            Dictionary<string, int> dictYears = new Dictionary<string, int>();
            foreach (var statusBook in userAndBooks[0].StatusBooks.
                Where(sb => sb.Status.Status1 == "Прочитано"))
            {
                string year = statusBook.StDate.Value.Year.ToString();
                if (dictYears.ContainsKey(year))
                    dictYears[year] += 1;
                else dictYears.Add(year, 1);
            }
            return dictYears;
        }
    }
>>>>>>> ea0a6313eb26e11a0b3b79a00eb559ec5b9b0803
}
