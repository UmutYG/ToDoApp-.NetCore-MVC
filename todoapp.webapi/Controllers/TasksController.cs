using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todoapp.business.Abstract;
using todoapp.webapi.DTO;

namespace todoapp.webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _taskService.GetAll();
            var tasksDTO = new List<TaskDTO>();
            foreach (var task in tasks)
            {
                tasksDTO.Add(new TaskDTO{
                    TaskHeader = task.TaskHeader,
                    Description = task.Description,
                    isCompleted = task.isCompleted
                });
            }
            return Ok(tasksDTO);
        }
        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            var task = _taskService.GetById(id);
            if(task == null)
            {
                return NotFound(); // 404
            }
            return Ok(new TaskDTO{
                    TaskHeader = task.TaskHeader,
                    Description = task.Description,
                    isCompleted = task.isCompleted
                }); // 200
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(todoapp.entity.Task task) // Entity is in the post body
        {
            await _taskService.CreateAsync(task);
            return CreatedAtAction(nameof(GetTask),new{id = task.TaskId}, task); // post header info with 201 status code.
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, todoapp.entity.Task task)
        {
            if(id != task.TaskId)
            {
                return BadRequest();
            }

            var tasktoUpdate = _taskService.GetById(id);
            if(task == null)
            {
                return NotFound();
            }
            await _taskService.UpdateAsync(tasktoUpdate, task);
            return NoContent();
        } 

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task =  _taskService.GetById(id);
            if(task == null)
            {
                return NotFound();
            }
            await _taskService.DeleteAsync(task);
            return NoContent();

        }

        private static TaskDTO TaskToDTO(todoapp.entity.Task t)
        {
            return new TaskDTO{
                TaskHeader = t.TaskHeader,
                Description = t.Description,
                isCompleted = t.isCompleted
            };
        }
    }

    
}