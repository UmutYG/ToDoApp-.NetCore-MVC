using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todoapp.business.Abstract;
using todoapp.business.Concrete;
using todoapp.data.Abstract;
using todoapp.data.Concrete;

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
    }
}