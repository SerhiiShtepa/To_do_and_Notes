using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using To_Do_and_Notes.Data;
using To_Do_and_Notes.Models;

namespace To_Do_and_Notes.Services
{
    public class NoteService
    {
        public ToDoAndNotesDbContext _context { get; set; }

        public NoteService(ToDoAndNotesDbContext context)
        {
            _context = context;
        }
        public bool CreateNote(Note newNote, int? folderId)
        {
            if (newNote == null || folderId == null || newNote?.Title == null) { return false; }
            newNote.CreatedAt = DateTime.Now;
            newNote.Folder = _context.Folders.Where(f => f.FolderId == folderId).First();
            _context.Add(newNote);
            _context.SaveChanges();
            return true;
        }
        public List<Note> GetAllActiveNotes(int? folderId)
        {
            if (folderId == null) { return null; }
            return _context.Notes.Where(n => n.FolderId == folderId && n.IsDeleted == false).Include(f => f.Folder).ToList();
        }
        public List<Note> GetAllActiveNotes()
        {
            return _context.Notes.Where(n => n.IsDeleted == false).Include(f => f.Folder).ToList();
        }
        public List<Note> GetAlMarkedAsDeletedNotesByFolder(int? folderId)
        {
            if (folderId == null) { return null; }
            return _context.Notes.Where(n => n.FolderId == folderId && n.IsDeleted == true).ToList();
        }
        public List<Note> GetAlMarkedAsDeletedNotes(int? userId)
        {
            if (userId == null) { return null; }
            var info = _context.Notes.Include(n => n.Folder).ThenInclude(f => f.User).Where(n => n.Folder.UserId == userId && n.IsDeleted == true);
            return info.ToList();
        }
        public bool EditNote(Note editNote)
        {
            if (editNote == null) { return false; }
            Note updatedNote = _context.Notes.Where(n => n.NoteId == editNote.NoteId).First();
            updatedNote.Title = editNote.Title;
            updatedNote.Content = editNote.Content;
            _context.SaveChanges();
            return true;
        }
        public bool MarkTaskAsDeleted(Note noteToMark)
        {
            if (noteToMark == null) { return false; }
            _context.Notes.Where(n => n.NoteId == noteToMark.NoteId).First().IsDeleted = true;
            _context.SaveChanges();
            return true;
        }
        public bool DeleteMarkedNote(Note markedNote)
        {
            if (markedNote == null || markedNote.IsDeleted == false) { return false; }
            _context.Remove(_context.Notes.Where(n => n.NoteId == markedNote.NoteId).First());
            _context.SaveChanges();
            return true;
        }
        public bool RestoreNote(Note markedNote)
        {
            if (markedNote == null) { return false; }
            _context.Notes.Where(n => n.NoteId == markedNote.NoteId).First().IsDeleted = false;
            _context.SaveChanges();
            return true;
        }
    }
}
