using To_Do_and_Notes.Data;
using To_Do_and_Notes.Models;

namespace To_Do_and_Notes.Services
{
    public class FolderService
    {
        private readonly ToDoAndNotesDbContext _context;

        public FolderService(ToDoAndNotesDbContext context)
        {
            _context = context;
        }
        public bool CreateFolder(Folder newFolder, int? userId)
        {
            newFolder.User = _context.Users.Where(u => u.UserId == userId).First();
            _context.Folders.Add(newFolder);
            _context.SaveChanges();
            return true;
        }

    }
}
