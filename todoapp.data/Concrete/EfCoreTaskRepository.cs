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

        public Task GetById(int id)
        {
            return context.Tasks.Find(id);
        }

        public void Update(Task t)
        {
            var entity = context.Tasks.Find(t.TaskId);
            Console.WriteLine(entity.Description + "  değiş  " + t.Description);
            entity.Description = t.Description;
            entity.TaskHeader = t.TaskHeader;
            entity.isCompleted = false;
            context.SaveChanges();
          
        }
    }
}