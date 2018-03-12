using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib.JeuDeLaVie
{
    public interface IFigure
    {

        bool[,] Matrice { get; set; }

        int GetLocationX();
        int GetLocationY();

        int GetWidth();
        int GetHeight();

    }
}
