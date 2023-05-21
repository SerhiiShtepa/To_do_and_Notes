using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using To_Do_and_Notes.Data;
using To_Do_and_Notes.Models;
using To_Do_and_Notes.Services;

namespace To_Do_and_Notes.Pages
{
    public class PersonInfoModel : PageModel
    {
        [BindProperty]
        public User? NewUser { get; set; }

        private readonly ToDoAndNotesDbContext _context;
        public UserService UserService { get; set; }
        public PersonInfoModel(ToDoAndNotesDbContext context)
        {
            _context = context;
            UserService = new UserService(_context);
        }
        public void OnGet()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null || userId == -1) { RedirectToPage("/SignIn"); }
            NewUser = UserService.GetUserById(userId);
        }
        public IActionResult OnPost()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            string email = _context.Users.Where(u => u.UserId == userId).First().Email;
            NewUser.Email = email;
            UserService.EditUser(NewUser, userId);
            return RedirectToPage("SignIn");
        }
    }
}
