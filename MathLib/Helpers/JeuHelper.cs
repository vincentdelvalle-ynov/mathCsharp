using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib.Helpers
{
    public static class JeuHelper
    {
        public static void Parcourir(this bool[,] matrice, Action<int, int> action)
        {
            int lignes = matrice.GetLength(0);
            int colones = matrice.GetLength(1);

            for (int i = 0; i < lignes; i++)
            {
                for (int j = 0; j < colones; j++)
                {
                    action(i, j);
                }
            }
        }
    }
}
