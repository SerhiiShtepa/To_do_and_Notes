using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using To_Do_and_Notes.Data;
using To_Do_and_Notes.Models;
using To_Do_and_Notes.Services;

namespace To_Do_and_Notes.Pages
{
    public class MainModel : PageModel
    {
        static public int? UserId { get; set; }
        [BindProperty]
        public Folder? NewFolder { get; set; }

        private readonly ToDoAndNotesDbContext _context;
        public FolderService FolderService { get; set; }
        public MainModel(ToDoAndNotesDbContext context)
        {
            _context = context;
            FolderService = new FolderService(_context);
        }

        public void OnGet()
        {
            UserId = HttpContext.Session.GetInt32("UserId");

            if (UserId == null)
            {
                RedirectToPage("SignIn");
            }
        }

        public IActionResult OnPostCreateFolder()
        {
            if (FolderService.CreateFolder(NewFolder, UserId))
            {
                return RedirectToAction("Get");
            }
            else
            {
                return Page();
            }
        }
    }
}
