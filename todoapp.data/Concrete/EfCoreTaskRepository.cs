using System;
using System.Collections.Generic;
using System.Linq;
using todoapp.data.Abstract;
using todoapp.entity;


namespace todoapp.data.Concrete
{
    public class EfCoreTaskRepository : ITaskRepository
    {
        private TaskContext context = new TaskContext();

        public void Create(Task t)
        {
            context.Tasks.Add(t);
            context.SaveChanges();
        }

        public void Delete(Task t)
        {
            context.Tasks.Remove(t);
            context.SaveChanges();
        }


        public List<Task> GetAll()
        {
            return context.Tasks.ToList();
        }

        public List<Task> GetAllByPagination(int page, int pageSize)
        {
            return context.Tasks.Skip((page-1) * pageSize).Take(pageSize).ToList();
        }

        public Task GetById(int id)
        {
            return context.Tasks.Find(id);
        }

        public List<Task> GetByStatus(bool status)
        {
            return context.Tasks.Where(t=>t.isCompleted == status)
                                .ToList();
        }

        public void Update(Task t)
        {
            var entity = context.Tasks.Find(t.TaskId);
            entity.Description = t.Description;
            entity.TaskHeader = t.TaskHeader;
            entity.isCompleted = t.isCompleted;
            context.SaveChanges();
          
        }
    }
}