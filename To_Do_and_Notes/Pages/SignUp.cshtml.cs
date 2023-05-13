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
            int? userId = UserService.SignUp(NewUser); // get user id from db
            if (userId == -1)
            {
                ModelState.AddModelError("NewUser.Email", "Така пошта вже існує");
                return Page();              
            }
            else
            {
                HttpContext.Session.SetInt32("UserId", Convert.ToInt32(userId));
                HttpContext.Session.SetString("PageToDisplay", PageToDisplay.MAIN.ToString());
                return RedirectToPage("Main");
            }
        }
    }
}
