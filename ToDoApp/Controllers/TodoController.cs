using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ToDoApp.Models;
using ToDoApp.Repository;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]   // [controller] = Todo
    // [ApiController]
    public class TodoController : Controller
    {

        private readonly ITodoRepository _toDoItem;
        public TodoController(ITodoRepository todoItem)
        {
            _toDoItem = todoItem ??
                throw new ArgumentNullException(nameof(todoItem));
        }




        [HttpGet]
        [Route("getToDoItem")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _toDoItem.GetTodoItem());
        }

        [HttpGet]
        [Route("GetToDoItemByID/{Id}")]
        public async Task<IActionResult> GetToDoItemById(int Id)
        {
            return Ok(await _toDoItem.GetTodoItemByID(Id));
        }

        [HttpPost]
        [Route("AddToDoItem")]
        public async Task<IActionResult> Post(TodoItem toDoItem)
        {
            var result = await _toDoItem.InsertTodoItem(toDoItem);

            

            if (result.TodoItemId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }


        [HttpPut]
        [Route("UpdateToDoItem")]
        public async Task<IActionResult> Put(TodoItem item)
        {
            await _toDoItem.UpdateTodoItem(item);
            return Ok("Updated Successfully");
        }


        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteToDoItem")]
        public IActionResult Delete(int id)
        {

            if (id == null)
            {
                return BadRequest();

            } else {
                _toDoItem.DeleteTodoItem(id);
                return new JsonResult("Deleted Successfully");
            }
        }

        [HttpDelete]
        [Route("DeleteAllToDoItems")]
        public async Task<IActionResult> DeleteAll()
        {
            await _toDoItem.DeleteAllToDoItems();
            return Ok("Deleted All Successfully");
        }

        [HttpGet]
        [Route("GetToDoItemByEmployee/{employee}")]
        public async Task<IActionResult> GetToDoItemByEmployee(string employee)
        {
            return Ok(await _toDoItem.GetToDoItemsByEmployee(employee));
        }

    }
}
