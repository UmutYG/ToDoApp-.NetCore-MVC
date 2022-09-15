using System;
using System.Collections.Generic;
using System.Linq;
using todoapp.entity;
//using System.Threading.Tasks;

namespace todoapp.webui.Models
{
    public class EditModel
    {
        public List<Task> Tasks{ get; set; }
        public Task EditTask{ get; set; }
    }
}