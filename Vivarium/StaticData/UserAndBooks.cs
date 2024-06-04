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


		public static int GetCountDoneBook()
		{
			return userAndBooks[0].StatusBooks.Where(sb => sb.Status.Status1 == "Прочитано").Count();
		}
        public static int GetCountStopBook()
        {
            return userAndBooks[0].StatusBooks.Where(sb => sb.Status.Status1 == "Заброшено").Count();
        }
        public static int GetCountFutureBook()
        {
            return userAndBooks[0].StatusBooks.Where(sb => sb.Status.Status1 == "В планах").Count();
        }
        public static int GetCountInProgressBook()
        {
            return userAndBooks[0].StatusBooks.Where(sb => sb.Status.Status1 == "Читаю").Count();
        }
		public static Dictionary<string, int> GetGenresValue()
		{
            Dictionary<string, int> dictGenres = new Dictionary<string, int>();
			foreach (var statusBook in userAndBooks[0].StatusBooks) 
			{
				foreach (var genre in statusBook.Book.BooksGenres)
				{
					if (dictGenres.ContainsKey(genre.Genre.GenreName))
						dictGenres[genre.Genre.GenreName] += 1;
					else dictGenres.Add(genre.Genre.GenreName, 1);
                }				
			}
			return dictGenres;
        }
        public static Dictionary<string, int> GetAuthorsValue()
        {
            Dictionary<string, int> dictAuthors = new Dictionary<string, int>();
            foreach (var statusBook in userAndBooks[0].StatusBooks)
            {
                foreach (var author in statusBook.Book.BooksAuthors)
                {
                    if (dictAuthors.ContainsKey(author.Author.Name))
                        dictAuthors[author.Author.Name] += 1;
                    else dictAuthors.Add(author.Author.Name, 1);
                }
            }
            return dictAuthors;
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
}
