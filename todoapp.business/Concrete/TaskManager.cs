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
            throw new NotImplementedException();
        }

        public void Delete(entity.Task t)
        {
            throw new NotImplementedException();
        }

        public List<entity.Task> GetAll()
        {
            return _taskRepository.GetAll();
        }

        public entity.Task GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(entity.Task t)
        {
            throw new NotImplementedException();
        }
    }
}