using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoapp.webapi.DTO
{
    public class TaskDTO
    {
        public string TaskHeader { get; set; }
        public string Description { get; set; }
        public bool isCompleted { get; set; }
      
    }
}