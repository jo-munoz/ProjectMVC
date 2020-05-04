using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.Logica.Models.ViewModels
{
    public class ResponseViewModel
    {
        public bool IsSuccessful { get; set; }

        public List<string> Errors { get; set; }
    }
}
