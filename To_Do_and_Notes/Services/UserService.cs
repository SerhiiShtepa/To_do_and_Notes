using To_Do_and_Notes.Data;
using To_Do_and_Notes.Models;

namespace To_Do_and_Notes.Services
{
    public class UserService
    {
        private readonly ToDoAndNotesDbContext _context;

        public UserService(ToDoAndNotesDbContext context)
        {
            _context = context;
        }
        public bool SignIn(User user)
        {
            if (UserExists(user))
            {
                string? checkPassword = _context.Users.Where(u => u.Email == user.Email).FirstOrDefault()?.Password;
                return checkPassword == user.Password ? true : false; 
            }
            else
            {
                return false;
            }
        }
        public bool SignUp(User newUser)
        {
            newUser.CreatedAt = DateTime.Now;
            newUser.ViewMode = ViewMode.TasksNotes;

            if (UserExists(newUser) == false)
            {
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool UserExists(User user)
        {
            User? checkUser = _context.Users.Where(u => u.Email == user.Email).FirstOrDefault();
            return checkUser == null ? false : true;
        }
    }
}
