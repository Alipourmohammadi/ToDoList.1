using System.ComponentModel.DataAnnotations;

namespace ToDoList.Applications.DTOs
{
    public class ToDoDTO
    {
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Invalid title length")]

        public string title { get; set; } = string.Empty;

        public DateTime time { get; set; } = DateTime.Now;
    }
}
