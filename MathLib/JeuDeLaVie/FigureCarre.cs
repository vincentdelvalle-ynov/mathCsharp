using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLib.Helpers;

namespace MathLib.JeuDeLaVie
{
    public class FigureCarre : Figure
    {
        
        public FigureCarre(int x, int y)
            :base(x, y)
        {
            Matrice = new bool[2, 2];
            Matrice.Parcourir( (i,j) => Matrice[i,j] = true );
        }
    }
}
