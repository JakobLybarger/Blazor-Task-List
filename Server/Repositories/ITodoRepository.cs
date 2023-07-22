using System;
using TaskList.Shared;

namespace TaskList.Server.Repositories
{
	public interface ITodoRepository
	{
		// Get all
		Task<List<Todo>> GetAllAsync();

		// Get by id
		Task<Todo?> GetByIdAsync(int id);

		// Create
		Task<Todo> CreateAsync(Todo todo);

		// Update
		Task<Todo?> UpdateAsync(int id, Todo todo);

		// Delete
		Task<Todo?> DeleteAsync(int id);
	}
}

