using To_Do_and_Notes.Data;
using To_Do_and_Notes.Models;

namespace To_Do_and_Notes.Services
{
    public class UserService
    {
        private ToDoAndNotesDbContext _context;

        public UserService(ToDoAndNotesDbContext context)
        {
            _context = context;
        }

        public void AddUser(User newUser)
        {
            newUser.CreatedAt = DateTime.Now;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
