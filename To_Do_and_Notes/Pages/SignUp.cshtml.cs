using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using To_Do_and_Notes.Data;
using To_Do_and_Notes.Models;
using To_Do_and_Notes.Services;

namespace To_Do_and_Notes.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public User? NewUser { get; set; }

        private readonly ToDoAndNotesDbContext _context;
        public UserService UserService { get; set; }
        public SignUpModel(ToDoAndNotesDbContext context)
        {
            _context = context;
            UserService = new UserService(_context);
        }
        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            if (UserService.SignUp(NewUser))
            {
                return RedirectToPage("Main");
            }
            else
            {
                ModelState.AddModelError("NewUser.Email", "Така пошта вже існує");
                return Page();
            }
        }
    }
}
