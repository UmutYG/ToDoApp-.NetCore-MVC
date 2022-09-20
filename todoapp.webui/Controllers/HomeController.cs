using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
//using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todoapp.business.Abstract;
using todoapp.entity;
using todoapp.webui.Identity;
using todoapp.webui.Models;

namespace todoapp.webui.Controllers
{
    
    public class HomeController : Controller
    {
        private ITaskService _taskService;
        private UserManager<User> _userManager;
        public HomeController(ITaskService taskService, UserManager<User> userManager)
        {
            _taskService = taskService;
            _userManager = userManager;
        }   
        public async System.Threading.Tasks.Task<IActionResult> Index(string status,int currentPage=1)
        {

            const int pageSize = 10;

            if(User.Identity.IsAuthenticated){
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

                if(status == "pending")
            {
                return View(new HomePageModel()
                    {
                        Tasks = _taskService.GetByStatus(false),
                        PageInfo = new PageInfo()
                    });
            }
            else if(status == "completed"){
                return View(new HomePageModel()
                    {
                        Tasks = _taskService.GetByStatus(true),
                        PageInfo = new PageInfo()
                    });
            }
            return View(new HomePageModel(){
                PageInfo = new PageInfo(){
                    TotalPage = (int)Math.Ceiling(((float)_taskService.GetAll().Count() / pageSize)),
                    CurrentPage = currentPage},
                    Tasks = _taskService.GetAllByPagination(currentPage,pageSize,user.Id)
                });
            }
            return View(new HomePageModel(){Tasks = new List<Task>(), PageInfo = new PageInfo()});
            
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> AddTask(HomePageModel model)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            Task add = new Task();
            add.TaskHeader = model.TaskHeader;
            add.Description = model.Description;
            add.UserId = user.Id;
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

        public IActionResult Edit(int id,int p)
        {
            return View(new EditModel(){
                Tasks = _taskService.GetAll(),
                EditTask = _taskService.GetById(id)}
                );
        }

        [HttpPost]
        public IActionResult Edit(Task t)
        {
            var change = _taskService.GetById(t.TaskId);
            if(change != null)
            {
                _taskService.Update(t);
                
            }
            return RedirectToAction("Index");
        }

        public IActionResult Check(int id)
        {
            var checkTask = _taskService.GetById(id);
            if(checkTask != null)
            {
                checkTask.isCompleted = checkTask.isCompleted ? false : true;
                _taskService.Update(checkTask);
            }
            return RedirectToAction("Index");
        }
    }
}