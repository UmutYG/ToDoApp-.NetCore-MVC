using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace todoapp.webui.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please provide a UserName.")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please provide a password.")]
        public string Password { get; set; }
    }
}