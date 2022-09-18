using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using todoapp.entity;
//using System.Threading.Tasks;

namespace todoapp.webui.Models
{

    public class PaginationModel
    {
        public List<Task> Tasks { get; set; }
        public PageInfo PageInfo { get; set; }

        [Required(ErrorMessage = "Please Fill The Task")]
        public string TaskHeader { get; set; }

        [Required(ErrorMessage = "Please Fill The Description")]
        public string Description { get; set; }
      
    }

    public class PageInfo
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }

    }
}