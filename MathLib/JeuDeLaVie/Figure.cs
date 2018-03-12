using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib.JeuDeLaVie
{
    public abstract class Figure : IFigure
    {

        public bool[,] Matrice { get; set; }

        public Figure(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        protected int X;
        protected int Y;

        public virtual int GetHeight()
        {
            return Matrice.GetLength(0);
        }

        public virtual int GetWidth()
        {
            return Matrice.GetLength(1);
        }

        public int GetLocationX()
        {
            return X;
        }

        public int GetLocationY()
        {
            return Y;
        }

    }
}
