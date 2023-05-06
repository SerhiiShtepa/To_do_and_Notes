namespace To_Do_and_Notes.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public int FolderId { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public Folder Folder { get; set; }
    }
}
