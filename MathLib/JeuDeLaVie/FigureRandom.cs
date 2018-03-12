using MathLib.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib.JeuDeLaVie
{
    public class FigureRandom : Figure
    {
        private static Random rand = new Random(DateTime.Now.Millisecond);

        private int width;
        private int height;

        public FigureRandom(int x, int y, int width, int height)
            : base(x, y)
        {
            this.width = width;
            this.height = height;

            Matrice = new bool[height, width];
            Matrice.Parcourir((i, j) => {
                Matrice[i, j] = rand.Next() % 2 == 0;
            });
        }

        public override int GetHeight()
        {
            return height;
        }

        public override int GetWidth()
        {
            return width;
        }
    }
}
