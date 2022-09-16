using System;
using System.Collections.Generic;
using System.Linq;

//using System.Threading.Tasks;
using todoapp.entity;

namespace todoapp.business.Abstract
{
    public interface ITaskService
    {
        Task GetById(int id);
        List<Task> GetAll();
        List<Task> GetByStatus(bool status);
        void Create(Task t);
        void Update(Task t);
        void Delete(Task t);
    }
}