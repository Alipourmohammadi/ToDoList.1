using System.ComponentModel.DataAnnotations;

namespace ToDoList.Applications.DTOs
{
    public class FilterDTO
    {
        public bool done { get; set; }
        public DateTime time { get; set; }
    }
}
