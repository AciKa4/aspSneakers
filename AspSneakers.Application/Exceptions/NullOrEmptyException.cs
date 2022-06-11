using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Application.Exceptions
{
    public class NullOrEmptyException : Exception
    {
        public NullOrEmptyException(string property)
            : base($"Property: {property} can not be empty.")
        {
        }
    }
}
