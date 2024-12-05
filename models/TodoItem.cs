namespace ToDoAPI.Models
{
    // Models/TodoItem.cs
    public class TodoItem
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public bool IsComplete { get; set; }
    }

}