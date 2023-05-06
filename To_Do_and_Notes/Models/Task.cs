namespace To_Do_and_Notes.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public int FolderId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public Folder Folder { get; set; }
    }
}
