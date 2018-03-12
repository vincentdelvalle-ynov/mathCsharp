using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib.JeuDeLaVie
{
    public class FigureClignotant : Figure
    {
        public FigureClignotant(int x, int y)
            :base(x, y)
        {
            Matrice = new bool[3, 3];
            Matrice[0, 1] = true;
            Matrice[1, 1] = true;
            Matrice[2, 1] = true;
        }

        public override int GetHeight()
        {
            return 3;
        }

        public override int GetWidth()
        {
            return 3;
        }
    }
}
