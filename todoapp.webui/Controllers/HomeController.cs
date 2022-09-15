using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todoapp.business.Abstract;
using todoapp.entity;

namespace todoapp.webui.Controllers
{
    
    public class HomeController : Controller
    {
        private ITaskService _taskService;
        public HomeController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        public IActionResult Index()
        {

            return View(_taskService.GetAll());
        }

        public IActionResult AddTask(string task, string desc)
        {
            Task add = new Task();
            add.TaskHeader = task;
            add.Description = desc;
            add.UserId = 1;
            _taskService.Create(add);
          
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
           var task =  _taskService.GetById(id);
           if(task != null)
           {
            _taskService.Delete(task);
            
           }
            return RedirectToAction("Index");
        }
    }
}