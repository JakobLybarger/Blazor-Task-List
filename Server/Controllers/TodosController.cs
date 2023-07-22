using Microsoft.AspNetCore.Mvc;
using TaskList.Server.Repositories;
using TaskList.Shared;

namespace TaskList.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : Controller
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ILogger<TodosController> _logger;

        public TodosController(ITodoRepository todoRepository, ILogger<TodosController> logger)
        {
            _todoRepository = todoRepository;
            _logger = logger;
        }
        // GET: /api/todos
        [HttpGet]
        public async Task<ActionResult<List<Todo>>> Get()
        {
            _logger.LogInformation("Retrieving all Todos from database", DateTimeOffset.UtcNow);

            return Ok(await _todoRepository.GetAllAsync());
        }

        // GET api/todos/<ID>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Todo>> GetById([FromRoute] int id)
        {
            _logger.LogInformation($"Retrieving Todo with ID: {id}", DateTimeOffset.UtcNow);

            var todo = await _todoRepository.GetByIdAsync(id);
            if (todo == null)
            {
                return NotFound("This todo doesn't exist.");
            }

            return Ok(todo);
        }

        // POST api/todos
        [HttpPost]
        public async Task<ActionResult<Todo>> Post([FromBody] Todo todo)
        {
            _logger.LogInformation("Creating a Todo", DateTimeOffset.UtcNow);

            todo = await _todoRepository.CreateAsync(todo);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        // PUT api/todo/<ID>
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Todo>> Put([FromRoute] int id, [FromBody] Todo todo)
        {
            _logger.LogInformation($"Updating Todo with ID: {id}", DateTimeOffset.UtcNow);

            var updatedTodo = await _todoRepository.UpdateAsync(id, todo);
            if (updatedTodo == null)
            {
                return NotFound("This Todo doesn't exist");
            }

            return Ok(updatedTodo);
        }

        // DELETE api/todos/<ID>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Todo>> Delete([FromRoute] int id)
        {
            _logger.LogInformation($"Deleting Todo with Id: {id}", DateTimeOffset.UtcNow);

            var todo = await _todoRepository.DeleteAsync(id);
            if (todo == null)
            {
                return NotFound("This Todo doesn't exist");
            }

            return Ok(id);
        }
    }
}

