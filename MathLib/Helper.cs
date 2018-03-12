using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib
{
    public static class Helper
    {
        public static void Parcourir(this int[,] matrice, Action<int, int> action)
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

        public static void Parcourir(this int[] tableau, Action<int> action)
        {
            for (int i = 0; i < tableau.Length; i++)
            {
                action(i);
            }
        }
        public static int[] GetLine(this int[,] mat, int numLine)
        {
            int[] line = new int[mat.GetLength(1)];
            line.Parcourir(i => line[i] = mat[numLine, i]);
            return line;
        }
    }
}
