using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoapp.webui.Models
{
    public class DonationModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DonationAmount { get; set; }
        public string CardNo { get; set; }
        public string Exp { get; set; }
        public string CVC { get; set; }
        public string Message { get; set; }     
    }
}