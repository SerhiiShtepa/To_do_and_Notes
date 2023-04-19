using To_Do_and_Notes.Data;
using To_Do_and_Notes.Models;

namespace To_Do_and_Notes.Services
{
    public class NotesService
    {
        private ToDoAndNotesDbContext _context;

        public NotesService(ToDoAndNotesDbContext context)
        {
            _context = context;
        }
        public void AddNote(Note newNote)
        {
            _context.Notes.Add(newNote);
            _context.SaveChanges();
        }
    }
}
