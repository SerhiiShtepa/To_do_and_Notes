using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using To_Do_and_Notes.Data;
using To_Do_and_Notes.Models;

namespace To_Do_and_Notes.Services
{
    public class FolderService
    {
        public ToDoAndNotesDbContext _context { get; set; }


        public FolderService(ToDoAndNotesDbContext context)
        {
            _context = context;
        }
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
            return _context.Folders.Where(f => f.UserId == userId).ToList();
        }
        public List<Folder> GetAllActiveFolders(int? userId)
        {
            if (userId == null) { return null; }
            List<Folder> folders = _context.Folders.Where(f => f.UserId == userId && f.IsDeleted == false).ToList();
            return folders;
        }
        public List<Folder> GetAllMarkedAsDeletedFolders(int? userId)
        {
            if (userId == null) { return null; }
            return _context.Folders.Where(f => f.UserId == userId && f.IsDeleted == true).ToList();
        }
        
        public bool RenameFolder(Folder folderWithNewName)
        {
            if (folderWithNewName == null) { return false; }
            _context.Folders.Where(f => f.FolderId == folderWithNewName.FolderId).First().Name = folderWithNewName.Name;
            _context.SaveChanges();
            return true;
        }
        public bool MarkFolderAsDeleted(Folder folderToMark)
        {
            if (folderToMark == null) { return false; }
            _context.Folders.Where(f => f.FolderId == folderToMark.FolderId).First().IsDeleted = true;

            foreach (Models.Task task in _context.Tasks.Where(t => t.FolderId == folderToMark.FolderId).ToList())
            {
                task.IsDeleted = true;
            }
            foreach (Note note in _context.Notes.Where(n => n.FolderId == folderToMark.FolderId).ToList())
            {
                note.IsDeleted = true;
            }
            _context.SaveChanges();
            return true;
        }
        public bool TryToDeleteMarkedFolders()
        {
            List<Folder> folders =  _context.Folders.Where(f => f.IsDeleted == true).Include(f => f.Tasks).Include(f => f.Notes).ToList();
            foreach (var folder in folders)
            {
                if (folder.Tasks.Count == 0 && folder.Notes.Count == 0)
                {
                    _context.Remove(folder);
                }
            }
            _context.SaveChanges();
            return true;
        }
        public Folder CreateStartupFolder(int? userId)
        {
            if (userId == null) { return null; }

            Folder folder = new Folder()
            {
                Name = "Згенерована папка",
                User = _context.Users.Where(u => u.UserId == userId).First()
            };
            _context.Folders.Add(folder);
            _context.SaveChanges();
            return folder;
        }
        public Folder GetFolderById(int? folderId)
        {
            if (folderId == null) { return null; }
            return _context.Folders.Where(f => f.FolderId == folderId).First();
        }
        public Folder GetActiveFolderById(int? folderId)
        {
            if (folderId == null) { return null; }
            return _context.Folders.Where(f => f.FolderId == folderId && f.IsDeleted == false).FirstOrDefault();
        }
    }
}
