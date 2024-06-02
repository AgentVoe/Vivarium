using Vivarium.Context;
using Vivarium.StaticData;

namespace Vivarium
{
	public class DataLoader
	{
		private string login;
		public DataLoader()
		{
			LoadAuthorsAndBooks();
		}
		public DataLoader(string login)
		{
			this.login = login;
			LoadUserAndBooks();
		}

		#region Процедуры выгрузки данных из БД
		/*
			Процедура выгружает данные из БД
			Затем создаёт вложенную структуру
			Содержащую Автора, Книги и Жанры книги
		*/

		private void LoadAuthorsAndBooks()
		{
			using (VivariumDContext db = new VivariumDContext())
			{

				AuthorsAndBooks.authorsAndBooks = db.BooksAuthors
					.OrderBy(a => a.Id)
					.Take(10)
					.Select(ba => new BooksAuthor()
					{
						Id = ba.Id,
						AuthorId = ba.AuthorId,
						Author = new Author()
						{
							Id = ba.Author.Id,
							Name = ba.Author.Name
						},
						BookId = ba.BookId,
						Book = new Book()
						{
							Id = ba.Book.Id,
							Title = ba.Book.Title,
							BYear = ba.Book.BYear,
							BooksGenres = ba.Book.BooksGenres.Select(genre => new BooksGenre()
							{
								Id = genre.Id,
								Genre = new Genre()
								{
									Id = genre.Genre.Id,
									GenreName = genre.Genre.GenreName
								}
							}).ToList()
						}
					}).ToList();
			}
		}
		/*
			Процедура выгружает данные из БД
			Затем создаёт вложенную структуру
			Содержащую Пользователя, его книги и хар-ки книги
		*/
		private void LoadUserAndBooks()
		{
			// Пока без челенжей и оценок
			using (VivariumDContext db = new VivariumDContext())
			{
				UserAndBooks.userAndBooks = db.Users
				.Where(user => user.Login == login)
				.Select(u => new User
				{
					Id = u.Id,
					Login = u.Login,
					StatusBooks = u.StatusBooks.Select(ub => new StatusBook
					{
						Id = ub.Id,
						StDate = ub.StDate,
						Book = new Book()
						{
							Id = ub.Book.Id,
							Title = ub.Book.Title,
							BYear= ub.Book.BYear,
							BooksGenres = ub.Book.BooksGenres.Select(genre => new BooksGenre()
							{
								Id = genre.Id,
								Genre = new Genre()
								{
									Id = genre.Genre.Id,
									GenreName = genre.Genre.GenreName
								}
							}).ToList()
						},
						Status = new Status()
						{
							Id = ub.Status.Id,
							Status1 = ub.Status.Status1
						}
					}).ToList()
				})
				.FirstOrDefault();
			}
		}
		#endregion
	}
}
