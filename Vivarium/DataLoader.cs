﻿using Vivarium.Context;
using Vivarium.StaticData;

namespace Vivarium
{
	public class DataLoader
	{
		private string login;
		public DataLoader()
		{
			LoadAuthorsAndBooks();
			LoadStatuses();
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
				Books.books = db.Books
				.OrderBy(ba => ba.Id)
				.Take(10)
				.Select(ba => new Book
				{
					Id = ba.Id,
					Title = ba.Title,
					BooksAuthors = ba.BooksAuthors.Select(a => new BooksAuthor
					{
						Id = a.Id,
						Author = new Author()
						{
							Id = a.Id,
							Name = a.Author.Name
						}
					}).ToList(),
					BYear = ba.BYear,
					BooksGenres = ba.BooksGenres.Select(bg => new BooksGenre()
					{
						Id = bg.Id,
						Genre = new Genre()
						{
							Id = bg.Genre.Id,
							GenreName = bg.Genre.GenreName
						}
					}).ToList(),
				})
				.ToList();
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
						BookId = ub.Book.Id,
						Book = new Book()
						{
							Id = ub.Book.Id,
							Title = ub.Book.Title,
                            BooksAuthors = ub.Book.BooksAuthors.Select(a => new BooksAuthor
                            {
                                Id = a.Id,
                                Author = new Author()
                                {
                                    Id = a.Id,
                                    Name = a.Author.Name
                                }
                            }).ToList(),
                            BYear = ub.Book.BYear,
							BooksGenres = ub.Book.BooksGenres.Select(genre => new BooksGenre()
							{
								Id = genre.Id,
								Genre = new Genre()
								{
									Id = genre.Genre.Id,
									GenreName = genre.Genre.GenreName
								}
							}).ToList(),
                            Assessments = ub.Book.Assessments.Select(a => new Assessment()
                            {
                                Id = a.Id,
                                GradeId = a.Grade.Id,
                                Grade = new Grade()
                                {
                                    Id = a.Grade.Id,
                                    Grade1 = a.Grade.Grade1
                                },
                                UserId = ub.User.Id,
                                BookId = ub.Book.Id,
                            }).ToList()
                        },
						Status = new Status()
						{
							Id = ub.Status.Id,
							Status1 = ub.Status.Status1
						}
					}).ToList(),
					Assessments = u.Assessments.Select(a => new Assessment()
					{
						Id = a.Id,
						GradeId = a.Grade.Id,
						Grade = new Grade()
						{
							Id = a.Grade.Id,
							Grade1 = a.Grade.Grade1
						},
						UserId = a.User.Id,
						BookId = a.Book.Id,
					}).ToList()
				})
				.ToList();
			}
		}
		/*
			Процедура выгружает статусы из БД
		*/

		private void LoadStatuses()
		{
			using (VivariumDContext db = new VivariumDContext())
			{
				Books.statuses = db.Statuses.ToList();
			}
		}
		#endregion
	}
}
