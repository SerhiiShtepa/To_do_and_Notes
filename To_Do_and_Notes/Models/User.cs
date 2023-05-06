namespace To_Do_and_Notes.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public ViewMode ViewMode { get; set; }
        public ICollection<Folder> Folders { get; set; }
    }
    public enum ViewMode
    {
        Tasks,
        Notes,
        TasksNotes
    }
}
