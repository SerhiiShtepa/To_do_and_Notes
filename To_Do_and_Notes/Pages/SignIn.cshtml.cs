using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
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
            int? userId = UserService.SignIn(User); // get user id from db
            if (userId == -1)
            {            
                ModelState.AddModelError("User.Email", "Неправильна пошта або пароль");
                return Page();
                
            }
            else
            {
                HttpContext.Session.SetInt32("UserId", Convert.ToInt32(userId));
                HttpContext.Session.SetString("ComponentToDisplay", ComponentToDisplay.MAIN.ToString());
                return RedirectToPage("/Controller");
            }
        }
    }
}
