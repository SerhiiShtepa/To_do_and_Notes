namespace To_Do_and_Notes.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; } // якщо Google-вхід
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
