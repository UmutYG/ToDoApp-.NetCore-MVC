using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoapp.business.Abstract;
using todoapp.data.Abstract;

namespace todoapp.business.Concrete
{
    public class TaskManager : ITaskService
    {
        private ITaskRepository _taskRepository;

        public TaskManager(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public void Create(entity.Task t)
        {
            _taskRepository.Create(t);
        }

        public void Delete(entity.Task t)
        {
            _taskRepository.Delete(t);
            
        }

        public List<entity.Task> GetAll()
        {
            return _taskRepository.GetAll();
        }

        public List<entity.Task> GetAllByPagination(int page, int pageSize,string userId)
        {
            return _taskRepository.GetAllByPagination(page,pageSize,userId);
        }

        public entity.Task GetById(int id)
        {
            return _taskRepository.GetById(id);
        }

        public List<entity.Task> GetByStatus(bool status)
        {
            return _taskRepository.GetByStatus(status);
        }

        public void Update(entity.Task t)
        {
            _taskRepository.Update(t);
        }
    }
}