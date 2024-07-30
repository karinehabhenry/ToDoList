using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    public class ToDoController : ControllerBase
    {
        private static List<ToDo>Todos = new List<ToDo>();

        private static int Id = 1;


        [HttpGet("GetTasks")]
        public IActionResult GetAllTasks()
        {
            return Ok(Todos);
        }


        [HttpGet("GetById")]
        public IActionResult GetTask(int id)
        {
            var ToDoID = Todos.SingleOrDefault(x => x.Id == id);
            if (ToDoID == null)
            {
                return NotFound();
            }
            return Ok(ToDoID);
        }

        [HttpPost("PostTask")]
        public IActionResult CreateTask(ToDo newTask)
        {
            newTask.Id = Id++;
            Todos.Add(newTask);
            return CreatedAtAction(nameof(GetTask), new { Id = newTask }, newTask);
        }



        [HttpDelete("DeleteTask")]
        public IActionResult DeleteTask(int id)
        {
            var Task = Todos.SingleOrDefault(e => e.Id == id);
            if (Task == null)
            {
                return NotFound();
            }
            Todos.Remove(Task);
            return NoContent();
        }



        [HttpPut("PutTask")]
        public IActionResult UpdateTask(ToDo updatedTask)
        {
            var Task = Todos.SingleOrDefault(e => e.Id == updatedTask.Id);

            if (Task == null)
            {
                return NotFound();
            }

            Task.Name= updatedTask.Name;
            Task.Description= updatedTask.Description;
            Task.Deadline= updatedTask.Deadline;
            Task.Duration= updatedTask.Duration;    

            return Ok(updatedTask);


        }

    }
}
