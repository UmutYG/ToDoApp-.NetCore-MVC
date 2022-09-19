using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using todoapp.entity;

namespace todoapp.webui.Identity
{
    public class User : IdentityUser
    {
        public List<Task> Tasks {get; set;}
    }
}