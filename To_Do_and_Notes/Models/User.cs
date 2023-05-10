using System.ComponentModel.DataAnnotations;

namespace To_Do_and_Notes.Models
{
    [Serializable]
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-zА-Яа-яІіЇїЄєҐґ']+([ A-Za-zА-Яа-яІіЇїЄєҐґ']+)*", ErrorMessage = "Вкажіть ім'я з 1-30 символів")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Вкажіть ім'я з 1-30 символів")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Пошта некоректна (name@example.com)")]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Пароль некоректний (повинен містити 8-25 символів)")]
        public string Password { get; set; }

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
