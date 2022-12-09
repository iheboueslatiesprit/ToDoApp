using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Repository
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetTodoItem();
        Task<TodoItem> GetTodoItemByID(int ID);
        Task<TodoItem> InsertTodoItem(TodoItem objTodoItem);
        Task<TodoItem> UpdateTodoItem(TodoItem objTodoItem);
        bool DeleteTodoItem(int ID);
        Task DeleteAllToDoItems();

        Task<IEnumerable<TodoItem>> GetToDoItemsByEmployee(string employee);

    }
}
