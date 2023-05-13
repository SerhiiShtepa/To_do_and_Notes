using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using To_Do_and_Notes.Data;
using To_Do_and_Notes.Models;
using To_Do_and_Notes.Services;

namespace To_Do_and_Notes.Pages
{
    public enum PageToDisplay
    {
        MAIN,
        BIN,
        PERSONALINFO
    }
    public class MainModel : PageModel
    {
        public PageToDisplay PageToDisplay { get; set; }
        public MainModel()
        {
            
        }
        public void OnGet()
        {
            if (Enum.TryParse(HttpContext.Session.GetString("PageToDisplay"), out PageToDisplay pageToDisplay))
            {
                PageToDisplay = pageToDisplay;
            }
            else
            {
                RedirectToPage("SignIn");
            }
        }
    }
}
