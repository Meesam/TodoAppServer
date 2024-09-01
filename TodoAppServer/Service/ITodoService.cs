using TodoAppServer.Models;

namespace TodoAppServer.Service
{
    public interface ITodoService
    {
        public bool AddTodo(Todo todo);
        public bool UpdateTodo(Todo todo);
        public bool RemoveTodo(int todoId);
        public IQueryable<Todo> GetTodos();
        public Todo? GetTodoById(int id);

    }
}
