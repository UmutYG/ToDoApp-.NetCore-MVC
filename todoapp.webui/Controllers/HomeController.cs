using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todoapp.data.Abstract;

namespace todoapp.webui.Controllers
{
    
    public class HomeController : Controller
    {
        private ITaskRepository _taskRepository;
        public HomeController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public IActionResult Index()
        {

            return View(_taskRepository.GetAll());
        }
    }
}