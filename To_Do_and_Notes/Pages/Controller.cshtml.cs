using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using To_Do_and_Notes.Data;
using To_Do_and_Notes.Models;
using To_Do_and_Notes.Services;

namespace To_Do_and_Notes.Pages
{
    public enum ComponentToDisplay
    {
        MAIN,
        BIN,
        PERSONALINFO
    }
    public class ControllerModel : PageModel
    {
        public ComponentToDisplay PageToDisplay { get; set; }
        public ControllerModel()
        {
            
        }
        public void OnGet()
        {
            if (Enum.TryParse(HttpContext.Session.GetString("ComponentToDisplay"), out ComponentToDisplay pageToDisplay))
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
