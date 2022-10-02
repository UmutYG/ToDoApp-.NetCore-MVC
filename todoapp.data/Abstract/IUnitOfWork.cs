using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoapp.data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ITaskRepository Tasks { get; }
        void Save();
        Task<int> SaveAsync();
    }
}