using System.Collections.Concurrent;
using System;
using System.Collections.Generic;
using ToDoApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ToDoApp.Repository
{
    public class TodoRepository : ITodoRepository
    {

        private readonly APIDbContext _appDBContext;
        public TodoRepository(APIDbContext context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }


        public async Task DeleteAllToDoItems()
        {
            _appDBContext.ToDoItems.RemoveRange(_appDBContext.ToDoItems);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetToDoItemsByEmployee(string employee)
        {
            return await _appDBContext.ToDoItems.FromSqlRaw("SELECT * FROM TodoItem WHERE employee = {0}", employee).ToListAsync();
        }






        public async Task<IEnumerable<TodoItem>> GetTodoItem()
        {
            return await _appDBContext.ToDoItems.ToListAsync();
        }

        public async Task<TodoItem> GetTodoItemByID(int ID)
        {
            return await _appDBContext.ToDoItems.FindAsync(ID);
        }

      
    

        public async Task<TodoItem> InsertTodoItem(TodoItem objTodoItem)
        {
            System.Diagnostics.Debug.WriteLine("DAAAAAAATA " + objTodoItem.Name);
            _appDBContext.ToDoItems.Add(objTodoItem);
            await _appDBContext.SaveChangesAsync();
            return objTodoItem;
        }
        public async Task<TodoItem> UpdateTodoItem(TodoItem objTodoItem)
        {
            _appDBContext.Entry(objTodoItem).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objTodoItem;
        }
        public bool DeleteTodoItem(int ID)
        {
            bool result = false;
            var toDoItem = _appDBContext.ToDoItems.Find(ID);
            if (toDoItem != null)
            {
                _appDBContext.Entry(toDoItem).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }


    }
}
