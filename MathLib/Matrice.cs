using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib
{
    public class Matrice
    {
        public int[,] matrice { get; set; }


        public int this[int i,int j]
        {
            get { return matrice[i, j]; }
            set { matrice[i, j] = value; }
        }

        public Matrice(int[,] mat)
        {
            int lignes = mat.GetLength(0);
            int colones = mat.GetLength(1);

            matrice = new int[lignes, colones];
            
            ParcourirMatrice((int i, int j) => {
                matrice[i, j] = mat[i, j];
            });
        }
        
        private void ParcourirMatrice(Action<int,int> action)
        {
            matrice.Parcourir(action);
        }

        /// <summary>
        /// Retourne une matrice, résultat de l'addition entre la matrice this, et celle en paramètre
        /// </summary>
        /// <param name="m">Matrice à ajouter à this</param>
        /// <returns>Le résultat de l'addition des deux matrice</returns>
        public Matrice Ajout(Matrice mat)
        {
            int m = mat.matrice.GetLength(0);
            int n = mat.matrice.GetLength(1);

            if(m != matrice.GetLength(0) || n != matrice.GetLength(1))
            {
                throw new MatriceException("Les deux matrices doivent avoir la même taille");
            }

            Matrice result = new Matrice(new int[m, n]);
            
            ParcourirMatrice((i, j) => result.matrice[i, j] = matrice[i, j] + mat.matrice[i, j]);

            return result;
        }

        public Matrice Multiplie(Matrice mat)
        {
            int n = this.matrice.GetLength(0);
            int m = mat.matrice.GetLength(1);

            // vérification des tailles
            if(n != mat.matrice.GetLength(1)
                || m != this.matrice.GetLength(0))
            {
                throw new MatriceException("Nombre de lignes et de colonnes incompatibles");
            }
            
            Matrice result = new Matrice(new int[n, m]);

            result.ParcourirMatrice((int i,int j) =>
            {
                // récupérer la ligne i sur this (A)
                int[] lignesDeA = matrice.GetLine(i);

                // récupérer la colone j sur mat (B)
                int[] colonnesDeB = GetColumn(mat.matrice, j);

                // somme des produits ligne et colonne
                int cumul = 0;
                lignesDeA.Parcourir(k => cumul += lignesDeA[k] * colonnesDeB[k]);

                result[i, j] = cumul;
            });

            return result;
        }

        

        public int[] GetColumn(int[,] mat, int numColumn)
        {
            int[] column = new int[mat.GetLength(0)];
            column.Parcourir(i => column[i] = mat[i, numColumn]);
            return column;
        }

    }
}
