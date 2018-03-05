using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib
{
    public class FractionInitException : Exception
    {
        public FractionInitException(string message)
            : base(message)
        {

        }
    }
}
