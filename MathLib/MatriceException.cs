using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib
{
    public class MatriceException : Exception
    {
        public MatriceException(string message)
            : base(message)
        {
        }
    }
}
