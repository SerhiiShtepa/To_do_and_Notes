namespace To_Do_and_Notes.Models
{
    public class Folder
    {
        public int FolderId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
