using Microsoft.EntityFrameworkCore;
using To_Do_and_Notes.Models;

namespace To_Do_and_Notes.Data
{
    public class ToDoAndNotesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Note> Notes { get; set; }

        public ToDoAndNotesDbContext(DbContextOptions<ToDoAndNotesDbContext> options) : base(options)
        {

        }
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
                .Entity<Models.Task>()
                .HasOne(u => u.User)
                .WithMany(t => t.Tasks)
                .HasPrincipalKey(u => u.Id)
                .HasForeignKey(t => t.UserId);
            modelBuilder
                .Entity<Note>()
                .HasOne(u => u.User)
                .WithMany(n => n.Notes)
                .HasPrincipalKey(u => u.Id)
                .HasForeignKey(n => n.UserId);            
        }
    }
}
