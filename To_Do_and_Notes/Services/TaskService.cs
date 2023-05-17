using To_Do_and_Notes.Data;
using To_Do_and_Notes.Models;

namespace To_Do_and_Notes.Services
{
    public class TaskService
    {
        private readonly ToDoAndNotesDbContext _context;

        public TaskService(ToDoAndNotesDbContext context)
        {
            _context = context;
        }
        public bool CreateTask(Models.Task newTask, int? folderId)
        {
            if (newTask == null || folderId == null || newTask?.Title == null) { return false; }
            newTask.CreatedAt = DateTime.Now;
            newTask.Folder = _context.Folders.Where(f => f.FolderId == folderId).First();
            if (newTask.IsCompleted == null)
            {
                newTask.IsCompleted = false;
            }
            _context.Tasks.Add(newTask);
            _context.SaveChanges();
            return true;
        }
        public List<Models.Task> GetAllActiveTasks(int? folderId)
        {
            if (folderId == null) { return null; }
            return _context.Tasks.Where(t => t.FolderId == folderId && t.IsDeleted == false).ToList();
        }
        public List<Models.Task> GetAllMarkedAsDeletedTasks(int? folderId)
        {
            if (folderId == null) { return null; }
            return _context.Tasks.Where(t => t.FolderId == folderId && t.IsDeleted == true).ToList();
        }
        public bool EditTask(Models.Task editTask)
        {
            if (editTask == null) { return false; }
            Models.Task updatedTask = _context.Tasks.Where(t => t.TaskId == editTask.TaskId).First();
            updatedTask.Title = editTask.Title;
            updatedTask.Description = editTask.Description;
            updatedTask.IsCompleted = editTask.IsCompleted;
            _context.SaveChanges();
            return true;
        }
        public bool MarkTaskAsDeleted(Models.Task taskToMark)
        {
            if (taskToMark == null) { return false; }
            _context.Tasks.Where(t => t.TaskId == taskToMark.TaskId).First().IsDeleted = true;
            _context.SaveChanges();
            return true;
        }
        public bool DeleteMarkedTask(Models.Task markedTask)
        {
            if (markedTask == null || markedTask.IsDeleted == false) { return false; }
            _context.Remove(_context.Tasks.Where(t => t.FolderId == markedTask.FolderId).First());
            _context.SaveChanges();
            return true;
        }
        public bool ChangeCompleteState(Models.Task toChangeTask)
        {
            if (toChangeTask == null) { return false; }
            _context.Tasks.Where(t => t.TaskId == toChangeTask.TaskId).First().IsCompleted = !(toChangeTask.IsCompleted);
            _context.SaveChanges();
            return true;
        }       
    }
}
