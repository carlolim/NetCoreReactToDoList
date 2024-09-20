using Microsoft.AspNetCore.Mvc;
using NetCoreReactToDoList.Models;

namespace NetCoreReactToDoList.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class TodoController : ControllerBase
    {
        public static List<TodoItem> Todos = new List<TodoItem>();
        public static int NextId = 1;

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            return Ok(Todos);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(TodoItem item)
        {
            item.Id = NextId;
            NextId++;
            Todos.Add(item);

            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id)
        {
            var todo = Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsCompleted = !todo.IsCompleted;

            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todo = Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            Todos.Remove(todo);

            return Ok();
        }
    }
}