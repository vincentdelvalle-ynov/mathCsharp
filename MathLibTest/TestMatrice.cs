using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLib;

namespace MathLibTest
{
    [TestClass]
    public class TestMatrice
    {

        
        [TestMethod]
        public void TestMatriceAjout()
        {
            int[,] mat1 = new int[,] {
                {1, 2},
                {3, 4},
            };
            int[,] mat2 = new int[,] {
                {1, 2},
                {3, 4},
            };
            int[,] matResult = new int[,] {
                {2, 4},
                {6, 8},
            };

            Matrice m1 = new Matrice(mat1);
            Matrice m2 = new Matrice(mat2);
            Matrice r = m1.Ajout(m2); ;
            
            // parcours des lignes
            for (int i = 0; i < matResult.GetLength(0); i++)
            {
                // parcours des colonnes
                for (int j = 0; j < matResult.GetLength(1); j++)
                {
                    Assert.AreEqual(matResult[i, j], r.matrice[i, j],
                        string.Format("position: {0}, {1}", i, j));
                }
            }
        }

        [TestMethod]
        public void TestMatriceAjoutKO()
        {
            Matrice m1 = new Matrice(new int[,]{
                { 0, 1 },
                { 2, 3 }
            });
            Matrice m2 = new Matrice(new int[,]{
                { 0, 1, 3, 4 }
            });
            try
            {
                m1.Ajout(m2);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(MatriceException));
            }
        }

        [TestMethod]
        public void TestMatriceMultipieOK()
        {
            int[,] mat1 = new int[,] {
                {1, 2, 0},
                {4, 3, -1},
            };
            int[,] mat2 = new int[,] {
                {5, 1},
                {2, 3},
                {3, 4},
            };
            int[,] matResult = new int[,] {
                {9, 7},
                {23, 9},
            };


            Matrice m1 = new Matrice(mat1);
            Matrice m2 = new Matrice(mat2);
            Matrice r = m1.Multiplie(m2); ;

            // parcours des lignes
            for (int i = 0; i < matResult.GetLength(0); i++)
            {
                // parcours des colonnes
                for (int j = 0; j < matResult.GetLength(1); j++)
                {
                    Assert.AreEqual(matResult[i, j], r.matrice[i, j],
                        string.Format("position: {0}, {1}", i, j));
                }
            }
        }

        [TestMethod]
        public void TestGetLine()
        {
            Matrice m = new Matrice(new int[,] {
                { 1, 2, 3 }, 
                { 4, 5, 6 }, 
                { 7, 8, 9 },
                { 10, 11, 12 },
            });
            
            int[] line = m.GetLine(m.matrice, 1);

            Assert.AreEqual(3, line.Length);
            Assert.AreEqual(4, line[0]);
            Assert.AreEqual(5, line[1]);
            Assert.AreEqual(6, line[2]);
        }

        [TestMethod]
        public void TestGetColumn()
        {
            Matrice m = new Matrice(new int[,] {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
                { 10, 11, 12 },
            });

            int[] column = m.GetColumn(m.matrice, 2);

            Assert.AreEqual(4, column.Length);
            Assert.AreEqual(3, column[0]);
            Assert.AreEqual(6, column[1]);
            Assert.AreEqual(9, column[2]);
            Assert.AreEqual(12, column[3]);
        }

    }
}
