using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib
{

    /// <summary>
    /// Classe dans laquelle on range toutes nos méthodes d'extension
    /// </summary>
    public static class MatriceHelper
    {

        /// <summary>
        /// Méthode d'extension permettant de parcourir un tableau à deux entrées
        /// </summary>
        /// <param name="matrice">Un tableau à deux entrées</param>
        /// <param name="action">Une action a réaliser à chaque itération du parcours</param>
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

        /// <summary>
        /// Méthode d'extension permettant de parcourir un tableau d'entiers
        /// </summary>
        /// <param name="tableau">Un tableau d'entiers</param>
        /// <param name="action">Action à réaliser à chaque itération</param>
        public static void Parcourir(this int[] tableau, Action<int> action)
        {
            for (int i = 0; i < tableau.Length; i++)
            {
                action(i);
            }
        }

        /// <summary>
        /// Méthode d'extension permettant de récupérer toutes les valeurs sur une ligne numLine
        /// dans un tableau à deux entrées
        /// </summary>
        /// <param name="mat">Le tableau à deux entrées</param>
        /// <param name="numLine">L'indice de la ligne (commence à 0)</param>
        /// <returns>Un tableau avec toutes les valeurs de la ligne dans l'ordre d'apparition</returns>
        public static int[] GetLine(this int[,] mat, int numLine)
        {
            int[] line = new int[mat.GetLength(1)];
            line.Parcourir(i => line[i] = mat[numLine, i]);
            return line;
        }

        /// <summary>
        /// Méthode d'extension permettant de récupérer toutes les valeurs sur une colonne numColumn
        /// dans un tableau à deux entrées
        /// </summary>
        /// <param name="mat">Le tableau à deux entrées</param>
        /// <param name="numLine">L'indice de la colonne (commence à 0)</param>
        /// <returns>Un tableau avec toutes les valeurs de la colonne dans l'ordre d'apparition</returns>
        public static int[] GetColumn(this int[,] mat, int numColumn)
        {
            int[] column = new int[mat.GetLength(0)];
            column.Parcourir(i => column[i] = mat[i, numColumn]);
            return column;
        }
    }
}
