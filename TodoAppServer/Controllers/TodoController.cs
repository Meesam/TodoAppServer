using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TodoAppServer.Models;
using TodoAppServer.Service;

namespace TodoAppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        [Route("getAllTodos")]
        public ActionResult GetAllTodos()
        {
            try
            {
                var data = _todoService.GetTodos();
                return Ok(data);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("addNew")]
        public ActionResult AddTodo(Todo todo)
        {
            try
            {
                if (todo is null)
                {
                    return BadRequest();
                }
                else
                {
                    todo.CreatedDate = DateTime.Now;
                    todo.IsDeleted = false;
                    todo.IsCompleted = false;
                    var response = _todoService.AddTodo(todo);
                    if (response)
                    {
                        return Ok(response);
                    }
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("updateTodo")]
        public ActionResult UpdateTodo(Todo todo)
        {
            try
            {
                if (todo is null)
                {
                    return BadRequest();
                }
                else
                {
                    var responseTodo = _todoService.GetTodoById(todo.Id);
                    if (responseTodo != null)
                    {
                        responseTodo.Title = todo.Title;
                        responseTodo.Description = todo.Description;
                        responseTodo.IsDeleted = todo.IsDeleted;
                        responseTodo.IsCompleted = todo.IsCompleted;
                        responseTodo.LastModifiedDate = DateTime.Now;
                        var response = _todoService.UpdateTodo(responseTodo);
                        if (response)
                        {
                            return Ok(response);
                        }
                        else
                        {
                            return BadRequest(responseTodo);
                        }
                    }
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("deleteTodo")]
        public ActionResult DeleteTodo(int todoId)
        {
            try
            {
                if (todoId <= 0)
                {
                    return BadRequest();
                }
                else
                {
                    var responseTodo = _todoService.GetTodoById(todoId);
                    if (responseTodo != null)
                    {
                        
                        responseTodo.IsDeleted = true;
                        responseTodo.LastModifiedDate = DateTime.Now;
                        _todoService.UpdateTodo(responseTodo);
                        return Ok();
                        
                    }
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getTodoById")]
        public ActionResult GetTodo(int todoId)
        {
            try
            {
                if (todoId <= 0)
                {
                    return BadRequest();
                }
                else
                {
                    var response = _todoService.GetTodoById(todoId);
                    if (response is not null)
                    {
                        return Ok(response);
                    }
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
