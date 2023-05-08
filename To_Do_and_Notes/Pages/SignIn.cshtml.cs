using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using To_Do_and_Notes.Data;
using To_Do_and_Notes.Models;
using To_Do_and_Notes.Services;

namespace To_Do_and_Notes.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public User? User { get; set; }

        private readonly ToDoAndNotesDbContext _context;
        public UserService UserService { get; set; }
        public SignInModel(ToDoAndNotesDbContext context)
        {
            _context = context;
            UserService = new UserService(_context);
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (UserService.SignIn(User))
            {
                return RedirectToPage("Main");
            }
            else
            {
                ModelState.AddModelError("User.Email", "Неправильна пошта або пароль");
                return Page();
            }
        }
    }
}
