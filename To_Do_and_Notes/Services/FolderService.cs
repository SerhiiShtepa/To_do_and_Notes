using Microsoft.AspNetCore.Hosting;
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
        //public FolderService(ToDoAndNotesDbContext context)
        //{
        //    _context = context;
        //}
        public bool CreateFolder(Folder newFolder, int? userId)
        {
            if (newFolder == null || userId == null || newFolder?.Name == null) { return false; }
            newFolder.User = _context.Users.Where(u => u.UserId == userId).First();
            _context.Folders.Add(newFolder);
            _context.SaveChanges();
            return true;
        }
        public List<Folder> GetAllFolders(int? userId)
        {
            if (userId == null) { return null; }
            return _context.Folders.Where(u => u.UserId == userId).ToList();
        }
        public bool RenameFolder(Folder folderWithNewName)
        {
            if (folderWithNewName == null) { return false; }
            _context.Folders.Where(f => f.FolderId == folderWithNewName.FolderId).First().Name = folderWithNewName.Name;
            _context.SaveChanges();
            return true;
        }
    }
}
