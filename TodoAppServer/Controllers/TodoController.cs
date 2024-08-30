using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

    }
}
