using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models
{
    [Table("TodoItem")]
    public class TodoItem
    {
        [Key]
        public int TodoItemId { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public string Employee { get; set; }
    }
}
