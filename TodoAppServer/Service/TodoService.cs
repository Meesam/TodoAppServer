using TodoAppServer.Data;
using TodoAppServer.Models;

namespace TodoAppServer.Service
{
    public class TodoService : ITodoService
    {
        private readonly TodoAppDbContext _dbContext;

        public TodoService(TodoAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddTodo(Todo todo)
        {
            try
            {
                _dbContext.Todos.Add(todo);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public Todo? GetTodoById(int id)
        {
            try
            {
                return _dbContext?.Todos.Find(id);
            }
            catch
            {
                throw;

            }
        }

        public IQueryable<Todo> GetTodos()
        {
            try
            {
                return _dbContext.Todos.OrderByDescending(x => x.CreatedDate);
            }
            catch { throw; }
        }

        public bool RemoveTodo(int todoId)
        {
            try
            {
                var todo = _dbContext?.Todos.Find(todoId);
                if (todo is not null)
                {
                    _dbContext?.Todos.Remove(todo);
                    _dbContext?.SaveChanges();
                    return true;
                }
                return false;

            }
            catch { throw; }
        }

        public bool UpdateTodo(Todo todo)
        {
            try
            {
                _dbContext?.Update(todo);
                _dbContext?.SaveChanges();
                return true;
            }
            catch { throw; }
        }
    }
}
