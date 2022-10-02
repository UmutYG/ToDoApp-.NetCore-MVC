using System;
using System.Collections.Generic;
using System.Linq;

using todoapp.business.Abstract;
using todoapp.data.Abstract;
using todoapp.entity;

namespace todoapp.business.Concrete
{
    public class TaskManager : ITaskService
    {
        private IUnitOfWork _unitofwork;

        public TaskManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public void Create(entity.Task t)
        {
            _unitofwork.Tasks.Create(t);
            _unitofwork.Save();
        }

        public void Delete(entity.Task t)
        {
            _unitofwork.Tasks.Delete(t);
            _unitofwork.Save();
            
        }

        public async System.Threading.Tasks.Task<List<Task>> GetAll()
        {
            return await _unitofwork.Tasks.GetAll();
        }

        public List<entity.Task> GetAllByPagination(int page, int pageSize,string userId)
        {
            return _unitofwork.Tasks.GetAllByPagination(page,pageSize,userId);
        }

        public entity.Task GetById(int id)
        {
            return _unitofwork.Tasks.GetById(id);
        }

        public List<entity.Task> GetByStatus(bool status)
        {
            return _unitofwork.Tasks.GetByStatus(status);
        }

        public void Update(entity.Task t)
        {
            _unitofwork.Tasks.Update(t);
            _unitofwork.Save();
        }
    }
}