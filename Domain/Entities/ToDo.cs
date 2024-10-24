namespace ToDoList.Core.Entities
{
    public class ToDo
    {
        public Guid Id { get; set; }
        public DateTime dateCreated { get; set; } = DateTime.Now;
        public string title { get; set; } = string.Empty;

        public bool isDeleted { get; set; } = false;
        public bool isDone { get; set; } = false;

    }
}
