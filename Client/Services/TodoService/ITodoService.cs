using System;
using TaskList.Shared;

namespace TaskList.Client.Services.TodoService
{
    public interface ITodoService
    {
        List<Todo> Todos { get; set; }

        // Get all Todos
        Task GetTodos();

        // Get a Todo by ID
        Task<Todo?> GetTodoById(int id);

        // Create a Todo
        Task CreateTodo(Todo todo);

        // Update a Todo
        Task UpdateTodo(Todo todo);

        // Delete a Todo
        Task DeleteTodo(int id);
    }
}

