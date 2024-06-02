namespace Assignment.Domain.Entities.Todo;

public class TodoList : BaseAuditableEntity
{
    public required string Title { get; set; }

    public Colour Colour { get; set; } = Colour.White;

    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}
