using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftwareCrud.Application.Models
{
    public class ErrorModel
    {
        public ErrorModel(string error)
        {
            Error = error;
        }
        public string Error { get; set; }
    }
}
