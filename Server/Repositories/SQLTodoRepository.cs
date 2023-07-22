using System;
using Microsoft.EntityFrameworkCore;
using TaskList.Server.Data;
using TaskList.Shared;

namespace TaskList.Server.Repositories
{
	public class SQLTodoRepository : ITodoRepository
	{
        private readonly DataContext _context;

		public SQLTodoRepository(DataContext context)
		{
            _context = context;
		}

        public async Task<Todo> CreateAsync(Todo todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo?> DeleteAsync(int id)
        {
            // See if todo exists in database
            var existingTodo = await _context.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
            if (existingTodo == null)
            {
                return null;
            }

            _context.Todos.Remove(existingTodo);
            await _context.SaveChangesAsync();
            return existingTodo;
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await _context.Todos.ToListAsync();

        }

        public async Task<Todo?> GetByIdAsync(int id)
        {
            return await _context.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
        }

        public async Task<Todo?> UpdateAsync(int id, Todo todo)
        {
            // See if todo exists in database
            var existingTodo = await _context.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
            if (existingTodo == null)
            {
                return null;
            }

            // Update todo values
            existingTodo.Title = todo.Title;
            existingTodo.Description = todo.Description;
            existingTodo.DueDate = todo.DueDate;
            existingTodo.Priority = todo.Priority;
            existingTodo.Status = todo.Status;

            // Save changes and return new todo
            await _context.SaveChangesAsync();
            return existingTodo;
        }
    }
}

