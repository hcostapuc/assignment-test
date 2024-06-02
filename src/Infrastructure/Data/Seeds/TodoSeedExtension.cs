using Assignment.Domain.Entities.Todo;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Infrastructure.Data.Seeds;
internal static class TodoSeedExtension
{
    internal static void AddSeed(this DbSet<TodoList> todoList) =>
        todoList.Add(new TodoList
        {
            Title = "Todo List",
            Items =
                {
                    new TodoItem { Title = "Make a todo list 📃" },
                    new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
        });
}
