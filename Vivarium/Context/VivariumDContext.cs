using Microsoft.EntityFrameworkCore;

namespace Vivarium.Context;

public partial class VivariumDContext : DbContext
{
    public VivariumDContext()
    {
    }

    public VivariumDContext(DbContextOptions<VivariumDContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assessment> Assessments { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BooksAuthor> BooksAuthors { get; set; }

    public virtual DbSet<BooksGenre> BooksGenres { get; set; }

    public virtual DbSet<Challenge> Challenges { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StatusBook> StatusBooks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=VivariumD;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("assessments_pkey");

            entity.ToTable("assessments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Book).WithMany(p => p.Assessments)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("assessments_book_id_fkey");

            entity.HasOne(d => d.Grade).WithMany(p => p.Assessments)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("assessments_grade_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Assessments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("assessments_user_id_fkey");
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("authors_pkey");

            entity.ToTable("authors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("books_pkey");

            entity.ToTable("books");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BYear)
                .HasMaxLength(100)
                .HasColumnName("b_year");
            entity.Property(e => e.Title)
                .HasMaxLength(1000)
                .HasColumnName("title");
        });

        modelBuilder.Entity<BooksAuthor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("books_authors_pkey");

            entity.ToTable("books_authors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");

            entity.HasOne(d => d.Author).WithMany(p => p.BooksAuthors)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("books_authors_author_id_fkey");

            entity.HasOne(d => d.Book).WithMany(p => p.BooksAuthors)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("books_authors_book_id_fkey");
        });

        modelBuilder.Entity<BooksGenre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("books_genres_pkey");

            entity.ToTable("books_genres");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");

            entity.HasOne(d => d.Book).WithMany(p => p.BooksGenres)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("books_genres_book_id_fkey");

            entity.HasOne(d => d.Genre).WithMany(p => p.BooksGenres)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("books_genres_genre_id_fkey");
        });

        modelBuilder.Entity<Challenge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("challenges_pkey");

            entity.ToTable("challenges");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChYear).HasColumnName("ch_year");
            entity.Property(e => e.Fact).HasColumnName("fact");
            entity.Property(e => e.Plan).HasColumnName("plan");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Challenges)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("challenges_user_id_fkey");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("genres_pkey");

            entity.ToTable("genres");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GenreName)
                .HasMaxLength(100)
                .HasColumnName("genre_name");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("grades_pkey");

            entity.ToTable("grades");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Grade1).HasColumnName("grade");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("statuses_pkey");

            entity.ToTable("statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Status1)
                .HasMaxLength(40)
                .HasColumnName("status");
        });

        modelBuilder.Entity<StatusBook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_book_pkey");

            entity.ToTable("status_book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.StDate).HasColumnName("st_date");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Book).WithMany(p => p.StatusBooks)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("status_book_book_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.StatusBooks)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("status_book_status_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.StatusBooks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("status_book_user_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(40)
                .HasColumnName("login");
            entity.Property(e => e.Pass)
                .HasMaxLength(100)
                .HasColumnName("pass");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
