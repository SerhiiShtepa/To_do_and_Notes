using System.Threading.Tasks;
using To_Do_and_Notes.Data;
using To_Do_and_Notes.Models;

namespace To_Do_and_Notes.Services
{
    public class UsersService
    {
        private ToDoAndNotesDbContext _context;

        public UsersService(ToDoAndNotesDbContext context) 
        {
            _context = context;
        }

        public void AddUser(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
