using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoapp.entity
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskHeader { get; set; }
        public string Description { get; set; }
        public bool isCompleted { get; set; }
        public User user { get; set; }
        // public int UserId { get; set; } Will be added automaticly.
    }
}