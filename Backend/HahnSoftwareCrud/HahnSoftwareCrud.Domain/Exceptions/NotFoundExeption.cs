using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnSoftwareCrud.Domain.Exceptions
{
    public class NotFoundExeption : Exception
    {
        public NotFoundExeption(string? error) : base(error) { }
    }
}
