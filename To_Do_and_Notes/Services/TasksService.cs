using To_Do_and_Notes.Data;
using To_Do_and_Notes.Models;

namespace To_Do_and_Notes.Services
{
    public class TasksService
    {
        private ToDoAndNotesDbContext _context;

        public TasksService(ToDoAndNotesDbContext context)
        {
            _context = context;
        }

        public void AddTask(Models.Task newTask)
        {
            _context.Tasks.Add(newTask);
            _context.SaveChanges();
        }
    }
}
