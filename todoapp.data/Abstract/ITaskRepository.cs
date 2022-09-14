using System;
using System.Collections.Generic;
using System.Linq;
using todoapp.entity;

namespace todoapp.data.Abstract
{
    public interface ITaskRepository
    {
        Task GetById(int id);
        List<Task> GetAll();
        void Create(Task t);
        void Update(Task t);
        void Delete(Task t);
    }
}