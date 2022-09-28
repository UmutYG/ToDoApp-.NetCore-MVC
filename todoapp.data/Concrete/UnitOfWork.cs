using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoapp.data.Abstract;

namespace todoapp.data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskContext _context;
        public UnitOfWork(TaskContext context)
        {
            _context = context;
        }
        private EfCoreTaskRepository _taskRepository;
        public ITaskRepository Tasks => _taskRepository = _taskRepository?? new EfCoreTaskRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            ;_context.SaveChanges();
        }
    }
}