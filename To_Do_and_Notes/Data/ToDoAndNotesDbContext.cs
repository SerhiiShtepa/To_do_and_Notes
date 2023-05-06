using Microsoft.EntityFrameworkCore;
using To_Do_and_Notes.Models;

namespace To_Do_and_Notes.Data
{
    public class ToDoAndNotesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public ToDoAndNotesDbContext(DbContextOptions<ToDoAndNotesDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                 .UseSqlServer(@"Server=(localdb)\mssqllocaldb; DataBase=ToDoAndNotesDb;")
                 .EnableDetailedErrors()
                 .EnableSensitiveDataLogging()
                 .LogTo(Console.WriteLine, LogLevel.Information);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
              .Entity<User>()
              .HasMany(f => f.Folders)
              .WithOne(u => u.User)
              .HasPrincipalKey(u => u.UserId)
              .HasForeignKey(u => u.UserId);
            modelBuilder
              .Entity<Models.Task>()
              .HasOne(f => f.Folder)
              .WithMany(t => t.Tasks)
              .HasPrincipalKey(f => f.FolderId)
              .HasForeignKey(f => f.FolderId);
            modelBuilder
              .Entity<Note>()
              .HasOne(f => f.Folder)
              .WithMany(n => n.Notes)
              .HasPrincipalKey(f => f.FolderId)
              .HasForeignKey(f => f.FolderId);
        }

    }
}
