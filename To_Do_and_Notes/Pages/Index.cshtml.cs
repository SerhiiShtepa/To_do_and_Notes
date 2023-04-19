using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using To_Do_and_Notes.Data;
using To_Do_and_Notes.Models;
using To_Do_and_Notes.Services;

namespace To_Do_and_Notes.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ToDoAndNotesDbContext _context;
        public List<User> Users { get; set; }
        public List<Note> Notes { get; set; }
        public List<Models.Task> Tasks { get; set; }

        private UsersService _usersService;
        private TasksService _tasksService;
        private NotesService _notesService;

        [BindProperty]
        public Models.Task NewTask { get; set; }
        [BindProperty]
        public Models.Note NewNote { get; set; }

        public IndexModel(ToDoAndNotesDbContext context)
        {
            _context = context;
            _usersService = new UsersService(_context);
            _tasksService = new TasksService(_context);
            _notesService = new NotesService(_context);
        }
        public void OnGet()
        {
            Tasks = _context.Tasks.ToList();
            Notes = _context.Notes.ToList();
        }
        public IActionResult OnPost()
        {
            Models.Task task = new Models.Task()
            {
                Description= NewTask.Description,
                Title= NewTask.Title,
                IsCompleted = NewTask.IsCompleted,
                User = _context.Users.First()
            };
            _tasksService.AddTask(task);
            return RedirectToAction("Get");
        }
    }
}