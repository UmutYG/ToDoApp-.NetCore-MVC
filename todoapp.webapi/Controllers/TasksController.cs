using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todoapp.business.Abstract;

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
            return Ok(tasks);
        }
        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            var task = _taskService.GetById(id);
            if(task == null)
            {
                return NotFound(); // 404
            }
            return Ok(task); // 200
        }
    }

    
}