using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib.Helpers
{
    public static class UlamSpiralHelper
    {
        public static bool DIciVersLa(int depart, int fin, Func<int, bool> stopableAction)
        {
            if(depart > fin)
            {
                return PourVersArriere(depart, fin, stopableAction);
            }
            else
            {
                return PourVersAvant(depart, fin, stopableAction);
            }
        }

        public static bool PourVersAvant(int i, int max, Func<int, bool> action)
        {
            for (; i < max; i++)
            {
                if (action(i)) return true;
            }
            return false;
        }

        public static bool PourVersArriere(int i, int max, Func<int, bool> action)
        {
            for (; i > max; i--)
            {
                if (action(i)) return true;
            }
            return false;
        }

    }
}
