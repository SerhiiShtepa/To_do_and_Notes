using Microsoft.EntityFrameworkCore;
using To_Do_and_Notes.Data;
using To_Do_and_Notes.Models;

namespace To_Do_and_Notes.Services
{
    public class UserService
    {
        public ToDoAndNotesDbContext _context { get; set; }

        public UserService(ToDoAndNotesDbContext context)
        {
            _context = context;
        }
        public int? SignIn(User user)
        {
            if (user == null)
            {
                return -1;
            }
            User userFind = _context?.Users?.Where(u => u.Email == user.Email)?.FirstOrDefault();
            if (userFind == null) { return -1; }
            return userFind.Password == user.Password ? userFind.UserId : -1;
        }
        public int? SignUp(User newUser)
        {
            if (newUser == null) { return -1; }
            newUser.CreatedAt = DateTime.Now;

            if (UserExists(newUser) == false)
            {
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return newUser.UserId;
            }
            else
            {
                return -1;
            }
            bool UserExists(User user)
            {
                User? checkUser = _context.Users.Where(u => u.Email == user.Email).FirstOrDefault();
                return checkUser == null ? false : true;
            }
        }

        public User GetUserById(int? userId)
        {
            User user = _context?.Users?.Where(u => u.UserId == userId)?.FirstOrDefault();
            return user ?? null;
        }
        public bool EditUser(User editUser, int? userId)
        {
            User user = _context.Users.Where(u => u.UserId == userId).First();
            user.Name = editUser.Name;
            user.Email = editUser.Email;
            user.Password = editUser.Password;
            _context.SaveChanges();
            return true;
        }
    }
}
