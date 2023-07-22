using System;
using System.Net.Http.Json;
using TaskList.Shared;

namespace TaskList.Client.Services.TodoService
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient http;

        public TodoService(HttpClient http)
        {
            this.http = http;
        }

        // List of Todo's/Tasks to be accessed by Razor pages
        public List<Todo> Todos { get; set; } = new List<Todo>();

        // Create a Todo
        public async Task CreateTodo(Todo todo)
        {
            HttpResponseMessage response = await http.PostAsJsonAsync("api/todos", todo);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("An Error Occured creating the Task");
            }
        }

        // Delete a Todo
        public async Task DeleteTodo(int id)
        {
            HttpResponseMessage response = await http.DeleteAsync($"api/todos/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("An Error Occured deleting the Task");
            }
        }

        // Get Todo by Id
        public async Task<Todo?> GetTodoById(int id)
        {
            HttpResponseMessage response = await http.GetAsync($"api/todos/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("An Error Occured retriving the Task");
            }
            return await response.Content.ReadFromJsonAsync<Todo>();
        }

        // Get all Todos
        public async Task GetTodos()
        {
            HttpResponseMessage response = await http.GetAsync("api/todos");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("An Error occured while retrieving the Tasks");
            }

            // Get todos from response and assign if not null
            var todos = await response.Content.ReadFromJsonAsync<List<Todo>>();
            if (todos != null)
            {
                Todos = todos;
            }
        }

        // Update a Todo
        public async Task UpdateTodo(Todo todo)
        {
            HttpResponseMessage response = await http.PutAsJsonAsync($"api/todos/{todo.Id}", todo);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("An Error occured while Updating the Task");
            }
        }
    }
}

